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
    
    public partial class tbl_ProductDynamicCategories
    {
        public tbl_ProductDynamicCategories()
        {
            this.tbl_ProductDynamicAttributes = new HashSet<tbl_ProductDynamicAttributes>();
        }
    
        public long PDCId { get; set; }
        public string PCDName { get; set; }
        public int StoreId { get; set; }
    
        public virtual ICollection<tbl_ProductDynamicAttributes> tbl_ProductDynamicAttributes { get; set; }
        public virtual tbl_Stores tbl_Stores { get; set; }
    }
}
