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
    
    public partial class tbl_Screens
    {
        public tbl_Screens()
        {
            this.tbl_ScreensToGroup = new HashSet<tbl_ScreensToGroup>();
        }
    
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
    
        public virtual ICollection<tbl_ScreensToGroup> tbl_ScreensToGroup { get; set; }
    }
}
