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
    
    public partial class tbl_ScreensToGroup
    {
        public int GroupScreenId { get; set; }
        public int ScreenId { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
    
        public virtual tbl_Groups tbl_Groups { get; set; }
        public virtual tbl_Screens tbl_Screens { get; set; }
        public virtual tbl_Stores tbl_Stores { get; set; }
    }
}
