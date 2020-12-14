using System.Collections.Generic;
using Xunit;
using RoverTrackingMvc.CustomAttributes;

namespace RoverTracking.Tests.CustomAttributes
{

    public class InvalidInputString
    {
        //invalid inputs 
        public static IEnumerable<object[]> Data =>
               new List<object[]>
         {
               new object[]  { @"5 5 6
                                 1 2 N  
                                 LMLMLMLMM  
                                 3 3 E   
                                 MMRMMRMRRM"
                            },
               new object[]  { @"6 4 
                                 2 3 NN    
                                 MLMLMRR   
                                 1 2 E    
                                 MMRMMRM   
                                 3 1 W    
                                 LMMRMMRM"
                            },
               new object[]  { @"5 3
                                1 3 N
                                MLMLSMRR
                                0 0 E
                                MMRMMRM
                                4 0 W
                                LMMRMMRM"
                            },
               new object[]  { @"5 5 
                                1 7 N  
                                LMLMLMLMM  
                                3 3 E   
                                MMRMMRMRRM"
                            }
         };
    }

    public class ValidInputFormatAttributeTest
    {
        [Theory]
        [MemberData(nameof(InvalidInputString.Data), MemberType = typeof(InvalidInputString))]
        public void IsValid_false(string inputStr)
        {
            var customValidation = new ValidInputFormatAttribute();

            var result = customValidation.IsValid(inputStr);

            Assert.False(result);
        }
    }
}
