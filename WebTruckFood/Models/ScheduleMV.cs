using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTruckFood.Models
{
    public class ScheduleMV
    {        
        public string Day { get; set; }
        [Required]
        public string Time { get; set; }

        public List<FoodTruck> Detail { get; set; }
        public List<DayWeek> Days { get; set; }        
    }
}