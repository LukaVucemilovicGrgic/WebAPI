using Program.Model;
using Program.Repository;
using Program.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Service
{
  public class BuyerService : IBuyerService
    {
        public async Task<List<Buyer>> GetAllBuyersAsync()
        {
            BuyerRepository repository = new BuyerRepository();
            List<Buyer> buyers = await repository.GetAllBuyersAsync();
            return buyers;
        }
        public async Task<List<Buyer>> GetBuyerAsync(Guid Id)
        {
            BuyerRepository repository = new BuyerRepository();
            List<Buyer> buyer = await repository.GetBuyerAsync(Id);
            return buyer;
        }
        public async Task<bool> AddBuyerAsync(Buyer buyer)
        {
            BuyerRepository repository = new BuyerRepository();
            bool newBuyer = await repository.AddBuyerAsync(buyer);
            return true;
        }
        public async Task<bool> UpdateBuyerAsync(Guid id, Buyer buyer)
        {
            BuyerRepository repository = new BuyerRepository();
            bool newBuyer = await repository.AddBuyerAsync(buyer);
            return true;
        }
        public async Task<bool> DeleteBuyerAsync(Guid id)
        {
            BuyerRepository repository = new BuyerRepository();
            bool newBuyer = await repository.DeleteBuyerAsync(id);
            return true;
        }
    }
}
