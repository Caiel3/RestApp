using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatApp.Web.Data;
using ReatApp.Web.Data.Entities;
using ReatApp.Web.Helpers;
using RestApp.Common.Request;
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
    public class QualificationsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public QualificationsController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        [HttpPost]
        public async Task<IActionResult> PostQualification([FromBody] QualificationRequest request)
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

            PointSale pointSale = await _context.PointSale
                .Include(p => p.Qualifications)
                .FirstOrDefaultAsync(p => p.Id == request.PointSaleId);
            if (pointSale == null)
            {
                return NotFound("Error002");
            }

            if (pointSale.Qualifications == null)
            {
                pointSale.Qualifications = new List<Qualification>();
            }

            pointSale.Qualifications.Add(new Qualification
            {
                Date = DateTime.UtcNow,
                PointSale = pointSale,
                Remarks = request.Remarks,
                Score = request.Score,
                User = user
            });

            _context.PointSale.Update(pointSale);
            await _context.SaveChangesAsync();
            return Ok(pointSale);
        }
    }

}
