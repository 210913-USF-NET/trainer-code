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
    public class ReviewController : ControllerBase
    {
        private IBL _bl;

        public ReviewController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<ReviewController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //Team Carlos
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Review foundReview = _bl.GetOneReviewById(id);
            if (foundReview != null)
            {
                return Ok(foundReview);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<ReviewController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //Team Garlic
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
