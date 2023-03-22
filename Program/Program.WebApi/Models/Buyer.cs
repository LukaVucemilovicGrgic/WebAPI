using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;

namespace Program.WebApi.Models
{
    public class Buyer
    {
        public Guid Id { get; set; }
        public string BuyerName { get; set; }
        public int PersonalIdentificationNumber { get; set; }
        public Guid TicketId { get; set; }
    }

}