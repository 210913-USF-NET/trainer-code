using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRBL;
using Models;
using WebUI.Models;

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
            List<RestaurantVM> allResto = _bl.GetAllRestaurants()
                                              .Select(r => new RestaurantVM(r)).ToList();
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
        public ActionResult Create(RestaurantVM restaurant)
        {
            try
            {
                //if the data in my form is valid
                if(ModelState.IsValid)
                {
                    _bl.AddRestaurant(restaurant.ToModel());
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new RestaurantVM(_bl.GetOneRestaurantById(id)));
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantVM restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.UpdateRestaurant(restaurant.ToModel());
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new RestaurantVM(_bl.GetOneRestaurantById(id)));
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _bl.DeleteRestaurant(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
