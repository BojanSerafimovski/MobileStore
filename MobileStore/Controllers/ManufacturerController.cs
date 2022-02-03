using DataAccessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturersService _service;

        public ManufacturerController(IManufacturersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allManufacturers = await _service.GetAllAsync();
            return View(allManufacturers);
        }

        // Get: Manufacturer/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post: Add new manufacturer
        [HttpPost]
        public async Task<IActionResult> Create([Bind("PictureUrl, ManufacturerName, ManufacturerBiography")]Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return View(manufacturer);
            }
            else
            {
                await _service.AddAsync(manufacturer);
                return RedirectToAction(nameof(Index));
            }
        }

        // Get: Manufacturer/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);

            if(manufacturerDetails == null)
            {
                return View("NotFound");
            }
            return View(manufacturerDetails);
        }

        // Get: Manufacturer/Edit
        public async Task <IActionResult> Edit(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null)
            {
                return View("NotFound");
            }
            return View(manufacturerDetails);
        }

        // Post: Add new manufacturer
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ManufacturerId, PictureUrl, ManufacturerName, ManufacturerBiography")] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return View(manufacturer);
            }
            await _service.UpdateAsync(id, manufacturer);
            return RedirectToAction(nameof(Index));
        }

        // Get: Manufacturer/Delete/id
        public async Task <IActionResult> Delete(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if(manufacturerDetails == null)
            {
                return View("NotFound");
            }
            return View(manufacturerDetails);
        }

        // Post: Delete a manufacturer
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
