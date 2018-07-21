using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityCountryApp.Models;
using CityCountryApp.Repository;

namespace CityCountryApp.Controllers
{
    public class CountryController : Controller
    {
       CountryRepository countryRepository= new CountryRepository();
        public ActionResult Index()
        {
            return View(countryRepository.GetAllCountry());
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View(countryRepository.GetAllCountry().Find(x=>x.Id==id));
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                if (countryRepository.AddCountry(country))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            return View(countryRepository.GetAllCountry().Find(x => x.Id == id));
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            try
            {
                countryRepository.UpdateCountry(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            return View(countryRepository.GetAllCountry().Find(x => x.Id == id));
        }

        // POST: Country/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                countryRepository.DeleteCountry(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
