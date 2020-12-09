using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RoverTrackingService.Models;

namespace RoverTrackingService.Repositories
{
    public class PlateauRepository : IPlateauRepository
    {
        private Plateau plateau { get; set; } = new Plateau();

        private List<Tuple<Orientation, int>> dic = new List<Tuple<Orientation, int>>();

        public Plateau computeFinalState(input input)
        {
            parseInput(input);
            return this.plateau;
        }

        public void parseInput(input value)
        {
            var strValue = value.inputStr;
            var inputLines = strValue.Split(new[] { Environment.NewLine },
                                           StringSplitOptions.None).Select(l => l.Trim().ToUpper()).Where(l => l != "");

            var firstLineStrs = inputLines.First().Where(x => x != ' ');// .Split("\\s+").Select(str => str.Trim());

            this.plateau.upperRightCoordinates = new Coordinates(int.Parse(firstLineStrs.ElementAt(0).ToString()),
             int.Parse(firstLineStrs.ElementAt(1).ToString()));
            var rovers = this.plateau.Rovers;

            for (int i = 1; i < inputLines.Count(); i = i + 2)
            {
                dic = new List<Tuple<Orientation, int>>();
                var roverInitialStateStr = inputLines.ElementAt(i).Where(x => x != ' ');

                var initialOrientation = (Orientation)Enum.Parse(typeof(Orientation), roverInitialStateStr.ElementAt(2).ToString(), true);
                var trajectory = inputLines.ElementAt(i + 1).Trim();

                var initialCoordinates = new Coordinates(int.Parse(roverInitialStateStr.ElementAt(0).ToString()),
                   int.Parse(roverInitialStateStr.ElementAt(1).ToString()));

                var x_coo = initialCoordinates.x_coordinate;
                var y_coo = initialCoordinates.y_coordinate;

                string pattern = "([LR])";
                string[] substrings = Regex.Split(trajectory, pattern);

                dic.Add(new Tuple<Orientation, int>(initialOrientation, substrings[0].Length));
                for (int k = 1; k < substrings.Length; k++)
                {
                    if ((substrings.ElementAt(k) == "L") || (substrings.ElementAt(k) == "R"))
                    {
                        var lastOrientation = dic.Last().Item1;

                        var orientationAtK = (substrings.ElementAt(k) == "L") ? (Orientation)((((int)lastOrientation - 1) + 4) % 4) :
                            (Orientation)(((int)lastOrientation + 1) % 4);
                        var moveAtK = (k + 1) < (substrings.Length) ? substrings.ElementAt(k + 1).Length : 0;

                        dic.Add(new Tuple<Orientation, int>(orientationAtK, moveAtK));

                    }
                }

                foreach (var entry in dic)
                {
                    switch (entry.Item1)
                    {
                        case Orientation.N:
                            y_coo = y_coo + entry.Item2;
                            break;

                        case Orientation.E:
                            x_coo = x_coo + entry.Item2;
                            break;

                        case Orientation.S:
                            y_coo = y_coo - entry.Item2;
                            break;

                        case Orientation.W:
                            x_coo = x_coo - entry.Item2;
                            break;
                    }
                }

                rovers.Add(new Rover
                {
                    initialCoordinates = new Coordinates(int.Parse(roverInitialStateStr.ElementAt(0).ToString()),
                                  int.Parse(roverInitialStateStr.ElementAt(0).ToString())),

                    initialOrientation = (Orientation)Enum.Parse(typeof(Orientation), roverInitialStateStr.ElementAt(2).ToString(), true),

                    trajectory = inputLines.ElementAt(i + 1).Trim(),
                    finalOrientation = dic.Last().Item1,
                    finalCoordinates = new Coordinates(x_coo, y_coo)
                });
            }
        }
    }
}
