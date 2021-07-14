namespace QLDA.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("teacher")]
    public partial class teacher
    {

        [Key]
        [StringLength(50)]
        public string teacher_id { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(500)]
        public string image { get; set; }

        [NotMapped]
     
        public HttpPostedFileBase ImageFile { get; set; }

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

       
    }
}
