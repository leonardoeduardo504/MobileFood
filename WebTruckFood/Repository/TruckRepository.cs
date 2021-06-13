using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebTruckFood.Models;

namespace WebTruckFood.Repository
{
    public class TruckRepository : ITruckRepository
    {
        public List<DayWeek> GetAllDays()
        {
            List<DayWeek> days = new List<DayWeek>();
            days.Add(new DayWeek { Id = 1, Name = "Monday" });
            days.Add(new DayWeek { Id = 2, Name = "Tuesday" });
            days.Add(new DayWeek { Id = 3, Name = "Wednesday" });
            days.Add(new DayWeek { Id = 4, Name = "Thursday" });
            days.Add(new DayWeek { Id = 5, Name = "Friday" });
            days.Add(new DayWeek { Id = 6, Name = "Saturday" });
            days.Add(new DayWeek { Id = 7, Name = "Sunday" });

            return days;
        }

        public ScheduleMV GetModel(ScheduleMV model)
        {
            if (model != null && !String.IsNullOrEmpty(model.Day) && !String.IsNullOrEmpty(model.Time) && CheckFormat24(model.Time))
            {
                model.Days = GetAllDays();
                model.Day = model.Days.FirstOrDefault(c => c.Id == int.Parse(model.Day)).Name;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/MobileFood/Get?day=" + model.Day + "&time=" + model.Time);

                if (response.IsSuccessStatusCode)
                    model.Detail = response.Content.ReadAsAsync<List<FoodTruck>>().Result;
                else
                    model.Detail = new List<FoodTruck>();
            }
            else
            {
                model = new ScheduleMV() { Detail = new List<FoodTruck>() };
                model.Days = GetAllDays();
            }
            return model;
        }

        public bool CheckFormat24(string ui)
        {
            string[] parts = ui.Split(':');
            if (parts.Count() == 2)
            {
                int hour = int.Parse(parts[0]);
                int mins = int.Parse(parts[1]);
                if (hour >= 0 && hour < 24 && mins >= 0 && mins < 60)
                    return true;
            }
            return false;
        }
    }
}