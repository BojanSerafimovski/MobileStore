using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly AppDbContext _context;

        public ManufacturerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allManufacturers = await _context.Manufacturers.ToListAsync();
            return View(allManufacturers);
        }
    }
}
