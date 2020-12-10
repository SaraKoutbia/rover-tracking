using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RoverTrackingMvc.Models;

namespace RoverTrackingMvc.Repositories
{
    public class PlateauRepository : IPlateauRepository
    {

        private readonly IPlateau _rectangularPlateau;

        public PlateauRepository(IPlateau plateau)
        {
            _rectangularPlateau = plateau;
        }


        public IPlateau ComputeFinalState(Input input)
        {
            ParseInput(input);
            return this._rectangularPlateau;
        }

        public void ParseInput(Input value)
        {
            var strValue = value.InputStr;
            var inputLines = strValue.Split(new[] { Environment.NewLine },
                                           StringSplitOptions.None).Select(l => l.Trim().ToUpper()).Where(l => l != "");

            var firstLineStrs = inputLines.First().Where(x => x != ' ');// .Split("\\s+").Select(str => str.Trim());

            this._rectangularPlateau.UpperRightCoordinates = new Coordinates(int.Parse(firstLineStrs.ElementAt(0).ToString()),
             int.Parse(firstLineStrs.ElementAt(1).ToString()));
            var rovers = this._rectangularPlateau.Rovers;

            for (int i = 1; i < inputLines.Count(); i = i + 2)
            {
                var dic = new List<Tuple<Orientation, int>>();
                var roverInitialStateStr = inputLines.ElementAt(i).Where(x => x != ' ');

                var initialOrientation = (Orientation)Enum.Parse(typeof(Orientation), roverInitialStateStr.ElementAt(2).ToString(), true);
                var trajectory = inputLines.ElementAt(i + 1).Trim();

                var initialCoordinates = new Coordinates(int.Parse(roverInitialStateStr.ElementAt(0).ToString()),
                   int.Parse(roverInitialStateStr.ElementAt(1).ToString()));

                var x_coo = initialCoordinates.X_coordinate;
                var y_coo = initialCoordinates.Y_coordinate;

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
                    InitialCoordinates = new Coordinates(int.Parse(roverInitialStateStr.ElementAt(0).ToString()),
                                  int.Parse(roverInitialStateStr.ElementAt(0).ToString())),

                    InitialOrientation = (Orientation)Enum.Parse(typeof(Orientation), roverInitialStateStr.ElementAt(2).ToString(), true),

                    Trajectory = inputLines.ElementAt(i + 1).Trim(),
                    FinalOrientation = dic.Last().Item1,
                    FinalCoordinates = new Coordinates(x_coo, y_coo),
                    TrajectoryBreakdown = dic
                });
            }
        }
    }
}
