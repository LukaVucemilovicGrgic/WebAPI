using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model.Common
{
    public interface IBuyer
    {
         Guid Id { get; set; }
        string BuyerName { get; set; }
        int? PersonalIdentificationNumber { get; set; }
        Guid? TicketId { get; set; }
    }
}
