using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RoverTrackingService.Models;

namespace RoverTrackingService.CustomAttributes
{
    public class ValidInputFormatAttribute : ValidationAttribute
    {
        Coordinates upperRightCoordinates { get; set; }

        string trajectory { get; set; }

        public List<Rover> rovers { get; set; }

        //TODO: rewrite the error messages 
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            var strValue = value.ToString();

            var inputLines = strValue.Split(new[] { Environment.NewLine },
                                           StringSplitOptions.None).Select(l => l.Trim().ToUpper()).Where(l => l != "");

            //var errorMessage = FormatErrorMessage((validationContext.DisplayName));

            var firstLineStrs = inputLines.First().Where(x => x != ' ');

            if (firstLineStrs.Count() != 2
                || !int.TryParse(firstLineStrs.ElementAt(0).ToString(), out int xcoordinate)
                || !int.TryParse(firstLineStrs.ElementAt(1).ToString(), out int ycoordinate)
                )
                return new ValidationResult(FormatErrorMessage(@"The first line must contain 2 integers, separated by a space, 
                                                        representing the upper-right coordinates of the plateau."));



            for (int i = 1; i < inputLines.Count(); i = i + 2)
            {
                // check it it is 2 ints followed by the orientation 
                var roverInitialStateStr = inputLines.ElementAt(i).Where(x => x != ' ');

                if ((roverInitialStateStr.Count() != 3) ||
                        !int.TryParse(roverInitialStateStr.ElementAt(0).ToString(), out int rover_x_coordinate) ||
                        !int.TryParse(roverInitialStateStr.ElementAt(1).ToString(), out int rover_y_coordinate) ||
                       !new List<char> { 'N', 'E', 'S', 'W' }.Contains(roverInitialStateStr.ElementAt(2))
            )
                    return new ValidationResult(FormatErrorMessage(@"The rover's initial state must contain 2 integers and a character, separated by a space, 
                                                        representing the rover's initial coordinates, and its orientation."));

                var expectedVals = new List<char> { 'M', 'L', 'R' };

                if ((inputLines.Count() <= i + 1) || !inputLines.ElementAt(i + 1).Trim().All(x => expectedVals.Contains(x)))
                    return new ValidationResult(FormatErrorMessage(@"The rover's trajectory can only have the following values 
                                                        'M', 'L', 'R'."));
            }
            return ValidationResult.Success;

        }
    }
}

