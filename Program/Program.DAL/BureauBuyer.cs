namespace Program.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BureauBuyer")]
    public partial class BureauBuyer
    {
        public Guid Id { get; set; }

        public int? AccountNumber { get; set; }

        public int? AmountOfMoney { get; set; }

        public DateTime? TimeOfPurchase { get; set; }

        public int? NumberOfBuyers { get; set; }

        public Guid BureauId { get; set; }

        public Guid BuyerId { get; set; }

        public virtual Bureau Bureau { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
