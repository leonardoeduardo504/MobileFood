using ApiMobileFood.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ApiMobileFood.Repository
{
    public class TruckRepository : ITruckRepository
    {
        public HttpClient Client { get; set; }
        public TruckRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["trucksUrl"].ToString());
        }

        public List<FoodTruck> GetAll()
        {
            List<FoodTruck> items = new List<FoodTruck>();
            HttpResponseMessage response = Client.GetAsync("resource/jjew-r69b.json").Result;
            if(response.IsSuccessStatusCode)
                items = response.Content.ReadAsAsync<List<FoodTruck>>().Result;

            return items;
        }

        public List<FoodTruck> GetBySchedule(string day, string time)
        {
            List<FoodTruck> items = new List<FoodTruck>();
            TimeSpan timeReq = TimeSpan.Parse(time);
            HttpResponseMessage response = Client.GetAsync("resource/jjew-r69b.json?dayofweekstr=" + day).Result;
            if (response.IsSuccessStatusCode)
                items = response.Content.ReadAsAsync<List<FoodTruck>>().Result;            
            
            items.ForEach(d =>
            {
                TimeSpan start, end;
                d.isOpen = false;
                if (TimeSpan.TryParseExact(d.start24, "h\\:mm", CultureInfo.CurrentCulture, out start) && TimeSpan.TryParseExact(d.end24, "h\\:mm", CultureInfo.CurrentCulture, out end))
                {
                    d.location = d.location != null ? d.location.Trim() : String.Empty;
                    d.optionaltext = d.optionaltext != null ? d.optionaltext.Trim() : String.Empty;
                    d.startStime = start;
                    d.endStime = end;
                    d.isOpen = (d.startStime <= timeReq && d.endStime >= timeReq);
                }
            });

            return items.Where(c => c.isOpen).ToList();
        }
    }
}