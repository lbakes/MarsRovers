using MarsRovers.Models;
using MarsRovers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarsRovers.Controllers
{
    public class RoverController : Controller
    {
        private int _roverNumber;
        public RoverController(IOptions<RoverOptions> roverOptions)
        {
            _roverNumber = roverOptions.Value.RoverNumber;
        }
        public IActionResult Index()
        {
            List<Rover> rovers = new List<Rover>();

            for (int i = 0; i < _roverNumber; i++)
            {
                rovers.Add(new Rover());
            }

            RoverViewModel rvm = new RoverViewModel()
            {
                Rovers = rovers
            };
    
            return View(rvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RoverViewModel roverVM)
        {
            if (ModelState.IsValid)
            {
                TempData["RoverData"] = JsonConvert.SerializeObject(roverVM);
                return RedirectToAction("Index", "Results");
            }

            return View(roverVM);
        }
    }
}