using System.Collections.Generic;

namespace RoverTrackingMvc.Models
{
    public interface IPlateau
    {
        public Coordinates LowerLeftCoordinates { get; }

        public Coordinates UpperRightCoordinates { get; set; }

        public List<Rover> Rovers { get; set; }
    }
}
