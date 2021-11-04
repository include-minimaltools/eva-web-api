namespace eva_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TYPE_TASK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TYPE_TASK()
        {
            TASK_COMMENT = new HashSet<TASK_COMMENT>();
        }

        [Key]
        [StringLength(10)]
        public string ID_TYPE_TASK { get; set; }

        [StringLength(10)]
        public string DESCIPTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TASK_COMMENT> TASK_COMMENT { get; set; }
    }
}
