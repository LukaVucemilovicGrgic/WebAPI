namespace Program.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Buyer")]
    public partial class Buyer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Buyer()
        {
            BureauBuyer = new HashSet<BureauBuyer>();
        }

        public Guid Id { get; set; }

        [StringLength(30)]
        public string BuyerName { get; set; }

        public int? PersonalIdentificationNumber { get; set; }

        public Guid? TicketId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BureauBuyer> BureauBuyer { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual InfoBuyer InfoBuyer { get; set; }
    }
}
