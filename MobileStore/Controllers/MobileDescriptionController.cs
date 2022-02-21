using DataAccessLayer.Data;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = UserRoles.Admin)]
    public class MobileDescriptionController : Controller
    {
        private readonly IMobileDescriptions _service;
        private readonly AppDbContext _context;

        public MobileDescriptionController(IMobileDescriptions service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        // Get: all
        public async Task <IActionResult> Index()
        {
            var allDescriptions = await _context.Mobiles.Include(x => x.Description).ToListAsync();
            return View(allDescriptions);
        }

        // Get: Description/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var descriptionDetails = await _service.GetByIdAsync(id);

            if (descriptionDetails == null)
            {
                return View("NotFound");
            }
            return View(descriptionDetails);
        }

        // Get: Description/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var descriptionDetails = await _service.GetByIdAsync(id);
            if (descriptionDetails == null)
            {
                return View("NotFound");
            }
            return View(descriptionDetails);
        }

        // Post: Add new manufacturer
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("MobileDescriptionId, MobileName, ManufactureDate, Description")] MobileDescription manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return View(manufacturer);
            }
            await _service.UpdateAsync(id, manufacturer);
            return RedirectToAction(nameof(Index));
        }
    }
}
