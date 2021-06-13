using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTruckFood.Models;

namespace WebTruckFood.Repository
{
    public interface ITruckRepository
    {
        List<DayWeek> GetAllDays();
        ScheduleMV GetModel(ScheduleMV model);
    }
}
