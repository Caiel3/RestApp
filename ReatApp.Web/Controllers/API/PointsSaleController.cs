using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatApp.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReatApp.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointsSaleController : ControllerBase
    {
        private readonly DataContext _context; 
        
        public PointsSaleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPointsSale()
        {
            return Ok(_context.PointSale
                .Include(c => c.Restaurant)
                .Include(c => c.CatalogueImage));
        }
    }
}
