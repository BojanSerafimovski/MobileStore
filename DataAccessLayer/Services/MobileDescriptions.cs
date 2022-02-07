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
    public class MobileDescriptions : IMobileDescriptions
    {
        private readonly AppDbContext _context;
        public MobileDescriptions(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MobileDescription description)
        {
            await _context.MobileDescriptions.AddAsync(description);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.MobileDescriptions.FirstOrDefaultAsync(x => x.MobileDescriptionId == id);
            _context.MobileDescriptions.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MobileDescription>> GetAllAsync()
        {
            var result = await _context.MobileDescriptions.ToListAsync();
            return result;
        }

        public async Task<MobileDescription> GetByIdAsync(int id)
        {
            var result = await _context.MobileDescriptions
                .Include(x => x.MobileModel)
                .FirstOrDefaultAsync(x => x.MobileDescriptionId == id);
            return result;
        }

        public async Task<MobileDescription> UpdateAsync(int id, MobileDescription newDescription)
        {
            _context.Update(newDescription);
            await _context.SaveChangesAsync();
            return newDescription;
        }
    }
}
