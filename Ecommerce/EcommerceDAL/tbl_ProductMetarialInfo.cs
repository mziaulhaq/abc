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
    
    public partial class tbl_ProductMetarialInfo
    {
        public int productMetarialId { get; set; }
        public Nullable<long> productId { get; set; }
        public Nullable<int> metarialId { get; set; }
    
        public virtual tbl_Metarial tbl_Metarial { get; set; }
        public virtual tbl_Products tbl_Products { get; set; }
    }
}
