using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core2
{
    public class dept2
    {
        [Key]
        public string deptid { get; set; }
        public string deptname { get; set; }
        public string location { get; set; }
        public IList<items2> items2 { get; set; }
    }
    public partial class items2
    {
        [Key]
        public string itemcode { get; set; }
        public string itemname { get; set; }
        [ForeignKey("dept2")]
        public string deptid { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> cost { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> rate { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
        public dept2 dept2 { get; set; }

    }
    public class dept_ItemsVm
    {
        public string DeptId { get; set; }
        [Required(ErrorMessage ="Please ender the Dept Name")]
        [Display (Name ="DeptName")]
        [MaxLength(50)]
        public string DeptName { get; set; }
        public string Location { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double Cost { get; set; }
        public double Rate { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
        public string sid { get; set; }
    }

}
