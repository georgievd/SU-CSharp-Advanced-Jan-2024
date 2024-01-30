using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count
        {
            get => cars.Count;
        } 

        public Parking(int capacity)
        {
            cars = new List<Car>(capacity);
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            string[] registrations = cars.Select(c => c.RegistrationNumber).ToArray();
            if (registrations.Contains(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
          //  Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            Car car = GetCar(registrationNumber);
            if (car is null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string number in registrationNumbers)
            {
                cars.RemoveAll(c => c.RegistrationNumber == number);
            }
        }
    }
}
