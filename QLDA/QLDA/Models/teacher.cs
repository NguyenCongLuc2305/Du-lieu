namespace QLDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("teacher")]
    public partial class teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public teacher()
        {
            projects = new HashSet<project>();
        }

        [Key]
        [StringLength(50)]
        public string teacher_id { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime age { get; set; }

        [StringLength(50)]
        public string faculty { get; set; }

        [StringLength(50)]
        public string subject { get; set; }

        [StringLength(50)]
        public string education { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }
        public object ImageFile { get; internal set; }
    }
}
