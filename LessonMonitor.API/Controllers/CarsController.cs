using LessonMonitor.API.Contracts;
using LessonMonitor.BusinessLogic;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
       private readonly ICarsService _carsService;
        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            var cars = await _carsService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _carsService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car carDto)
        {
            if (carDto == null)
            {
                return BadRequest("Car data is required.");
            }

            var car = new Core.Car
            {
                Make = carDto.Make,
                Model = carDto.Model,
                Year = carDto.Year,
                PricePerDay = carDto.PricePerDay,
                IsAvailable = carDto.IsAvailable,
                CarImages = carDto.CarImages?.Select(img => new Core.CarImage
                {
                    ImageUrl = img.ImageUrl
                }).ToList()
            };

            await _carsService.AddCarAsync(car);
            return Ok("Car added successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id) 
        { 
            await _carsService.DeleteCarAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car carDto)
        {
            if (id != carDto.Id)
            {
                return BadRequest();
            }

            var car = new Core.Car
            {
                Id = carDto.Id,
                Make = carDto.Make,
                Model = carDto.Model,
                Year = carDto.Year,
                PricePerDay = carDto.PricePerDay,
                IsAvailable = carDto.IsAvailable,
                CarImages = carDto.CarImages?.Select(img => new Core.CarImage
                {
                    Id = img.Id,
                    ImageUrl = img.ImageUrl
                }).ToList()
            };

            await _carsService.UpdateCarAsync(car);
            return NoContent();
        }
    }
}
