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
            STUDENT = new HashSet<STUDENT>();
            SEMESTER = new HashSet<SEMESTER>();
        }

        [Key]
        [StringLength(5)]
        public string ID_CARRER { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCRIPTION { get; set; }

        [StringLength(10)]
        public string FACULTY { get; set; }

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

        public virtual CAMPUS CAMPUS2 { get; set; }

        public virtual CAMPUS CAMPUS3 { get; set; }

        public virtual CAMPUS CAMPUS4 { get; set; }

        public virtual FACULTY FACULTY1 { get; set; }

        public virtual FACULTY FACULTY2 { get; set; }

        public virtual FACULTY FACULTY3 { get; set; }

        public virtual FACULTY FACULTY4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COURSE> COURSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT> STUDENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEMESTER> SEMESTER { get; set; }
    }
}
