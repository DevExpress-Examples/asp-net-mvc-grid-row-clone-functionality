using e4643.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e4643.Controllers
{
    public class HomeController : Controller
    {
        PersonList list = new PersonList();
        public ActionResult Index()
        {
            return View(list.GetPersons());
        }

        public ActionResult GridViewPartial()
        {
            return PartialView("_GridViewPartial", list.GetPersons());
        }

        public ActionResult CustomGridViewEditingPartial(int key)
        {
            ViewData["key"] = key;
            return PartialView("_GridViewPartial", list.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew(Person person)
        {
            if (ModelState.IsValid)
                list.AddPerson(person);
            return PartialView("_GridViewPartial", list.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate(Person personInfo)
        {
            if (ModelState.IsValid)
                list.UpdatePerson(personInfo);
            return PartialView("_GridViewPartial", list.GetPersons());
        }

        public ActionResult EditingDelete(int personId)
        {
            list.DeletePerson(personId);
            return PartialView("_GridViewPartial", list.GetPersons());
        }
    }
}