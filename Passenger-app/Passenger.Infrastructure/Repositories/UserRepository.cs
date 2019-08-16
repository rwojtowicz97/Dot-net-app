using System;
using System.Collections.Generic;
using Passenger.Infrastructure.Repositories;
using Passenger.Domain;

namespace Passenger.Core.Repositories
{
  public class UserRepository
  {
        User Get(Guid id);
        User Get(string email);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Remove(Guid id);
  }
}
