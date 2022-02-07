using DataAccessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
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
