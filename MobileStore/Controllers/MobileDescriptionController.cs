using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Controllers
{
    public class MobileDescriptionController : Controller
    {
        private readonly AppDbContext _context;

        public MobileDescriptionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            var allDescriptions = await _context.Mobiles.Include(x => x.Description).ToListAsync();
            return View(allDescriptions);
        }
    }
}
