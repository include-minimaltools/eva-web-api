namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STUDENT")]
    public partial class STUDENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUDENT()
        {
            STUDENT_COURSE = new HashSet<STUDENT_COURSE>();
            STUDENT_TASK = new HashSet<STUDENT_TASK>();
        }

        [Key]
        [StringLength(10)]
        public string CARNET { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        [Required]
        [StringLength(20)]
        public string LASTNAME { get; set; }

        [StringLength(500)]
        public string ADDRESS { get; set; }

        [StringLength(9)]
        public string PHONE { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(5)]
        public string ID_CAREER { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_GROUPS { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_CREATE { get; set; }

        public DateTime DATE_CREATE { get; set; }

        [StringLength(20)]
        public string USER_UPDATE { get; set; }

        public DateTime? DATE_UPDATE { get; set; }

        public virtual CAREER CAREER { get; set; }

        public virtual GROUPS GROUPS { get; set; }

        public virtual USERS USERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT_COURSE> STUDENT_COURSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT_TASK> STUDENT_TASK { get; set; }
    }
}
