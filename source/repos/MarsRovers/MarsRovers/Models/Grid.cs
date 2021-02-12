using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Models
{
    public class Grid
    {
        [Required]
        [DisplayName("Base")]
        public int X { get; set; }

        [Required]
        [DisplayName("Height")]
        public int Y { get; set; }
    }
}
