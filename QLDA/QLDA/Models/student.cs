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

        [Required(ErrorMessage = "Bạn cần nhập mã sinh viên !!!")]
        [Key]
        [StringLength(50)]
        public string student_id { get; set; }

        [Required(ErrorMessage ="Bạn cần nhập giới tính !!! ")]
        [StringLength(50)]
        public string gender { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập email !!!")]
        [StringLength(50)]
        public string email { get; set; }


        [Required(ErrorMessage = "Bạn cần nhập ảnh !!!")]
        [StringLength(500)]
        public string image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [Required(ErrorMessage = "Bạn cần nhập tên !!!")]
        [StringLength(50)]
        public string name { get; set; }


        [Required(ErrorMessage = "Bạn cần nhập ngày sinh !!!")]
        [Column(TypeName = "date")]
        public DateTime age { get; set; }


        [Required(ErrorMessage = "Bạn cần nhập địa chỉ !!!")]
        [StringLength(50)]
        public string address { get; set; }


        [Required(ErrorMessage = "Bạn cần nhập lớp !!!")]
        [Column("class")]
        [StringLength(50)]
        public string _class { get; set; }


        [Required(ErrorMessage = "Bạn cần nhập khoa !!!")]
        [StringLength(50)]
        public string faculty { get; set; }


        [Required(ErrorMessage = "Bạn cần nhập số điện thoại !!!")]
        [StringLength(12)]
        public string phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }
    }
}
