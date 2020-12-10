using System.ComponentModel.DataAnnotations;
using RoverTrackingMvc.CustomAttributes;
namespace RoverTrackingMvc.Models
{
    public class Input
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "* The input is required.")]
        [ValidInputFormatAttribute]
        public string InputStr { get; set; }

    }
}