using System.ComponentModel.DataAnnotations;
using RoverTrackingService.CustomAttributes;
namespace RoverTrackingService.Models
{
    public class input
    {
        [Required]
        [ValidInputFormatAttribute]
        public string inputStr { get; set; }

    }
}