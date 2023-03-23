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
        public List<Buyer> GetAllBuyers()
        {
            BuyerRepository repository = new BuyerRepository();
            List<Buyer> buyers = repository.GetAllBuyers();
            return buyers;
        }
        public List<Buyer> GetBuyer(Guid Id)
        {
            BuyerRepository repository = new BuyerRepository();
            List<Buyer> buyer = repository.GetBuyer(Id);
            return buyer;
        }
    }
}
