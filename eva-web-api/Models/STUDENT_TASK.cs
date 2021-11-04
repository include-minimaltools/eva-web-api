namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STUDENT_TASK
    {
        [Required]
        [StringLength(10)]
        public string ID_STUDENT_TASK { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ID_STUDENT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string ID_TASK { get; set; }

        [StringLength(10)]
        public string QUALIFICATION { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SEND_DATE { get; set; }

        [MaxLength(50)]
        public byte[] TASK_FILE { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_CREATE { get; set; }

        public DateTime DATE_CREATE { get; set; }

        [StringLength(20)]
        public string USER_UPDATE { get; set; }

        public DateTime? DATE_UPDATE { get; set; }

        public virtual STUDENT STUDENT { get; set; }

        public virtual TASK_COMMENT TASK_COMMENT { get; set; }

        public virtual TASK TASK { get; set; }
    }
}
