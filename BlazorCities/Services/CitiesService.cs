using BlazorCities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCities.Services
{
    public class CitiesService
    {
        private readonly DataContext _dbContext;

        public CitiesService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _dbContext.Cities.ToListAsync();
        }

        public async Task<City> GetCityAsync(int id)
        {
            return await _dbContext.Cities.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<bool> InsertCityAsync(City city)
        {
            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCityAsync(City city)
        {
            _dbContext.Cities.Update(city);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCityAsync(City city)
        {
            _dbContext.Remove(city);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }
}
