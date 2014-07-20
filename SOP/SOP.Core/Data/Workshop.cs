//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SOP.Core.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Workshop
    {
        public Workshop()
        {
            this.PaymentSummaries = new HashSet<PaymentSummary>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Location { get; set; }
        public string MapCoordinates { get; set; }
        public string GeneralManagerName { get; set; }
        public Nullable<decimal> GeneralManagerNum { get; set; }
        public int DelearId { get; set; }
    
        public virtual Dealer Dealer { get; set; }
        public virtual ICollection<PaymentSummary> PaymentSummaries { get; set; }
    }
}