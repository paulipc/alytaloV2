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
    
    public partial class Valo
    {
        public int ValoId { get; set; }
        public string Kuvaus { get; set; }
        public int TaloId { get; set; }
        public Nullable<int> ValonMaara { get; set; }
        public Nullable<bool> ValoPaalla { get; set; }
    
        public virtual Talo Talo { get; set; }
    }
}