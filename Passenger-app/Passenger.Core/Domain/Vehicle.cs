using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Name { get; protected set; }
        public int Seats { get; protected set; }
        public string Brand { get; protected set; }

        protected Vehicle()
        {

        }
        protected Vehicle(string name, int seats, string brand)
        {
            SetName(name);
            SetSeats(seats);
            SetBrand(brand);

        }

        public void SetName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Name = name;
            }
            else
            {
                throw new Exception("This name is invaild.");
            }
        }

        public void SetBrand(string brand)
        {
            if (!string.IsNullOrWhiteSpace(brand))
            {
                Brand = brand;
            }
            else
            {
                throw new Exception("This Brand is invaild.");
            }
        }
        public void SetSeats(int seats)
        {
            if(seats > 0 || seats <9)
            {
                Seats = seats;
            }
            else
            {
                if(seats < 0)
                {
                    throw new Exception("Numer of seats must be greater than 0");
                }
                else if(seats > 9)
                {
                    throw new Exception("You can not provide more than 9 seats");
                }
            }
        }

        public static Vehicle Create(string name, string brand, int seats)
            => new Vehicle(name, seats, brand);
    }

}
