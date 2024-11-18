using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        private readonly LessonMonitorDbContext _context;
        public CarsRepository(LessonMonitorDbContext context)
        {
            _context = context;
        }

        public async Task AddCarAsync(Car car)
        {
            var entityCar = new Entities.Car
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                PricePerDay = car.PricePerDay,
                IsAvailable = car.IsAvailable
            };
            await _context.Cars.AddAsync(entityCar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            var entityCars = await _context.Cars.ToListAsync();

            var coreCars = entityCars.Select(car => new Car
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                PricePerDay = car.PricePerDay,
                IsAvailable = car.IsAvailable
            }).ToList();

            return coreCars;
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var entityCar = await _context.Cars.FindAsync(id);
        
            if(entityCar != null)
            {
                return null;
            }

            return new Car
            {
                Id = entityCar.Id,
                Make = entityCar.Make,
                Model = entityCar.Model,
                Year = entityCar.Year,
                PricePerDay = entityCar.PricePerDay,
                IsAvailable = entityCar.IsAvailable
            };
        }

        public async Task UpdateCarAsync(Car car)
        {
            var entityCar = await _context.Cars.FindAsync(car.Id);

            if (entityCar == null)
            {
                throw new Exception($"Car with ID {car.Id} not found.");
            }

            entityCar.Make = car.Make;
            entityCar.Model = car.Model;
            entityCar.Year = car.Year;
            entityCar.PricePerDay = car.PricePerDay;
            entityCar.IsAvailable = car.IsAvailable;

            _context.Cars.Add(entityCar);
            await _context.SaveChangesAsync();
        }
    }
}
