using Microsoft.AspNetCore.Mvc;
using System;
using RoverTrackingService.Models;
using RoverTrackingService.Repositories;



namespace RoverTrackingMvc.Controllers
{
    public class RoverTrackingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult FinalPlateauState(input userInput)
        {
            var s = userInput.inputStr;
            var plateau = new Plateau();


            if (ModelState.IsValid)
            {
                try
                {
                    var plateauRegistery = new PlateauRepository();
                    plateau = plateauRegistery.computeFinalState(userInput);
                    ViewBag.Plateau = plateau;
                    ViewData["Success"] = "Success";                    
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Server side error occurred", ex.Message.ToString());
                }
            }
            return View(userInput);
        }
    }
}
