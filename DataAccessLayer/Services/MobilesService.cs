using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class MobilesService : IMobilesService
    {
        private readonly AppDbContext _context;
        public MobilesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mobile>> GetAllAsync()
        {
            var result = await _context.Mobiles
                .Include(x => x.Manufacturer)
                .Include(x => x.Description)
                .OrderByDescending(x => x.MobilePrice)
                .ToListAsync();
            return result;

        }

        public async Task<Mobile> GetByIdAsync(int id)
        {
            var result = await _context.Mobiles
                .Include(x => x.Description)
                .Include(x => x.Manufacturer)
                .FirstOrDefaultAsync(x => x.MobileId == id);
            return result;
        }
    }
}
