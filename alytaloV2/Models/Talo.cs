//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace alytaloV2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Talo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Talo()
        {
            this.Valo = new HashSet<Valo>();
            this.Sauna = new HashSet<Sauna>();
        }
    
        public int TaloId { get; set; }
        public string Kuvaus { get; set; }
        public Nullable<double> NykyLampo { get; set; }
        public Nullable<double> TavoiteLampo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Valo> Valo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sauna> Sauna { get; set; }
    }
}
