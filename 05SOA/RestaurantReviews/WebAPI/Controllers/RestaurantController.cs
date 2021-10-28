using Microsoft.AspNetCore.Mvc;
using Models;
using RRBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IBL _bl;

        public RestaurantController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<RestaurantController>
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _bl.GetAllRestaurants();
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Restaurant foundRestaurant = await _bl.GetOneRestaurantByIdAsync(id);
            if (foundRestaurant != null)
            {
                return Ok(foundRestaurant);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Restaurant newRestaurant)
        {
            Restaurant addedRestaurant = await _bl.AddRestaurantAsync(newRestaurant);
            return Created("api/[controller]", addedRestaurant);
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Restaurant newRestaurant)
        {
            //Shrek 5ever
            Restaurant updatedRestaurant = await _bl.UpdateRestaurantAsync(newRestaurant);
            return Ok(updatedRestaurant);
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            //!Fast Just Furious
            await _bl.DeleteRestaurantAsync(id);
        }
    }
}
