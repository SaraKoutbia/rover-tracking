using System.Collections.Generic;

namespace RoverTrackingMvc.Models
{
    public class RectangularPlateau : IPlateau
    {
        public Coordinates LowerLeftCoordinates { get; } = new Coordinates(0, 0);

        public Coordinates UpperRightCoordinates { get; set; } = new Coordinates(0, 0);

        public List<Rover> Rovers { get; set; } = new List<Rover>();

    }
}