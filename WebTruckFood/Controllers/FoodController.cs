using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebTruckFood.Models;
using WebTruckFood.Repository;

namespace WebTruckFood.Controllers
{
    public class FoodController : Controller
    {
        private readonly ITruckRepository _repository;
        public FoodController(ITruckRepository repository)
        {
            _repository = repository;
        }

        // GET: Food
        public ActionResult Index(ScheduleMV model)
        {
            model = _repository.GetModel(model);

            return View(model);
        }        
    }
}