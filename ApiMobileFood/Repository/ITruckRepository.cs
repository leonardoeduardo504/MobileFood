using ApiMobileFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMobileFood.Repository
{
    public interface ITruckRepository
    {
        List<FoodTruck> GetAll();
        List<FoodTruck> GetBySchedule(string day, string time);
    }
}
