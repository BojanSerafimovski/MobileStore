using DataAccessLayer.Models;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IMobilesService
    {
        Task AddAsync(Mobile mobile);
        Task<IEnumerable<Mobile>> GetAllAsync();
        Task<Mobile> GetByIdAsync(int id);
        Task UpdateQuantity(List<ShoppingCartItem> shoppingCartItems);
    }
}
