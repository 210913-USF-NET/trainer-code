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
        public IActionResult Get(int id)
        {
            Restaurant foundRestaurant = _bl.GetOneRestaurantById(id);
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
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
