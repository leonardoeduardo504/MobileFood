using ApiMobileFood.Models;
using ApiMobileFood.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ApiMobileFood.Controllers
{
    public class MobileFoodController : ApiController
    {
        private readonly ITruckRepository _repository;
        public MobileFoodController(ITruckRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public JsonResult<List<FoodTruck>> GetAll()
        {
            var items = _repository.GetAll();
            return Json<List<FoodTruck>>(items);
        }

        [HttpGet]
        public JsonResult<List<FoodTruck>> Get(string day, string time)
        {
            var item = _repository.GetBySchedule(day, time);
            return Json<List<FoodTruck>>(item);
        }
    }
}
