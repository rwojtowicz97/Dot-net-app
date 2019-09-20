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

    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
           var userRepositoryMock = new Mock<IUserRepository>();
           var mapperMock = new Mock<IMapper>();
           var encrypter = new Mock<IEncrypter>();

           var userService = new UserService(userRepositoryMock.Object, encrypter.Object, mapperMock.Object);
           await userService.RegisterAsync(Guid.NewGuid(),"user@email.com", "username", "secret1234", "user");

           userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task when_calling_get_async_and_user_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypter = new Mock<IEncrypter>();

            var userService =new UserService(userRepositoryMock.Object, encrypter.Object, mapperMock.Object);
            await userService.GetAsync("user1@mail.com");
            
            var user = new User(Guid.NewGuid(),"user1@mail.com", "testowy", "haslo123", "user","salt");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                              .ReturnsAsync(user);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
        [Fact]
        public async Task when_calling_get_async_and_user_does_not_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypter = new Mock<IEncrypter>();

            var userService =new UserService(userRepositoryMock.Object, encrypter.Object, mapperMock.Object);
            await userService.GetAsync("user@mail.com");

            userRepositoryMock.Setup(x => x.GetAsync("user@mail.com"))
                              .ReturnsAsync(() => null);

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
    }
}