namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TASK")]
    public partial class TASK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TASK()
        {
            STUDENT_TASK = new HashSet<STUDENT_TASK>();
        }

        [Key]
        [StringLength(6)]
        public string ID_TASK { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        public DateTime DELIVERY_DATE { get; set; }

        public int ID_COURSE { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_TYPE_TASK { get; set; }

        public virtual COURSE COURSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT_TASK> STUDENT_TASK { get; set; }

        public virtual TYPE_TASK TYPE_TASK { get; set; }
    }
}
