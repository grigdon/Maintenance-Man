using CarMaintenance.Api.Models;
using CarMaintenance.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Api.Enterprise
{
    // Enterprise controller
    // Acts as a middle-man between DbContext and the controller
    public class CarEC
    {
        private readonly CarDbContext _context;
        
        // Dependency Injection of CarDbContext
        public CarEC(CarDbContext context)
        {
            _context = context;
        }
        
        // Create Car
        public async Task<Car> CreateCarAsync(Car car)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
        
        // Read all cars
        public async Task<List<Car>> GetCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }
        
        // Read car == car.id
        public async Task<Car?> GetCarByIdAsync(Guid carId)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.Id == carId);
        }
        
        // Read car == user.id
        public async Task<Car?> GetCarByUserIdAsync(Guid userId)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.UserId == userId);
        }
        
        // Update car
        public async Task<Car?> UpdateCarAsync(Guid id, Car updatedCar)
        {
            var existingCar = await _context.Cars.FindAsync(id);

            if (existingCar == null)
            {
                return null;
            }
            
            // Update properties
            existingCar.Nickname = updatedCar.Nickname;
            existingCar.Year = updatedCar.Year;
            existingCar.Make = updatedCar.Make;
            existingCar.Model = updatedCar.Model;
            existingCar.Trim = updatedCar.Trim;
            existingCar.Engine = updatedCar.Engine;
            existingCar.Transmission = updatedCar.Transmission;
            existingCar.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingCar;
        }
        
        // Delete a car
        public async Task<bool> DeleteCarAsync(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            
            if (car == null)
                return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}