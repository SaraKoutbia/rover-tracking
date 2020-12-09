using System.Collections.Generic;


namespace RoverTrackingService.Models
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
        public Coordinates initialCoordinates { get; set; }
        public Orientation initialOrientation { get; set; }
        public Coordinates finalCoordinates { get; set; } = new Coordinates(0, 0);
        public Orientation finalOrientation { get; set; }
        public string trajectory { get; set; }
        public Dictionary<Orientation, int> dic { get; set; }

    }
}