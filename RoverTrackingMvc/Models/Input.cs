using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using RoverTrackingService.CustomAttributes;
namespace RoverTrackingService.Models
{
    public class input
    {
        [Required]
        //TODO[ValidInputAttribute]
        public string inputStr { get; set; }

    }
}