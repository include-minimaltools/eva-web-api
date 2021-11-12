namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COURSE")]
    public partial class COURSE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURSE()
        {
            SEMESTER = new HashSet<SEMESTER>();
            STUDENT_COURSE = new HashSet<STUDENT_COURSE>();
            TASK = new HashSet<TASK>();
            TEACHER_COURSE = new HashSet<TEACHER_COURSE>();
        }

        [Key]
        public int ID_COURSE { get; set; }

        [Required]
        [StringLength(40)]
        public string NAME { get; set; }

        [Required]
        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        [StringLength(500)]
        public string OBJECTS { get; set; }

        public int CREDITS { get; set; }

        public int FRECUENCY { get; set; }

        public int HOURS { get; set; }

        [Required]
        [StringLength(5)]
        public string ID_CAREER { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_CREATE { get; set; }

        public DateTime DATE_CREATE { get; set; }

        [StringLength(20)]
        public string USER_UPDATE { get; set; }

        public DateTime? DATE_UPDATE { get; set; }

        public virtual CAREER CAREER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEMESTER> SEMESTER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT_COURSE> STUDENT_COURSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TASK> TASK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEACHER_COURSE> TEACHER_COURSE { get; set; }
    }
}
