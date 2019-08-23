using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Moq;
using Passenger.Core.Repositories;
using AutoMapper;
using Passenger.Infrastructure.Repositories;
using Passenger.Infrastructure.Services;
using Passenger.Core.Domain;

namespace Passenger.Tests.Services
{
    
    public class UserServiceTests
    {
        [Fact]
        public async Task Test()
        {
           var userRepositoryMock = new Mock<IUserRepository>();
           var mapperMock = new Mock<IMapper>();

           var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
           await userService.RegisterAsync("user@email.com", "user", "secret123");

           userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Exactly(1));
        }
    }
}