using MarsRovers.Models;
using MarsRovers.Utility;
using MarsRovers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MarsRovers.Controllers
{
    public class ResultsController : Controller
    {

        public IActionResult Index()
        {
            RoverViewModel rvm = JsonConvert.DeserializeObject<RoverViewModel>(TempData["RoverData"].ToString());

            TempData["RoverData"] = JsonConvert.SerializeObject(rvm);

            InstructionHandler instructionHandler = new InstructionHandler();

            ResultsViewModel results = new ResultsViewModel()
            {
                Grid = rvm.Grid,
                Rovers = rvm.Rovers,
                Results = instructionHandler.GetUpdatedPosition(rvm)
            };

            return View(results);
        }

    }
}