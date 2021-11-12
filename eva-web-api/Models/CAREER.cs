namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAREER")]
    public partial class CAREER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAREER()
        {
            COURSE = new HashSet<COURSE>();
            SEMESTER = new HashSet<SEMESTER>();
            STUDENT = new HashSet<STUDENT>();
        }

        [Key]
        [StringLength(5)]
        public string ID_CAREER { get; set; }

        [Required]
        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        [Required]
        [StringLength(10)]
        public string FACULTY { get; set; }

        [Required]
        [StringLength(10)]
        public string CAMPUS { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_CREATE { get; set; }

        public DateTime DATE_CREATE { get; set; }

        [StringLength(20)]
        public string USER_UPDATE { get; set; }

        public DateTime? DATE_UPDATE { get; set; }

        public virtual CAMPUS CAMPUS1 { get; set; }

        public virtual FACULTY FACULTY1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COURSE> COURSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEMESTER> SEMESTER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT> STUDENT { get; set; }
    }
}
