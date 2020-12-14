using Microsoft.AspNetCore.Mvc;
using System;
using RoverTrackingMvc.Models;
using RoverTrackingMvc.Repositories;
using System.Diagnostics;


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

            try
            {
                if (ModelState.IsValid)
                {
                    var plateau = _plateauRepository.ComputeFinalState(userInput);
                    ViewBag.Plateau = plateau;
                    ViewData["Status"] = "Success";
                }
                else
                {
                    ViewData["Status"] = "ModelError";
                }

                return View(userInput);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("Server side error occurred", ex.Message.ToString());
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
