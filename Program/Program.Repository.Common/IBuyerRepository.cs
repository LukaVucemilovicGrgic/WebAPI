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
        List<Buyer> GetAllBuyers();
        List<Buyer> GetBuyer(Guid Id);
        //bool AddBuyer(Buyer buyer);
        //bool UpdateBuyer(Guid id, Buyer buyer);
        //bool DeleteBuyer(Guid id);

    }
}
