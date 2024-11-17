using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.BusinessLogic
{
    public class CarsService : ICarsService
    {
        private readonly ICarsRepository _carsRepository;
        public CarsService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }
        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _carsRepository.GetAllCarsAsync();
        }
        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _carsRepository.GetCarByIdAsync(id);
        }
        public async Task AddCarAsync(Car car)
        {
            await _carsRepository.AddCarAsync(car);
        }
        public async Task DeleteCarAsync(int id)
        {
            await _carsRepository.DeleteCarAsync(id);
        }
        public async Task UpdateCarAsync(Car car)
        {
            await _carsRepository.UpdateCarAsync(car);
        }
    }
}
