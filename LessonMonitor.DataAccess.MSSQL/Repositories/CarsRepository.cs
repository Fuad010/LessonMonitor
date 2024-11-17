using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public Task AddCarAsync(Car car)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> GetAllCarsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetCarByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCarAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
