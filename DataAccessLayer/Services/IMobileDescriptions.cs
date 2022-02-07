using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IMobileDescriptions
    {
        Task<IEnumerable<MobileDescription>> GetAllAsync();
        Task<MobileDescription> GetByIdAsync(int id);
        Task AddAsync(MobileDescription description);
        Task<MobileDescription> UpdateAsync(int id, MobileDescription newDescription);
        Task DeleteAsync(int id);
    }
}
