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
        public MobileController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allMobiles = _context.Mobiles
                .Include(x => x.Manufacturer)
                .Include(x => x.Description)
                .OrderByDescending(x => x.MobilePrice)
                .ToList();
            return View(allMobiles);
        }
    }
}
