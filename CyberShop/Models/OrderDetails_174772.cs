//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CyberShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetails_174772
    {
        public int OrderId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> UnitCost { get; set; }
    
        public virtual Products_174772 Products_174772 { get; set; }
    }
}
