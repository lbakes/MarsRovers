using MarsRovers.Models;
using System.Collections.Generic;

namespace MarsRovers.ViewModels
{
    public class ResultsViewModel
    {
        public List<Rover> Rovers { get; set; }
        public Grid Grid { get; set; }
        public List<string> Results { get; set; }
    }
}
