using RoverTrackingMvc.Models;

namespace RoverTrackingMvc.Repositories
{
    public interface IPlateauRepository
    {
        abstract void ParseInput(Input input);
        public IPlateau ComputeFinalState(Input input);
    }
}
