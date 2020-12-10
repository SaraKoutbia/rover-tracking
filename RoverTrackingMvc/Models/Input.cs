using System.ComponentModel.DataAnnotations;
using RoverTrackingService.CustomAttributes;
namespace RoverTrackingService.Models
{
    public class Input
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "* The input is required.")]
        [ValidInputFormatAttribute]
        public string InputStr { get; set; }

    }
}