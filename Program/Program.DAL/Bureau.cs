namespace Program.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bureau")]
    public partial class Bureau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bureau()
        {
            BureauBuyer = new HashSet<BureauBuyer>();
        }

        public Guid Id { get; set; }

        [StringLength(30)]
        public string AddressBureau { get; set; }

        public int? ContactNumber { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BureauBuyer> BureauBuyer { get; set; }
    }
}
