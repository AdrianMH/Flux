//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flux.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CcyXRate
    {
        public int CCYXRateId { get; set; }
        public string CcyId { get; set; }
        public System.DateTime DateXRate { get; set; }
        public decimal XRate { get; set; }
        public System.DateTime DateTimeCreated { get; set; }
        public string UserCreated { get; set; }
        public System.DateTime DateTimeUpdated { get; set; }
        public string UserUpdated { get; set; }
    
        public virtual Ccy Ccy { get; set; }
    }
}
