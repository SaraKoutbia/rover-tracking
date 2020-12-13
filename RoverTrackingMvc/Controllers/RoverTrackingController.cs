using Microsoft.AspNetCore.Mvc;
using System;
using RoverTrackingMvc.Models;
using RoverTrackingMvc.Repositories;


namespace RoverTrackingMvc.Controllers
{
    public class RoverTrackingController : Controller
    {
        private readonly IPlateauRepository _plateauRepository;

        public RoverTrackingController(IPlateauRepository plateauRepository)
        {
            _plateauRepository = plateauRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult FinalPlateauState(Input userInput)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var plateau = _plateauRepository.ComputeFinalState(userInput);
                    ViewBag.Plateau = plateau;
                    ViewData["Status"] = "Success";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Server side error occurred", ex.Message.ToString());
                }
            }
            else {
                ViewData["Status"] = "ModelError";
            }
            return View(userInput);
        }
    }
}
