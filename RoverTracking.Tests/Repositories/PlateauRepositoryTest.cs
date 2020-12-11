using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using RoverTrackingMvc.Models;
using RoverTrackingMvc.Repositories;

namespace RoverTracking.Tests
{
    public class InputAndExpectedOutput
    {
        public static IEnumerable<object[]> Data =>
                  new List<object[]>
            {
               new object[]  { @"5 5 
                                1 2 N  
                                LMLMLMLMM  
                                3 3 E   
                                MMRMMRMRRM",

                               new Rover[]{
                                   new Rover{
                                       FinalCoordinates= new Coordinates(1, 3),
                                       FinalOrientation= Orientation.N},
                                   new Rover{
                                       FinalCoordinates= new Coordinates(5, 1),
                                       FinalOrientation= Orientation.E}
                               }
                            },
                new object[]  { @"6 4 
                                  2 3 N    
                                  MLMLMRR   
                                  1 2 E    
                                  MMRMMRM   
                                  3 1 W    
                                  LMMRMMRM",

                               new Rover[]{
                                   new Rover{
                                       FinalCoordinates= new Coordinates(1, 3),
                                       FinalOrientation= Orientation.N},
                                   new Rover{
                                       FinalCoordinates= new Coordinates(2, 0),
                                       FinalOrientation= Orientation.W},
                                   new Rover{
                                       FinalCoordinates= new Coordinates(1, 1),
                                       FinalOrientation= Orientation.N}
                               }
                            },
                new object[]  { @"5 3
                                1 3 N
                                MLMLMRR
                                0 0 E
                                MMRMMRM
                                4 0 W
                                LMMRMMRM",

                               new Rover[]{
                                   new Rover{
                                       FinalCoordinates= new Coordinates(0, 2),
                                       FinalOrientation= Orientation.N},
                                   new Rover{
                                       FinalCoordinates= new Coordinates(1, 0),
                                       FinalOrientation= Orientation.W},
                                   new Rover{
                                       FinalCoordinates= new Coordinates(2, 1),
                                       FinalOrientation= Orientation.N}
                               }
                            }
            };
    }

    public class PlateauRepositoryTest
    {
        [Theory]
        [MemberData(nameof(InputAndExpectedOutput.Data), MemberType = typeof(InputAndExpectedOutput))]
        public void ComputeFinalState_Successful(string inputStr, Rover[] expectedRovers)
        {
            var plateauRegistery = new PlateauRepository(new RectangularPlateau());
            var plateau = plateauRegistery.ComputeFinalState(new Input { InputStr = inputStr });

            for (int i = 0; i < plateau.Rovers.Count; i++)
            {
                var actualRover = plateau.Rovers[i];
                expectedRovers[i].FinalCoordinates.Should().BeEquivalentTo(actualRover.FinalCoordinates);
                expectedRovers[i].FinalOrientation.Should().BeEquivalentTo(actualRover.FinalOrientation);
            }
        }
    }
}
