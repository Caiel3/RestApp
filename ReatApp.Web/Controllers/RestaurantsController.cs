using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatApp.Web.Data;
using ReatApp.Web.Data.Entities;
using ReatApp.Web.Helpers;
using ReatApp.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReatApp.Web.Controllers
{
    [Authorize(Roles = "Admin, RestaurantAdmin")]
    public class RestaurantsController : Controller
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IUserHelper _userHelper;

        public RestaurantsController(
            IUserHelper userHelper, DataContext context, IBlobHelper blobHelper, IConverterHelper converterHelper)
        {
            _userHelper = userHelper;
            _context = context;
            _blobHelper = blobHelper;
            _converterHelper = converterHelper;
        }

        //public async Task<IActionResult> Index()
        //{

        //    //User user = await _userHelper.GetUserAsync(User.Identities[0].Name);

        //    string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        //    User user = await _userHelper.GetUserAsync(email);
        //    if (user == null)
        //    {
        //        return NotFound("Error001");
        //    }

        //    return View(await _context.Restaurants
        //        .Include(u => u.User)
        //        .Where(d => d.User == user
        //                //_context.Users
        //                //.where(u => u.User == User.Claims)
        //                //d.User == User.Identities
        //                )
        //        .ToListAsync());
        //}

        public async Task<IActionResult> Index()
        {

            string email = User.Identity.Name;

            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                return NotFound("Error001");
            }
            if (user.UserType.ToString() == "Admin")
            {
                return View(await _context.Restaurants
                                .ToListAsync());
            }
            return View(await _context.Restaurants
                .Where(d => d.UserId == user.Id)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            RestaurantViewModel model = new RestaurantViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {

                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "categories");
                }

                string email = User.Identity.Name;
                User user = await _userHelper.GetUserAsync(email);
                if (user == null)
                {
                    return NotFound("Error001");
                }

                model.UserId = user.Id;

                try
                {
                    Restaurant restaurant = _converterHelper.ToRestaurant(model, imageId, true);
                    _context.Add(restaurant);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            RestaurantViewModel model = _converterHelper.ToRestaurantViewModel(restaurant);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = model.ImageId;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "categories");
                }

                try
                {
                    Restaurant restaurant = _converterHelper.ToRestaurant(model, imageId, false);
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            try
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }


    }



}
