//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBLAPTOP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DH()
        {
            this.CTDHBs = new HashSet<CTDHB>();
        }
    
        public string maDH { get; set; }
        public string maKH { get; set; }
        public string maNV { get; set; }
        public Nullable<int> Thanhtien { get; set; }
        public Nullable<System.DateTime> Ngayban { get; set; }
        public string hovaten { get; set; }
        public string diachikhachhang { get; set; }
        public string diachigiaohang { get; set; }
        public string sodienthoaikhachhang { get; set; }
        public string sodiennguoinhan { get; set; }
        public string socmtndkh { get; set; }
        public string socmtndnguoinhan { get; set; }
        public string taikhoannh { get; set; }
        public Nullable<int> tongsotien { get; set; }
        public Nullable<int> tienvat { get; set; }
        public Nullable<int> trangthaidonhang { get; set; }
    
        public virtual Khachhang Khachhang { get; set; }
        public virtual Nhanvien Nhanvien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDHB> CTDHBs { get; set; }
    }
}
