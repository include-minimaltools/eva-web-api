namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TASK_COMMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TASK_COMMENT()
        {
            STUDENT_TASK = new HashSet<STUDENT_TASK>();
        }

        [Key]
        [StringLength(10)]
        public string ID_TASK_COMMENT { get; set; }

        [StringLength(10)]
        public string ID_STUDENT_TASK { get; set; }

        [StringLength(50)]
        public string EMAIL_USER { get; set; }

        [StringLength(10)]
        public string TYPE_TASK { get; set; }

        [StringLength(50)]
        public string DESCRIPTON { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_CREATE { get; set; }

        public DateTime DATE_CREATE { get; set; }

        [StringLength(20)]
        public string USER_UPDATE { get; set; }

        public DateTime? DATE_UPDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT_TASK> STUDENT_TASK { get; set; }

        public virtual TYPE_TASK TYPE_TASK1 { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
