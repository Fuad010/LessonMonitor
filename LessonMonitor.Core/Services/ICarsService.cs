using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
    public interface ICarsService
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
    }
}
