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
    
    public partial class tbl_ProductsGender
    {
        public long PGId { get; set; }
        public long PGProductId { get; set; }
        public int PGGenderId { get; set; }
    
        public virtual tbl_GenderCategories tbl_GenderCategories { get; set; }
        public virtual tbl_Products tbl_Products { get; set; }
    }
}