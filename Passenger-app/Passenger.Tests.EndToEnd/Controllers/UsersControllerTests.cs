using System;
using System.Text;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Passenger.Api;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Infrastructure.DTO;
using FluentAssertions;
using Xunit;
using Passenger.Infrastructure.Commands.Users;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests : ControllerTestBase
    {
        [Fact]
        public async Task given_valid_emaill_user_should_exists()
        {
            var email = "user1@mail.com";
            var user = await GetUserAsync(email);
            user.Email.Should().BeEquivalentTo(email);
        }

        [Fact]
        public async Task given_valid_emaill_user_should_not_exists()
        {
            var email = "user1000@mail.com";
            var response = await Client.GetAsync($"users/{email}");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
       [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                Email = "testowy@mail.com",
                Username = "testowy",
                Password = "Testowe123"
            };
            var payload = GetPayload(command);
            var response = await Client.PostAsync("users", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.Should().BeEquivalentTo(command.Email);
        }
        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}