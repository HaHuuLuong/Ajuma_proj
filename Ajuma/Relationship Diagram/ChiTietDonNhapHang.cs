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
    
    public partial class ChiTietDonNhapHang
    {
        public string madonnhaphang { get; set; }
        public string masanpham { get; set; }
        public double soluongdat_ { get; set; }
        public Nullable<double> dongia_ { get; set; }
        public Nullable<double> thanhtien_ { get; set; }
        public Nullable<double> soluongnhan_ { get; set; }
        public string trangthai_ { get; set; }
    
        public virtual DonNhapHang DonNhapHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
