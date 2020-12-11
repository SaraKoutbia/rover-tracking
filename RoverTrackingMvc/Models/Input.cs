using System.ComponentModel.DataAnnotations;
using RoverTrackingMvc.CustomAttributes;
namespace RoverTrackingMvc.Models
{
    public class Input
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "* The input is required.")]
        [ValidInputFormatAttribute(LowerRight_Xcoordinates = 0, LowerRight_Ycoordinates = 0)]
        public string InputStr { get; set; }

    }
}