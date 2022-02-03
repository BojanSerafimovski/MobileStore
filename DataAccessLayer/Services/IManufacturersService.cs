using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IManufacturersService
    {
        Task<IEnumerable<Manufacturer>> GetAllAsync();
        Task <Manufacturer> GetByIdAsync(int id);
        Task AddAsync(Manufacturer manufacturer);
        Task<Manufacturer> UpdateAsync(int id, Manufacturer newManufacturer);
        Task DeleteAsync(int id);
    }
}
