namespace QLDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("project")]
    public partial class project
    {
        [Key]
        [StringLength(50)]
        public string project_id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime start { get; set; }

        [Column(TypeName = "date")]
        public DateTime end { get; set; }

        [StringLength(50)]
        public string teacher_id { get; set; }

        [StringLength(50)]
        public string student_id { get; set; }

        public virtual student student { get; set; }

        public virtual teacher teacher { get; set; }
    }
}
