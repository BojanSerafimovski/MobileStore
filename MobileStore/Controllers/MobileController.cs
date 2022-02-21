using DataAccessLayer.Services;
using DataAccessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Controllers
{
    public class MobileController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMobilesService _service;
        public MobileController(IMobilesService service, AppDbContext context)
        {
            _context = context;
            _service = service;
        }

        // Get all mobiles
        public async Task<IActionResult> Index()
        {
            var allMobiles = await _service.GetAllAsync();
            return View(allMobiles);
        }

        public IActionResult Create()
        {
            ViewBag.Manufacturers = _context.Manufacturers
                .Select(i => new SelectListItem
                {
                    Value = i.ManufacturerId.ToString(),
                    Text = i.ManufacturerName
                }).ToList();
            return View();
        }

        // Post: Add new manufacturer
        [HttpPost]
        public async Task<IActionResult> Create([Bind("MobileName, Description, MobilePrice, ManufactureDate, ManufacturerId, MobileImage, Quantity")] Mobile mobile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Manufacturers = _context.Manufacturers
                    .Select(i => new SelectListItem
                    {
                        Value = i.ManufacturerId.ToString(),
                        Text = i.ManufacturerName
                    }).ToList();
                return View(mobile);
            }
            else
            {
                await _service.AddAsync(mobile);
                return RedirectToAction(nameof(Index));
            }
        }


        // Search bar filtering
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMobiles = await _service.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMobiles
                    .Where(x => x.Manufacturer.ManufacturerName.StartsWith(searchString, StringComparison.CurrentCultureIgnoreCase) || x.MobileName.StartsWith(searchString, StringComparison.CurrentCultureIgnoreCase) || x.MobileName.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                if (filteredResult.Count == 0)
                {
                    return View("EmptyFilter");
                }
                return View("Index", filteredResult);
            }
            return View("Index", allMobiles);
        }

        // Details field
        public async Task<IActionResult> Details(int id)
        {
            var mobileDetail = await _service.GetByIdAsync(id);
            return View(mobileDetail);
        }
    }
}
