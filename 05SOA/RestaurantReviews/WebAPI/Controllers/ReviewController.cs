using Microsoft.AspNetCore.Mvc;
using Models;
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
        /// <summary>
        /// Retrieve all reviews from the database
        /// </summary>
        /// <returns>list of reviews (perhaps in actionresult?)</returns>
        // GET: api/<ReviewController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //Team Carlos
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Retrieve reviews by restaurant Id
        /// </summary>
        /// <param name="id">Id of restaurant to fetch the review for</param>
        /// <returns>List of reviews for that particular restaurant</returns>
        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //using System.Helpme!
            return "value";
        }

        /// <summary>
        /// Creates a new review
        /// </summary>
        /// <param name="reviewToAdd">A review object to add</param>
        /// <returns>added review object</returns>
        // POST api/<ReviewController>
        [HttpPost]
        public void Post([FromBody] Review reviewToAdd)
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
