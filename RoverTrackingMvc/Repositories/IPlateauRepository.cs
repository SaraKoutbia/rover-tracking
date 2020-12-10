using RoverTrackingService.Models;

namespace RoverTrackingService.Repositories
{
    public interface IPlateauRepository
    {
        abstract void ParseInput(Input input);
        public Plateau ComputeFinalState(Input input);
    }
}
