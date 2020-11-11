using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatApp.Web.Data;
using ReatApp.Web.Helpers;
using ReatApp.Web.Models;
using RestApp.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReatApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PointsSaleController : Controller
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public PointsSaleController(DataContext context, IBlobHelper blobHelper, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _blobHelper = blobHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.PointSale
                .Include(p => p.Restaurant)
                .Include(p => p.PointSaleImage)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            PointSaleViewModel model = new PointSaleViewModel
            {
                Restaurants = _combosHelper.GetComboRestaurants(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PointSaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PointSale pointSale = await _converterHelper.ToPointSaleAsync(model, true);

                    if (model.ImageFile != null)
                    {
                        Guid imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "products");
                        pointSale.PointSaleImage = new List<PointSaleImage>
                {
                    new PointSaleImage { ImageId = imageId }
                };
                    }

                    _context.Add(pointSale);
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

            model.Restaurants = _combosHelper.GetComboRestaurants();
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PointSale pointSale = await _context.PointSale
                .Include(p => p.Restaurant)
                .Include(p => p.PointSaleImage)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pointSale == null)
            {
                return NotFound();
            }

            PointSaleViewModel model = _converterHelper.ToPointSaleViewModel(pointSale);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PointSaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PointSale pointSale = await _converterHelper.ToPointSaleAsync(model, false);

                    if (model.ImageFile != null)
                    {
                        Guid imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "products");
                        if (pointSale.PointSaleImage == null)
                        {
                            pointSale.PointSaleImage = new List<PointSaleImage>();
                        }

                        pointSale.PointSaleImage.Add(new PointSaleImage { ImageId = imageId });
                    }

                    _context.Update(pointSale);
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

            model.Restaurants = _combosHelper.GetComboRestaurants();
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PointSale pointSale = await _context.PointSale
                .Include(p => p.PointSaleImage)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pointSale == null)
            {
                return NotFound();
            }

            try
            {
                _context.PointSale.Remove(pointSale);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PointSale pointSale = await _context.PointSale
                .Include(c => c.Restaurant)
                .Include(c => c.PointSaleImage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointSale == null)
            {
                return NotFound();
            }

            return View(pointSale);
        }

        public async Task<IActionResult> AddImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PointSale pointSale = await _context.PointSale.FindAsync(id);
            if (pointSale == null)
            {
                return NotFound();
            }

            AddPointSaleImageViewModel model = new AddPointSaleImageViewModel { PointSaleId = pointSale.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage(AddPointSaleImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                PointSale pointSale = await _context.PointSale
                    .Include(p => p.PointSaleImage)
                    .FirstOrDefaultAsync(p => p.Id == model.PointSaleId);
                if (pointSale == null)
                {
                    return NotFound();
                }

                try
                {
                    Guid imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "products");
                    if (pointSale.PointSaleImage == null)
                    {
                        pointSale.PointSaleImage = new List<PointSaleImage>();
                    }

                    pointSale.PointSaleImage.Add(new PointSaleImage { ImageId = imageId });
                    _context.Update(pointSale);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{pointSale.Id}");

                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PointSaleImage pointSaleImage = await _context.PointSaleImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointSaleImage == null)
            {
                return NotFound();
            }

            PointSale pointSale = await _context.PointSale.FirstOrDefaultAsync(p => p.PointSaleImage.FirstOrDefault(pi => pi.Id == pointSaleImage.Id) != null);
            _context.PointSaleImages.Remove(pointSaleImage);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{pointSale.Id}");
        }



    }
}
