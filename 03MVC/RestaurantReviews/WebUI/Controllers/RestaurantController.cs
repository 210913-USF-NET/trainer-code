using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRBL;
using Models;

namespace WebUI.Controllers
{

    public class RestaurantController : Controller
    {
        private IBL _bl;
        public RestaurantController(IBL bl)
        {
            _bl = bl;
        }
        // GET: RestaurantController
        public ActionResult Index()
        {
            List<Restaurant> allResto = _bl.GetAllRestaurants();
            return View(allResto);
        }

        // GET: RestaurantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                //if the data in my form is valid
                if(ModelState.IsValid)
                {
                    _bl.AddRestaurant(restaurant);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
