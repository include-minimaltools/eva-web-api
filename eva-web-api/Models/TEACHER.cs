namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TEACHER")]
    public partial class TEACHER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEACHER()
        {
            TEACHER_COURSE = new HashSet<TEACHER_COURSE>();
            TEACHER_GROUPS = new HashSet<TEACHER_GROUPS>();
        }

        [Key]
        [StringLength(10)]
        public string ID_TEACHER { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        [StringLength(20)]
        public string LASTNAME { get; set; }

        [StringLength(500)]
        public string ADDRESS { get; set; }

        [StringLength(9)]
        public string PHONE { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_FACULTY { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_CREATE { get; set; }

        public DateTime DATE_CREATE { get; set; }

        [StringLength(20)]
        public string USER_UPDATE { get; set; }

        public DateTime? DATE_UPDATE { get; set; }

        public virtual FACULTY FACULTY { get; set; }

        public virtual USERS USERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEACHER_COURSE> TEACHER_COURSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEACHER_GROUPS> TEACHER_GROUPS { get; set; }
    }
}
