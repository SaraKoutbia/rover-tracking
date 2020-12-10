using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RoverTrackingMvc.CustomAttributes
{
    public class ValidInputFormatAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var inputStr = value.ToString();
            var inputLines = inputStr.Split(new[] { Environment.NewLine },
                                           StringSplitOptions.None).Select(l => l.Trim().ToUpper()).Where(l => l != "");

            //validate the first line 
            var firstLineChars = inputLines.First().Where(x => x != ' ');
            if (firstLineChars.Count() != 2
                || !int.TryParse(firstLineChars.ElementAt(0).ToString(), out int xcoordinate)
                || !int.TryParse(firstLineChars.ElementAt(1).ToString(), out int ycoordinate)
                )
                return new ValidationResult(ErrorMessage = @" The first line must contain two integers, separated by a space, 
                                                        representing the upper-right coordinates of the plateau.");


            //validate the rover's initial position: check it is two integers followed by the orientation 
            for (int i = 1; i < inputLines.Count(); i += 2)
            {
                var roverInitialStateChars = inputLines.ElementAt(i).Where(x => x != ' ');
                if ((roverInitialStateChars.Count() != 3) ||
                        !int.TryParse(roverInitialStateChars.ElementAt(0).ToString(), out int rover_x_coordinate) ||
                        !int.TryParse(roverInitialStateChars.ElementAt(1).ToString(), out int rover_y_coordinate) ||
                       !new List<char> { 'N', 'E', 'S', 'W' }.Contains(roverInitialStateChars.ElementAt(2))
            )
                    return new ValidationResult(ErrorMessage = @"The rover's initial state must contain two integers and a character, separated by a space, 
                                                        representing the rover's initial coordinates and its orientation.");

                //validate the rover's trajectory is valid: It should only contain the following values 'M', 'L', 'R'
                var expectedVals = new List<char> { 'M', 'L', 'R' };
                if ((inputLines.Count() <= i + 1) || !inputLines.ElementAt(i + 1).Trim().All(x => expectedVals.Contains(x)))
                    return new ValidationResult(ErrorMessage = @"The rover's trajectory can only take the following values 
                                                        'M', 'L', 'R'.");
            }
            return ValidationResult.Success;
        }
    }
}

