using Program.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Repository.Common
{

    public interface IBuyerRepository
    {
        Task<List<Buyer>> GetAllBuyersAsync();
        Task<List<Buyer>> GetBuyerAsync(Guid Id);
        Task<bool> AddBuyerAsync(Buyer buyer);
        Task<bool> UpdateBuyerAsync(Guid id, Buyer buyer);
        Task<bool> DeleteBuyerAsync(Guid id);


    }
}
