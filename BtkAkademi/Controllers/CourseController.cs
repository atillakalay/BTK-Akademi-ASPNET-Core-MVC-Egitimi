using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;


namespace BtkAkademi.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Candidate candidate)
        {

            if (Repository.Applications.Any(a => a.Email.Equals(candidate.Email)))
            {
                ModelState.AddModelError("", "There is aleready an apptication for you.");
            }

            if (ModelState.IsValid)
            {
                Repository.Add(candidate);
                return View("Feedback", candidate);
            }
            return View();
        }
    }
}