//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ajuma.Relationship_Diagram
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonNhapHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonNhapHang()
        {
            this.ChiTietDonNhapHangs = new HashSet<ChiTietDonNhapHang>();
        }
    
        public string madonnhaphang { get; set; }
        public Nullable<System.DateTime> ngaydat { get; set; }
        public Nullable<System.DateTime> ngaynhan { get; set; }
        public Nullable<double> tongtien { get; set; }
        public string manhanvien { get; set; }
        public string manhacungcap { get; set; }
        public string trangthai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonNhapHang> ChiTietDonNhapHangs { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
