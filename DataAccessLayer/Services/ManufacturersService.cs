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
    public class ManufacturersService : IManufacturersService
    {
        private readonly AppDbContext _context;

        public ManufacturersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Manufacturer manufacturer)
        {
           await _context.Manufacturers.AddAsync(manufacturer);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Manufacturers.FirstOrDefaultAsync(x => x.ManufacturerId == id);
            _context.Manufacturers.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            var result = await _context.Manufacturers.ToListAsync();
            return result;
        }

        public async Task<Manufacturer> GetByIdAsync(int id)
        {
            var result = await _context.Manufacturers.FirstOrDefaultAsync(x => x.ManufacturerId == id);
            return result;
        }

        public async Task<Manufacturer> UpdateAsync(int id, Manufacturer newManufacturer)
        {
            _context.Update(newManufacturer);
            await _context.SaveChangesAsync();
            return newManufacturer;
        }
    }
}
