using Program.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model
{
    public class Buyer : IBuyer
    {
        public Guid Id { get; set; }
        public string BuyerName { get; set; }
        public int? PersonalIdentificationNumber { get; set; }
        public Guid TicketId { get; set; }
    }
}
