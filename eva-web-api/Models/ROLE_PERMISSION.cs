namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ROLE_PERMISSION
    {
        [Required]
        [StringLength(5)]
        public string ID_ROLE_PERMISSION { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string ID_ROLE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string ID_PERMISSION { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_CREATE { get; set; }

        public DateTime DATE_CREATE { get; set; }

        [StringLength(20)]
        public string USER_UPDATE { get; set; }

        public DateTime? DATE_UPDATE { get; set; }

        public virtual PERMISSION PERMISSION { get; set; }

        public virtual ROLE ROLE { get; set; }
    }
}
