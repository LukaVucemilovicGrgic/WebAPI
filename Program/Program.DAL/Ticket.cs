namespace Program.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            Buyer = new HashSet<Buyer>();
        }

        public Guid Id { get; set; }

        public int? PriceE { get; set; }

        public int? NumberOfTicket { get; set; }

        public DateTime? Expire { get; set; }

        public Guid TicketTypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Buyer> Buyer { get; set; }

        public virtual TicketType TicketType { get; set; }
    }
}
