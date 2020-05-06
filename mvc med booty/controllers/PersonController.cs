using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_med_booty.models;
using mvc_med_booty.models.Services;

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
            return View(_peopleService.GetPerson());
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

        public IActionResult Edit(int id)
        {
            PersonViewModel person = new PersonViewModel(_peopleService.FindById(id));
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = id;
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PersonViewModel person)
        {

            if (ModelState.IsValid)
            {
                _peopleService.Update(id, person);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.PersonId = id;
                return View(person);
            }

        }

        public ActionResult Delete(int id)
        {

            _peopleService.Remove(id);

            return RedirectToAction("Index");
        }

    }
}