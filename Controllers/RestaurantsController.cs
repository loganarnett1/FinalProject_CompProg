using FinalProject_CompProg.Data;
using FinalProject_CompProg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProject_CompProg.Interfaces;

namespace FinalProject_CompProg.Controllers
{
    [ApiController]
    [Route("Restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private readonly ILogger<RestaurantsController> _logger;
        private readonly IRestaurantsContextDAO _context;


        public RestaurantsController(ILogger<RestaurantsController> logger, IRestaurantsContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return OK(_context.GetAllRestaurants());    
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveRestaurantById(id);
            if(result == null)
            {
                return NotFound(id);
            }
            if(result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Restaurant restaurant)
        {
            var result = _context.UpdateRestaurant(restaurant);
            if(result == null)
            {
                return NotFound(restaurant.id);
            }
            if(result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Restaurant restaurant)
        {
            var result = _context.Add(restaurant);
            if(result == null)
            {
                return StatusCode(500, "Restaurant with same ID already exists");
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }








    }
}
