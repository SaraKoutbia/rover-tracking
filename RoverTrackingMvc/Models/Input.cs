using System.ComponentModel.DataAnnotations;
using RoverTrackingService.CustomAttributes;
namespace RoverTrackingService.Models
{
    public class input
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="* The input is required.")]
        [ValidInputFormatAttribute]
        public string inputStr { get; set; }

    }
}