using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatApp.Web.Data;
using ReatApp.Web.Data.Entities;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetPointsSale()
        {
            List<PointSale> pointsSales = await _context.PointSale
                .Include(c => c.Restaurant)
                .Include(c => c.CatalogueImage)
                .Include(p => p.Qualifications)
                .ToListAsync();
            return Ok(pointsSales);

        }
    }
}
