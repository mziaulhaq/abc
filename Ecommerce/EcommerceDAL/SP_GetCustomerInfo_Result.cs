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
    
    public partial class SP_GetCustomerInfo_Result
    {
        public long CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public System.DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ProvinceOrState { get; set; }
        public int CountryId { get; set; }
        public byte Status { get; set; }
        public int StoreId { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string Ipaddress { get; set; }
    }
}
