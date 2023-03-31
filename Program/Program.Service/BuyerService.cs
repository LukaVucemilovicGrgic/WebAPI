using Program.Common;
using Program.Model;
using Program.Repository;
using Program.Repository.Common;
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
        protected IBuyerRepository BuyerRepository { get; set; }
        public BuyerService(IBuyerRepository buyerRrepository) 
        {
            BuyerRepository = buyerRrepository;
        }
        public async Task<List<Buyer>> GetAllBuyersAsync()
        {
          //  BuyerRepository repository = new BuyerRepository();
            List<Buyer> buyers = await BuyerRepository.GetAllBuyersAsync();
            return buyers;
        }
        public async Task<List<Buyer>> GetBuyerAsync(Guid Id)
        {
          //  BuyerRepository repository = new BuyerRepository();
            List<Buyer> buyer = await BuyerRepository.GetBuyerAsync(Id);
            return buyer;
        }
        public async Task<bool> AddBuyerAsync(Buyer buyer)
        {
          //  BuyerRepository repository = new BuyerRepository();
            bool newBuyer = await BuyerRepository.AddBuyerAsync(buyer);
            return true;
        }
        public async Task<bool> UpdateBuyerAsync(Guid id, Buyer buyer)
        {
          //  BuyerRepository repository = new BuyerRepository();
            bool newBuyer = await BuyerRepository.AddBuyerAsync(buyer);
            return true;
        }
        public async Task<bool> DeleteBuyerAsync(Guid id)
        {
          //  BuyerRepository repository = new BuyerRepository();
            bool newBuyer = await BuyerRepository.DeleteBuyerAsync(id);
            return true;
        }
        public async Task<List<Buyer>> GetPagingSortingFilteringAsync(Paging paging, Sorting sorting, Filtering filtering)         //dodaj
        {
            BuyerRepository repository = new BuyerRepository();
            List<Buyer> buyers = await repository.GetPagingSortingFilteringAsync(paging, sorting, filtering);      //dodaj
            return buyers;
        }
    }
}
