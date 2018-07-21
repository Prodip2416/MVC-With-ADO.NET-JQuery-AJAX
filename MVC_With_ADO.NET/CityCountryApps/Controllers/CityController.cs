using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityCountryApp.Models;
using CityCountryApp.Repository;

namespace CityCountryApp.Controllers
{
    public class CityController : Controller
    {
       CityRepository cityRepository = new CityRepository();
       CountryRepository countryRepository= new CountryRepository();
        public ActionResult Index()
        {
            return View(cityRepository.GetAllCityDetails());
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View(cityRepository.GetAllCityDetails().Find(x=>x.Id==id));
        }

        // GET: City/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(countryRepository.GetAllCountry(),"id","name");
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(City city)
        {
            try
            {
                ViewBag.CountryId = new SelectList(countryRepository.GetAllCountry(), "id", "name");
                if (cityRepository.AddCity(city))
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

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            int Countryid = cityRepository.GetCountryId(id);
            ViewBag.CountryId = new SelectList(countryRepository.GetAllCountry(), "id", "name",Countryid);
            return View(cityRepository.GetAllCityDetails().Find(x => x.Id == id));
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(City city)
        {
            try
            {
                ViewBag.CountryId = new SelectList(countryRepository.GetAllCountry(), "id", "name");
                cityRepository.UpdateCity(city);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            return View(cityRepository.GetAllCityDetails().Find(x => x.Id == id));
        }

        // POST: City/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                cityRepository.DeleteCity(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
