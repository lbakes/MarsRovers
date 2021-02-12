using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Models
{
    public class Rover
    {
        [Required]
        [RegularExpression(@"^[0123456789NSEWnsew]+$", ErrorMessage = "Make sure all characters are valid.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Start Position must be 3 characters long (i.e. '12N').")]
        [DisplayName("Start Position")]
        public string InitialPosition { get; set; }

        [Required]
        [RegularExpression(@"^[lrmLRM]+$", ErrorMessage = "Make sure all characters are valid.")]
        [DisplayName("Turn/Move Instructions")]
        public string Instructions { get; set; }
    }
}
