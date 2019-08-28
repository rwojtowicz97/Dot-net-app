using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Passenger.Api;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Infrastructure.DTO;
using FluentAssertions;
using Xunit;

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
            var response = await _client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.Should().BeEquivalentTo(email);
        }
    }
}