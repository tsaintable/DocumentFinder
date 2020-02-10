namespace DocumentFinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DOCUMENT_DISTRIBUTION
    {
        [Key]
        public Guid UniqueDistrID { get; set; }

        public Guid UDocIDDistribution { get; set; }

        [Required]
        [StringLength(50)]
        public string DistributionOwner { get; set; }

        [Required]
        [StringLength(50)]
        public string DistributionLocation { get; set; }

        [Column(TypeName = "money")]
        public decimal DistributionAmount { get; set; }

        public DateTime DistributionDateAssigned { get; set; }
    }
}
