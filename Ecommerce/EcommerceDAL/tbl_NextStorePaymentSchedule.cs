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
    
    public partial class tbl_NextStorePaymentSchedule
    {
        public int NextPSId { get; set; }
        public int StoreId { get; set; }
        public System.DateTime ScheduleDate { get; set; }
        public System.DateTime InsertionDate { get; set; }
        public int InsertedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    
        public virtual tbl_Stores tbl_Stores { get; set; }
        public virtual tbl_Stores tbl_Stores1 { get; set; }
        public virtual tbl_Users tbl_Users { get; set; }
        public virtual tbl_Users tbl_Users1 { get; set; }
    }
}
