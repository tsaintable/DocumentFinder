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
        [StringLength(10)]
        public string UniqueContentID { get; set; }

        [Required]
        [StringLength(10)]
        public string ContentNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string ContentDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string ContentVersion { get; set; }

        [StringLength(10)]
        public string ContentDateAssigned { get; set; }
    }
}
