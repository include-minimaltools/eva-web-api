namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TEACHER_GROUPS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ID_TEACHER { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string ID_GROUPS { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_CREATE { get; set; }

        public DateTime DATE_CREATE { get; set; }

        [StringLength(20)]
        public string USER_UPDATE { get; set; }

        public DateTime? DATE_UPDATE { get; set; }

        public virtual GROUPS GROUPS { get; set; }

        public virtual TEACHER TEACHER { get; set; }
    }
}
