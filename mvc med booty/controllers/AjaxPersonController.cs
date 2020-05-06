using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_med_booty.models;
using mvc_med_booty.models.Services;

namespace mvc_med_booty.controllers
{
    public class AjaxPersonController : Controller
    {

        private readonly IPeopleService _personService;

        public AjaxPersonController(IPeopleService personService)
        {
            _personService = personService;
        }

        public IActionResult SPA()
        {
            return View(_personService.GetPeople());
        }

        // GET
        public ActionResult Delete(int id)
        {

            if (_personService.Remove(id))
            {
                return Content("was deleted");
            }
            else
            {
                return NotFound();
            }


        }

        [HttpPost]
        public ActionResult Create(PersonViewModel person)//need to have zero constructor for this binding to work
        {
            if (ModelState.IsValid)
            {
                People createdPeople = _personService.Create(person);

                return PartialView("_drinkPartial", createdPeople);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
