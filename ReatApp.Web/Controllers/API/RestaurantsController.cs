using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatApp.Web.Data;

namespace ReatApp.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly DataContext _context;

        public RestaurantsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRestaurants()
        {
            return Ok(_context.Restaurants);
        }
    }

}
