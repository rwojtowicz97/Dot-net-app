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
    public class UsersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UsersControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().
                    UseStartup<Startup>());
            _client = _server.CreateClient();
        }
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
            var response = await _client.GetAsync($"users/{email}");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
       [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Email = "testowy@mail.com",
                Username = "testowy",
                Password = "Testowe123"
            };
            var payload = GetPayload(request);
            var response = await _client.PostAsync("users", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"users/{request.Email}");

            var user = await GetUserAsync(request.Email);
            user.Email.Should().BeEquivalentTo(request.Email);
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            //Content type: application/json
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}