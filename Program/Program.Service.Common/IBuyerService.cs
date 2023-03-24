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
        List<Buyer> GetAllBuyers();
        List<Buyer> GetBuyer(Guid Id);
        bool AddBuyer(Buyer buyer);
        bool UpdateBuyer(Guid id, Buyer buyer);
        bool DeleteBuyer(Guid id);
    }
}
