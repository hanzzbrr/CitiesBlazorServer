using BlazorCities.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCities.Hubs
{
    public class CitiesHub : Hub <ICitiesHub>
    {
        public async Task UpdateCity(City city)
        {
            await Clients.All.Update(city);
        }
    }
}
