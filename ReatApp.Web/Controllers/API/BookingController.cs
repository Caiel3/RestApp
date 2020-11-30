using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatApp.Web.Data;
using ReatApp.Web.Data.Entities;
using ReatApp.Web.Helpers;
using RestApp.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReatApp.Web.Controllers.API
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public BookingController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        [HttpPost]
        public async Task<IActionResult> PostBooking([FromBody] BookingResponse request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                return NotFound("Error001");
            }

            PointSale pointSale = await _context.PointSale.FindAsync(request.pointSale.Id);

            Booking booking = new Booking
            {
                Date = DateTime.UtcNow,
                pointSale = pointSale,
                User = user
            };

            _context.bookings.Add(booking);
            await _context.SaveChangesAsync();
            return Ok(booking);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            List<Booking> bookings = await _context.bookings
                .Include(c => c.User)
                .Include(c => c.pointSale)
                .ThenInclude(c => c.Restaurant)
                .ToListAsync();
            return Ok(bookings);

        }
    }
}