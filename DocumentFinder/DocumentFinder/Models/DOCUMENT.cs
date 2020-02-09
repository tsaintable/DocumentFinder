namespace DocumentFinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCUMENT")]
    public partial class DOCUMENT
    {
        [Key]
        public Guid UniqueDocID { get; set; }

        public int DocID { get; set; }

        [Required]
        [StringLength(50)]
        public string DocType { get; set; }

        [Required]
        [StringLength(50)]
        public string DocName { get; set; }

        [Required]
        [StringLength(50)]
        public string DocManuf { get; set; }

        [Required]
        [StringLength(50)]
        public string DocCatg { get; set; }

        [Required]
        [StringLength(50)]
        public string DocWONum { get; set; }

        [Required]
        [StringLength(50)]
        public string DocPONum { get; set; }

        public DateTime DocDate { get; set; }

        [Required]
        [StringLength(50)]
        public string DocProjMgr { get; set; }

        [Column(TypeName = "money")]
        public decimal DocEqpAmt { get; set; }

        [Required]
        public string DocDescr { get; set; }
    }
}
