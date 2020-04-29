using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_med_booty.models;

namespace mvc_med_booty.controllers
{
    public class PersonController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PersonController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index()
        {
            return View(_peopleService.GetPeople());
        }

        public IActionResult Details(int id)
        {
            People people = _peopleService.FindById(id);
            if (people == null)
            {
                return RedirectToAction("Index");
            }
            return View(people);
        }

        public IActionResult Create()
        {
            
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonViewModel person)//need to have zero constructor for this binding to work
        {
            if (ModelState.IsValid)
            {
                _peopleService.Create(person);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(person);
            }
        }

        public IActionResult Edit()
        {
            return View();
        }

        
    }
}