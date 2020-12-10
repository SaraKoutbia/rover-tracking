using RoverTrackingService.Models;

namespace RoverTrackingService.Repositories
{
    public interface IPlateauRepository
    {
        abstract void parseInput(input input);
        public Plateau computeFinalState(input input);
    }
}
