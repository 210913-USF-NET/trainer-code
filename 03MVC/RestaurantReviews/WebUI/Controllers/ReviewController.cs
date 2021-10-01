using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using RRBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ReviewController : Controller
    {
        private IBL _bl;

        public ReviewController(IBL bl)
        {
            _bl = bl;
        }

        // GET: ReviewController/5
        /// <summary>
        /// Get all Reviews to a restaurant
        /// </summary>
        /// <param name="id">restaurant Id</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            RestaurantVM resto = new RestaurantVM(_bl.GetOneRestaurantById(id));
            if (resto.Reviews.Count > 0)
            {
                int sum = 0;
                foreach (Review review in resto.Reviews)
                {
                    sum += review.Rating;
                }
                resto.Rating = sum / resto.Reviews.Count;
            }
            return View(resto);
        }

        // GET: ReviewController/Create?RestaurantId=5
        public ActionResult Create(string restaurantId)
        {
            return View(new Review(int.Parse(restaurantId)));
        }

        // POST: ReviewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Review review)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _bl.AddAReview(review);
                    return RedirectToAction(nameof(Index),new {id = review.RestaurantId });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ReviewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReviewController/Edit/5
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

        // GET: ReviewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReviewController/Delete/5
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
