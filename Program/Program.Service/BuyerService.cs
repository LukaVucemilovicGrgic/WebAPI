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
            List<Buyer> buyers = await BuyerRepository.GetAllBuyersAsync();
            return buyers;
        }
        public async Task<Buyer> GetBuyerAsync(Guid Id)
        {
            Buyer buyer = await BuyerRepository.GetBuyerAsync(Id);
            return buyer;
        }
        public async Task<bool> AddBuyerAsync(Buyer buyer)
        {
            bool isSuccessfull = await BuyerRepository.AddBuyerAsync(buyer);
            return isSuccessfull;
        }
        public async Task<bool> UpdateBuyerAsync(Guid id, Buyer buyer)
        {
            Buyer changeBuyer = await BuyerRepository.GetBuyerAsync(id);
            if(changeBuyer == null)
            {
                return false;
            }
            Buyer buyertoUpadate = new Buyer
            {
                Id = id,
                BuyerName = buyer.BuyerName == default ? changeBuyer.BuyerName : buyer.BuyerName,
                PersonalIdentificationNumber = buyer.PersonalIdentificationNumber == default ? changeBuyer.PersonalIdentificationNumber : buyer.PersonalIdentificationNumber,
                TicketId = buyer.TicketId == default ? changeBuyer.TicketId : buyer.TicketId,
            };
            bool isUpdated = await BuyerRepository.UpdateBuyerAsync(id, buyertoUpadate);
            return isUpdated;
        }
        public async Task<bool> DeleteBuyerAsync(Guid id)
        {
            Buyer buyerCheck = await BuyerRepository.GetBuyerAsync(id);
            if (buyerCheck == null)
            {
                return false;
            }
            bool isDeleted = await BuyerRepository.DeleteBuyerAsync(id);
            return isDeleted;
        }
        public async Task<List<Buyer>> GetPagingSortingFilteringAsync(Paging paging, Sorting sorting, Filtering filtering)        
        {
            BuyerRepository repository = new BuyerRepository();
            List<Buyer> buyers = await repository.GetPagingSortingFilteringAsync(paging, sorting, filtering);     
            return buyers;
        }
    }
}
