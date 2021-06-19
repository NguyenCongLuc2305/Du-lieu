namespace QLDA.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("student")]
    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            projects = new HashSet<project>();
        }

        [Key]
        [StringLength(50)]
        public string student_id { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime age { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [Column("class")]
        [StringLength(50)]
        public string _class { get; set; }

        [StringLength(50)]
        public string faculty { get; set; }

        [StringLength(12)]
        public string phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }
    }
}
