using System;
using System.Collections.Generic;


namespace RoverTrackingMvc.Models
{

    public enum Orientation
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }

    public class Rover
    {
        public Coordinates InitialCoordinates { get; set; }
        public Orientation InitialOrientation { get; set; }
        public Coordinates FinalCoordinates { get; set; } = new Coordinates(0, 0);
        public Orientation FinalOrientation { get; set; }
        public string Trajectory { get; set; }
        public List<Tuple<Orientation, int>> TrajectoryBreakdown { get; set; }= new List<Tuple<Orientation, int>>();

    }
}