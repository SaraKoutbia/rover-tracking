using Xunit;
using RoverTrackingMvc.Models;
using RoverTrackingMvc.Repositories;
using Moq;
using Microsoft.AspNetCore.Mvc;
using RoverTrackingMvc.Controllers;

namespace RoverTracking.Tests.Controllers
{
    public class RoverTrackingControllerTest
    {
        [Fact]
        public void AddModelError_ViewDataStatusEqualsModelError()
        {
            var roverTrackingController = new RoverTrackingController(new Mock<IPlateauRepository>().Object);

            roverTrackingController.ModelState.AddModelError("key", "error message");
            var actionResult = roverTrackingController.FinalPlateauState(new Input());

            Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(actionResult);

            Assert.Equal("ModelError", (actionResult as ViewResult).ViewData["Status"]);
        }
    }
}
