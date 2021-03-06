using BlazorCities.Data;
using BlazorCities.Hubs;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<CitiesHub, ICitiesHub> _hubContext;

        public CitiesService(DataContext dbContext, IHubContext<CitiesHub, ICitiesHub> hubContext)
        {
            _dbContext = dbContext;
            _hubContext = hubContext;
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
            await _hubContext.Clients.All.SendCities(_dbContext.Cities);
            return true;
        }

        public async Task<bool> UpdateCityAsync(City city)
        {
            _dbContext.Cities.Update(city);
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendCities(_dbContext.Cities);
            return true;
        }

        public async Task<bool> DeleteCityAsync(City city)
        {
            _dbContext.Remove(city);
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendCities(_dbContext.Cities);
            return true;
        }

        public async Task<int> GetMaxId()
        {                        
            return await _dbContext.Cities.MaxAsync(c => c.ID);
        }

        
    }
}
