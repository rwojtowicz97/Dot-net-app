using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Exceptions;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Infrastructure.Services
{
    using Passenger.Core.Domain;

    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public PassengerService(IPassengerRepository passengerRepository, IUserRepository userRepository,
            IMapper mapper)
        {
            _passengerRepository = passengerRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PassengerDetailsDto> GetAsync(Guid userId)
        {
            var passenger = await _passengerRepository.GetAsync(userId);
            
            return _mapper.Map<PassengerDetailsDto>(passenger);
        }
        public async Task<IEnumerable<PassengerDto>> BrowseAsync()
        {
            var passengers = await _passengerRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<PassengerDto>>(passengers);
        }
        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);

            var passenger = await _passengerRepository.GetAsync(userId);
            
            if(passenger != null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.PassengerAlreadyExists, $"Passenger with id: {userId} already exists.");
            }

            passenger = new Passenger(user);
            await _passengerRepository.AddAsync(passenger);
        }

        public async Task DeleteAsync(Guid userId)
        {
            var passenger = await _passengerRepository.GetAsync(userId);
            await _passengerRepository.DeleteAsync(passenger);
        }
    }
}