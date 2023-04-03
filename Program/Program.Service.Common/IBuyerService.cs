using Program.Common;
using Program.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Service.Common
{
    public interface IBuyerService
    {
        Task<List<Buyer>> GetAllBuyersAsync();
        Task<Buyer> GetBuyerAsync(Guid Id);
        Task<bool> AddBuyerAsync(Buyer buyer);
        Task<bool> UpdateBuyerAsync(Guid id, Buyer buyer);
        Task<bool> DeleteBuyerAsync(Guid id);
        Task<List<Buyer>> GetPagingSortingFilteringAsync(Paging paging, Sorting sorting, Filtering filtering);           //dodaj filter i sort kad budes radio
    }
}
