namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERMISSION")]
    public partial class PERMISSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERMISSION()
        {
            ROLE_PERMISSION = new HashSet<ROLE_PERMISSION>();
        }

        [Key]
        [StringLength(5)]
        public string ID_PERMISSION { get; set; }

        [Required]
        [StringLength(20)]
        public string DESCRIPTION { get; set; }

        [Required]
        [StringLength(20)]
        public string PAGE { get; set; }

        [Required]
        [StringLength(20)]
        public string ACTION { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_CREATE { get; set; }

        public DateTime DATE_CREATE { get; set; }

        [StringLength(20)]
        public string USER_UPDATE { get; set; }

        public DateTime? DATE_UPDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROLE_PERMISSION> ROLE_PERMISSION { get; set; }
    }
}
