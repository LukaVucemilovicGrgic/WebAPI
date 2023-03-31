namespace Program.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InfoBuyer")]
    public partial class InfoBuyer
    {
        public Guid Id { get; set; }

        public int? NumberInSystem { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfCreation { get; set; }

        [StringLength(30)]
        public string PlaceOfCreation { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
