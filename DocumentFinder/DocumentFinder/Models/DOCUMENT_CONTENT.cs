namespace DocumentFinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DOCUMENT_CONTENT
    {
        [Key]
        public Guid UniqueContentID { get; set; }

        public Guid UDocIDContact { get; set; }

        [Required]
        [StringLength(50)]
        public string ContentNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string ContentDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string ContentVersion { get; set; }

        public DateTime ContentDateAssigned { get; set; }
    }
}
