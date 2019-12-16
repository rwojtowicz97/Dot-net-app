using System;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Driver> GetOrFailAsync(this IDriverRepository repository, Guid userId)
        {
            var driver = await repository.GetAsync(userId);
            if(driver == null)
            {
                throw new Exception($"Drivers with id '{userId}' doesn't exists.");
            }

            return driver;
        }

        public static async Task<Driver> GetOrFailAsync(this IDriverRepository repository, string username)
        {
            var driver = await repository.GetAsync(username);
            if(driver == null)
            {
                throw new Exception($"Drivers with name '{username}' doesn't exists.");
            }

            return driver;
        }

        public static async Task<User> GetOrFailAsync(this IUserRepository repository, Guid userId)
        {
            var user = await repository.GetAsync(userId);
            if(user == null)
            {
                throw new Exception($"User with id '{userId}' doesn't exists.");
            }

            return user;
        }
    }
}