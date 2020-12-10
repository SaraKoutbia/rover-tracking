namespace RoverTrackingService.Models
{
    public class Coordinates
    {
        public int X_coordinate { get; set; }
        public int Y_coordinate { get; set; }

        public Coordinates(int x_coordinate, int y_coordinate)
        {
            this.X_coordinate = x_coordinate;
            this.Y_coordinate = y_coordinate;
        }
    }
}