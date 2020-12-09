using RoverTrackingService.Models;

namespace RoverTrackingService.Repositories
{
    interface IPlateauRepository
    {
        abstract void parseInput(input input);
        public Plateau computeFinalState(input input);
    }
}
