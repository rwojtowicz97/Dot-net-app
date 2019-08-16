using System;
using Passenger.Core.Repositories;
using Passenger.Domain;


namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserService user)
        {

        }
        public void Register(string email, string username, string password)
        {
            var user = _userRepository.Get(email);
            if (user != null)
            {
                throw new Exception($"User with email: {email} already exists.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            _userRepository.Add(user);

        }
    }
}