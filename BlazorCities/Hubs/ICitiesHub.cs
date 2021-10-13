using BlazorCities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCities.Hubs
{
    public interface ICitiesHub
    {
        public Task Update(City city);
    }
}
