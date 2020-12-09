using System.Collections.Generic;

namespace RoverTrackingService.Models
{
    public class Plateau
    {
        Coordinates lowerLeftCoordinates { get; } = new Coordinates(0, 0);

        public Coordinates upperRightCoordinates { get; set; } = new Coordinates(0, 0);

        public List<Rover> Rovers { get; set; } = new List<Rover>();

    }
}