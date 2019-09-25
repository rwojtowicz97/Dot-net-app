using System.Threading.Tasks;
using Passenger.Core.Repositories;
using AutoMapper;
using Passenger.Infrastructure.Services;
using Passenger.Core.Domain;
using FluentAssertions;
using Xunit;
using Moq;
using System;

namespace Passenger.Tests.Services
{
    public class DriverServiceTests
    {
        [Fact]
        public async Task create_async_should_invoke_add_assync_on_repository()
        {
            var driverRepositoryMock = new Mock<IDriverRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypter = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, encrypter.Object, mapperMock.Object);
            var userId = Guid.NewGuid();
            await userService.RegisterAsync(userId,"driver@email.com", "drivername", "secret1234", "user");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);

            var driverService = new DriverService(driverRepositoryMock.Object, userRepositoryMock.Object, mapperMock.Object);
            await driverService.CreateAsync(userId);

            driverRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Driver>()), Times.Once);
        }
    }
}