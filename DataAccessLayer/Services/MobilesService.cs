using DataAccessLayer.Models;
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

        public async Task AddAsync(Mobile mobile)
        {
            await _context.Mobiles.AddAsync(mobile);
            await _context.SaveChangesAsync();
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

        public async Task UpdateQuantity(List<ShoppingCartItem> shoppingCartItems)
        {
            foreach (var item in shoppingCartItems)
            {
                var result = await _context.Mobiles.FirstOrDefaultAsync(x => x.MobileId == item.Mobile.MobileId);
                result.Quantity -= item.Amount;
                await _context.SaveChangesAsync();
            }
        }
    }
}
