using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTruckFood.Models
{
    public class FoodTruck
    {
        public int dayorder { get; set; }
        public string dayofweekstr { get; set; }
        public string location { get; set; }
        public string Comlocationdescpany { get; set; }
        public string start24 { get; set; }
        public string end24 { get; set; }
        public string optionaltext { get; set; }
        public TimeSpan? startStime { get; set; }
        public TimeSpan? endStime { get; set; }
        public bool isOpen { get; set; }
    }
}