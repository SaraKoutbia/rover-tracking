using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RoverTrackingMvc.CustomAttributes
{
    public class ValidInputFormatAttribute : ValidationAttribute
    {
        public int LowerRight_Xcoordinates { get; set; }
        public int LowerRight_Ycoordinates { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var inputStr = value.ToString();
            var inputLines = inputStr.Split(new[] { Environment.NewLine },
                                           StringSplitOptions.None).Select(l => l.Trim().ToUpper()).Where(l => l != "");

            //validate the first line 
            var firstLineStrings = inputLines.First().Split().Where(str => str != "");
            if (firstLineStrings.Count() != 2
                || !int.TryParse(firstLineStrings.ElementAt(0).ToString(), out int xcoordinate)
                || !int.TryParse(firstLineStrings.ElementAt(1).ToString(), out int ycoordinate)
                )
                return new ValidationResult(ErrorMessage = @" The first line must contain two integers, separated by a space, 
                                                        representing the upper-right coordinates of the plateau.");


            //validate the rover's initial position: check it is two integers followed by the orientation 
            for (int i = 1; i < inputLines.Count(); i += 2)
            {
                var roverInitialStateStrings = inputLines.ElementAt(i).Split().Where(str => str != "");
                if ((roverInitialStateStrings.Count() != 3) ||
                        !int.TryParse(roverInitialStateStrings.ElementAt(0).ToString(), out int rover_x_coordinate) ||
                        !int.TryParse(roverInitialStateStrings.ElementAt(1).ToString(), out int rover_y_coordinate) ||
                       !new List<char> { 'N', 'E', 'S', 'W' }.Select(x => x.ToString()).Contains(roverInitialStateStrings.ElementAt(2))
            )
                    return new ValidationResult(ErrorMessage = @"The rover's initial state must contain two integers and a character, separated by a space, 
                                                        representing the rover's initial coordinates and its orientation.");


                var PlateauUpperLeft_Xcoordinate = int.Parse(firstLineStrings.ElementAt(0));
                var PlateauUpperLeft_Ycoordinate = int.Parse(firstLineStrings.ElementAt(1));
                var roverInitial_Xcoordinate = int.Parse(roverInitialStateStrings.ElementAt(0));
                var roverInitial_Ycoordinate = int.Parse(roverInitialStateStrings.ElementAt(1));

                if ((roverInitial_Xcoordinate > PlateauUpperLeft_Xcoordinate)
                    || (roverInitial_Ycoordinate > PlateauUpperLeft_Ycoordinate)
                    || (roverInitial_Xcoordinate < LowerRight_Xcoordinates)
                    || (roverInitial_Ycoordinate < LowerRight_Ycoordinates))
                {
                    return new ValidationResult(ErrorMessage = String.Format(@"The rover's must be within the plateau delimitted by:                                              
                                   ({0},{0}), ({1},{0}), ({0},{2}),({1},{2}) )", 0, PlateauUpperLeft_Xcoordinate, PlateauUpperLeft_Ycoordinate));
                }

                //validate the rover's trajectory is valid: It should only contain the following values 'M', 'L', 'R'
                var expectedVals = new List<char> { 'M', 'L', 'R' };
                if ((inputLines.Count() <= i + 1) || !inputLines.ElementAt(i + 1).All(x => expectedVals.Contains(x)))
                    return new ValidationResult(ErrorMessage = @"The rover's trajectory can only take the following values 
                                                        'M', 'L', 'R'.");
            }
            return ValidationResult.Success;
        }
    }
}

