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
    
    public partial class SP_ProductSearch_Result
    {
        public Nullable<long> RowNumber { get; set; }
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductBrandId { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public string ProductPriceDescription { get; set; }
        public long ProductInStock { get; set; }
        public string ProductImage { get; set; }
        public int ProductInsertedBy { get; set; }
        public System.DateTime ProductInsertedDate { get; set; }
        public int StoreId { get; set; }
        public Nullable<bool> ProductIsFeatured { get; set; }
        public int ProductStatus { get; set; }
        public int ProductSale { get; set; }
        public int SalesTaxId { get; set; }
    }
}
