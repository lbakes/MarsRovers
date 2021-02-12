using MarsRovers.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarsRovers.ViewModels
{
    public class RoverViewModel
    {
        public List<Rover> Rovers { get; set; }
        [Required]
        public Grid Grid { get; set; }
        public int RoverAmount { get; set; }
    }
}
