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
    
    public partial class tbl_SalesTaxRates
    {
        public tbl_SalesTaxRates()
        {
            this.tbl_Products = new HashSet<tbl_Products>();
            this.tbl_Products1 = new HashSet<tbl_Products>();
            this.tbl_SalesTaxRatesUpdation = new HashSet<tbl_SalesTaxRatesUpdation>();
        }
    
        public int SalesTaxId { get; set; }
        public int SalesTaxRate { get; set; }
        public string SalesTaxSector { get; set; }
        public string SalesTaxDescription { get; set; }
        public int SalesTaxCreatedBy { get; set; }
        public System.DateTime SalesTaxCreatedDate { get; set; }
        public Nullable<int> SalesTaxLastUpdatedBy { get; set; }
        public Nullable<System.DateTime> SalesTaxLastUpdateDate { get; set; }
        public Nullable<int> StoreId { get; set; }
    
        public virtual ICollection<tbl_Products> tbl_Products { get; set; }
        public virtual ICollection<tbl_Products> tbl_Products1 { get; set; }
        public virtual tbl_Stores tbl_Stores { get; set; }
        public virtual ICollection<tbl_SalesTaxRatesUpdation> tbl_SalesTaxRatesUpdation { get; set; }
    }
}
