using HolidayWebChat.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HolidayWebChat.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HolidayWebChat.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration { get; set; }
        private ILocationRepository _locationRepository;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _locationRepository = new LocationRepository(_configuration.GetConnectionString("default"));
        }

        public IActionResult Index()
        {
            if (Request.Method != "POST")
            {
                return View();
            }
            //var form = Request.Form;
            //var location = form["Continent"];
            //HttpContext.Session.SetString("Continent", location);
            return RedirectToAction("QuestionOneSubmit");
        }

        [HttpPost] public IActionResult QuestionOneSubmit(ChatBotModel model)
        {
            return QuestionTwo(model);
        }
        
        public IActionResult QuestionTwo(ChatBotModel model)
        {
            return View("QuestionTwo", model);
        }

        [HttpPost] public IActionResult QuestionTwoSubmit(ChatBotModel model)
        {
            return QuestionThree(model);
        }

        public IActionResult QuestionThree(ChatBotModel model)
        {
            return View("QuestionThree", model);   
        }

        [HttpPost] public IActionResult QuestionThreeSubmit(ChatBotModel model)
        {
            return QuestionFour(model);
        }

        public IActionResult QuestionFour(ChatBotModel model)
        {
            return View("QuestionFour", model);
        }

        [HttpPost]
        public IActionResult QuestionFourSubmit(ChatBotModel model)
        {
            return QuestionFive(model);
        }

        public IActionResult QuestionFive(ChatBotModel model)
        {
            return View("QuestionFive", model);
        }

        [HttpPost]
        public IActionResult QuestionFiveSubmit(ChatBotModel model)
        {
            return QuestionSix(model);
        }

        public IActionResult QuestionSix(ChatBotModel model)
        {
            return View("QuestionSix", model);
        }

        [HttpPost]
        public IActionResult QuestionSixSubmit(ChatBotModel model)
        {
            return Recommendation(model);
        }

        public IActionResult Recommendation(ChatBotModel model)
        {
            return View("Recommendation", model);
        }
        
        public IActionResult ReturnToStart()
        {
            return RedirectToAction("Index");
        }

        public IActionResult LocationInfo()
        {
            string continent = HttpContext.Session.GetString("Continent");
            IEnumerable<Location> locations = _locationRepository.GetLocationByContinent(continent);
            return View(locations);
        }

        public IActionResult Privacy()
        {
            





            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
