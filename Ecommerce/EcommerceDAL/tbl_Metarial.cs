//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommerceDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Metarial
    {
        public tbl_Metarial()
        {
            this.tbl_ProductMetarialInfo = new HashSet<tbl_ProductMetarialInfo>();
        }
    
        public int meterialId { get; set; }
        public string meterialName { get; set; }
        public string meterialDescription { get; set; }
    
        public virtual ICollection<tbl_ProductMetarialInfo> tbl_ProductMetarialInfo { get; set; }
    }
}
