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
    
    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public string maalbum { get; set; }
        public string tenalbum { get; set; }
        public string mota { get; set; }
        public string anh { get; set; }
        public string manghesi { get; set; }
    
        public virtual NgheSi NgheSi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
