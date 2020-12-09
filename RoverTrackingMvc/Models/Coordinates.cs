namespace RoverTrackingService.Models
{
    public class Coordinates
    {
        public int x_coordinate { get; set; }
        public int y_coordinate { get; set; }

        public Coordinates(int x_coordinate, int y_coordinate)
        {
            this.x_coordinate = x_coordinate;
            this.y_coordinate = y_coordinate;
        }
    }
}