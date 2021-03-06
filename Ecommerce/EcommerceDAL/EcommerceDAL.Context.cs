﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class ClothEntities : DbContext
    {
        public ClothEntities()
            : base("name=ClothEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_BillingTerm> tbl_BillingTerm { get; set; }
        public DbSet<tbl_Brands> tbl_Brands { get; set; }
        public DbSet<tbl_BrandsUpdation> tbl_BrandsUpdation { get; set; }
        public DbSet<tbl_Categories> tbl_Categories { get; set; }
        public DbSet<tbl_CategoriesUpdationRecord> tbl_CategoriesUpdationRecord { get; set; }
        public DbSet<tbl_Colors> tbl_Colors { get; set; }
        public DbSet<tbl_Country> tbl_Country { get; set; }
        public DbSet<tbl_Customers> tbl_Customers { get; set; }
        public DbSet<tbl_GenderCategories> tbl_GenderCategories { get; set; }
        public DbSet<tbl_Groups> tbl_Groups { get; set; }
        public DbSet<tbl_HomePageBanners> tbl_HomePageBanners { get; set; }
        public DbSet<tbl_Metarial> tbl_Metarial { get; set; }
        public DbSet<tbl_NextStorePaymentSchedule> tbl_NextStorePaymentSchedule { get; set; }
        public DbSet<tbl_Orders> tbl_Orders { get; set; }
        public DbSet<tbl_OrdersUpdation> tbl_OrdersUpdation { get; set; }
        public DbSet<tbl_Packages> tbl_Packages { get; set; }
        public DbSet<tbl_Pages> tbl_Pages { get; set; }
        public DbSet<tbl_PagesUpdation> tbl_PagesUpdation { get; set; }
        public DbSet<tbl_PaymentMethods> tbl_PaymentMethods { get; set; }
        public DbSet<tbl_ProductCategories> tbl_ProductCategories { get; set; }
        public DbSet<tbl_ProductDynamicAttributes> tbl_ProductDynamicAttributes { get; set; }
        public DbSet<tbl_ProductDynamicCategories> tbl_ProductDynamicCategories { get; set; }
        public DbSet<tbl_ProductImages> tbl_ProductImages { get; set; }
        public DbSet<tbl_ProductMetarialInfo> tbl_ProductMetarialInfo { get; set; }
        public DbSet<tbl_Products> tbl_Products { get; set; }
        public DbSet<tbl_ProductsColors> tbl_ProductsColors { get; set; }
        public DbSet<tbl_ProductsGender> tbl_ProductsGender { get; set; }
        public DbSet<tbl_SalesTaxRates> tbl_SalesTaxRates { get; set; }
        public DbSet<tbl_SalesTaxRatesUpdation> tbl_SalesTaxRatesUpdation { get; set; }
        public DbSet<tbl_Screens> tbl_Screens { get; set; }
        public DbSet<tbl_ScreensToGroup> tbl_ScreensToGroup { get; set; }
        public DbSet<tbl_StorePayment> tbl_StorePayment { get; set; }
        public DbSet<tbl_Stores> tbl_Stores { get; set; }
        public DbSet<tbl_Templates> tbl_Templates { get; set; }
        public DbSet<tbl_Users> tbl_Users { get; set; }
        public DbSet<tbl_UsersUpdation> tbl_UsersUpdation { get; set; }
    
        public virtual ObjectResult<BrandsUpdateInformation> ReturnBrandsUpdateInformation(Nullable<int> brandId, Nullable<int> storeId)
        {
            var brandIdParameter = brandId.HasValue ?
                new ObjectParameter("BrandId", brandId) :
                new ObjectParameter("BrandId", typeof(int));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BrandsUpdateInformation>("ReturnBrandsUpdateInformation", brandIdParameter, storeIdParameter);
        }
    
        public virtual ObjectResult<BrandsToUserInformation> BrandToUserInformation(Nullable<int> brandId, Nullable<int> storeId)
        {
            var brandIdParameter = brandId.HasValue ?
                new ObjectParameter("BrandId", brandId) :
                new ObjectParameter("BrandId", typeof(int));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BrandsToUserInformation>("BrandToUserInformation", brandIdParameter, storeIdParameter);
        }
    
        public virtual ObjectResult<Categories> SP_Categories_GetACategoryChildCategories(Nullable<int> storeId, Nullable<int> catID)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var catIDParameter = catID.HasValue ?
                new ObjectParameter("CatID", catID) :
                new ObjectParameter("CatID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Categories>("SP_Categories_GetACategoryChildCategories", storeIdParameter, catIDParameter);
        }
    
        public virtual ObjectResult<Categories> SP_Categories_GetAllCategories(Nullable<int> storeId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Categories>("SP_Categories_GetAllCategories", storeIdParameter);
        }
    
        public virtual ObjectResult<Categories> SP_Categories_GetAllInActiveCategories(Nullable<int> storeId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Categories>("SP_Categories_GetAllInActiveCategories", storeIdParameter);
        }
    
        public virtual ObjectResult<Categories> SP_Categories_SearchWithInCategory(string searchVal, Nullable<int> storeId)
        {
            var searchValParameter = searchVal != null ?
                new ObjectParameter("SearchVal", searchVal) :
                new ObjectParameter("SearchVal", typeof(string));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Categories>("SP_Categories_SearchWithInCategory", searchValParameter, storeIdParameter);
        }
    
        public virtual ObjectResult<ProductToCategories> SP_Product_GetAProductCategories(Nullable<int> storeId, Nullable<long> pId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("PId", pId) :
                new ObjectParameter("PId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductToCategories>("SP_Product_GetAProductCategories", storeIdParameter, pIdParameter);
        }
    
        public virtual ObjectResult<Categories> GetAllActiveCategoriesNotBindToAProduct(Nullable<int> storeId, Nullable<long> pId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("PId", pId) :
                new ObjectParameter("PId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Categories>("GetAllActiveCategoriesNotBindToAProduct", storeIdParameter, pIdParameter);
        }
    
        public virtual ObjectResult<Colors> GetAllColorsNotBindToProduct(Nullable<int> storeId, Nullable<long> productId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("storeId", storeId) :
                new ObjectParameter("storeId", typeof(int));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("productId", productId) :
                new ObjectParameter("productId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Colors>("GetAllColorsNotBindToProduct", storeIdParameter, productIdParameter);
        }
    
        public virtual ObjectResult<Genders> GetAllGenderNotBindToProduct(Nullable<int> storeId, Nullable<long> productId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("storeId", storeId) :
                new ObjectParameter("storeId", typeof(int));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("productId", productId) :
                new ObjectParameter("productId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Genders>("GetAllGenderNotBindToProduct", storeIdParameter, productIdParameter);
        }
    
        public virtual ObjectResult<DynamicCategories> GetDistinctDynamicCatNotBindToProduct(Nullable<int> storeId, Nullable<long> pId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("storeId", storeId) :
                new ObjectParameter("storeId", typeof(int));
    
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DynamicCategories>("GetDistinctDynamicCatNotBindToProduct", storeIdParameter, pIdParameter);
        }
    
        public virtual ObjectResult<ProductDynamicCategories> GetAllDynamicCategoriesofProduct(Nullable<int> storeId, Nullable<long> pId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("storeId", storeId) :
                new ObjectParameter("storeId", typeof(int));
    
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductDynamicCategories>("GetAllDynamicCategoriesofProduct", storeIdParameter, pIdParameter);
        }
    
        public virtual ObjectResult<Users> AuthenticateUser(string userLoginId, string userLoginPwd)
        {
            var userLoginIdParameter = userLoginId != null ?
                new ObjectParameter("UserLoginId", userLoginId) :
                new ObjectParameter("UserLoginId", typeof(string));
    
            var userLoginPwdParameter = userLoginPwd != null ?
                new ObjectParameter("UserLoginPwd", userLoginPwd) :
                new ObjectParameter("UserLoginPwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Users>("AuthenticateUser", userLoginIdParameter, userLoginPwdParameter);
        }
    
        public virtual ObjectResult<Screens> GetGroupAuthorizedScreens(Nullable<int> groupId, Nullable<int> storeId)
        {
            var groupIdParameter = groupId.HasValue ?
                new ObjectParameter("GroupId", groupId) :
                new ObjectParameter("GroupId", typeof(int));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Screens>("GetGroupAuthorizedScreens", groupIdParameter, storeIdParameter);
        }
    
        public virtual ObjectResult<UsersInfo> GetAllUsers(Nullable<int> storeId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsersInfo>("GetAllUsers", storeIdParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> SP_CalculateProductPrice(Nullable<long> pId)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("PId", pId) :
                new ObjectParameter("PId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("SP_CalculateProductPrice", pIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_GetSalesTaxRateForProduct(Nullable<long> productId)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_GetSalesTaxRateForProduct", productIdParameter);
        }
    
        public virtual int SP_ConfirmOrder(Nullable<long> orderId, Nullable<int> userId, Nullable<int> storeId, ObjectParameter returnVal)
        {
            var orderIdParameter = orderId.HasValue ?
                new ObjectParameter("OrderId", orderId) :
                new ObjectParameter("OrderId", typeof(long));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ConfirmOrder", orderIdParameter, userIdParameter, storeIdParameter, returnVal);
        }
    
        public virtual int SP_RejectOrderAfterConfirmation(Nullable<long> orderId, Nullable<int> userId, Nullable<int> storeId, ObjectParameter returnVal)
        {
            var orderIdParameter = orderId.HasValue ?
                new ObjectParameter("OrderId", orderId) :
                new ObjectParameter("OrderId", typeof(long));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_RejectOrderAfterConfirmation", orderIdParameter, userIdParameter, storeIdParameter, returnVal);
        }
    
        public virtual ObjectResult<SalesReportByDate> SP_SalesReportByDate(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> storeId, Nullable<int> pageIndex, Nullable<int> pageSize, ObjectParameter totalProfit, ObjectParameter totalCount)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SalesReportByDate>("SP_SalesReportByDate", startDateParameter, endDateParameter, storeIdParameter, pageIndexParameter, pageSizeParameter, totalProfit, totalCount);
        }
    
        public virtual ObjectResult<SalesReportByProduct> SP_SalesReportByProduct(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> storeId, Nullable<int> pageIndex, Nullable<int> pageSize, Nullable<long> pId, ObjectParameter stockAmountSold, ObjectParameter totalProfit, ObjectParameter totalCount)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("PId", pId) :
                new ObjectParameter("PId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SalesReportByProduct>("SP_SalesReportByProduct", startDateParameter, endDateParameter, storeIdParameter, pageIndexParameter, pageSizeParameter, pIdParameter, stockAmountSold, totalProfit, totalCount);
        }
    
        public virtual ObjectResult<SalesReportByDateForDownload> SP_SalesReportByDateForDownload(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> storeId, ObjectParameter totalProfit)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SalesReportByDateForDownload>("SP_SalesReportByDateForDownload", startDateParameter, endDateParameter, storeIdParameter, totalProfit);
        }
    
        public virtual ObjectResult<SalesReportByProductForDownload> SP_SalesReportByProductForDownload(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> storeId, Nullable<long> pId, ObjectParameter stockAmountSold, ObjectParameter totalProfit, ObjectParameter totalCount)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("PId", pId) :
                new ObjectParameter("PId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SalesReportByProductForDownload>("SP_SalesReportByProductForDownload", startDateParameter, endDateParameter, storeIdParameter, pIdParameter, stockAmountSold, totalProfit, totalCount);
        }
    
        public virtual ObjectResult<StoreInformation> GetStoreInformation(string domainName)
        {
            var domainNameParameter = domainName != null ?
                new ObjectParameter("DomainName", domainName) :
                new ObjectParameter("DomainName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StoreInformation>("GetStoreInformation", domainNameParameter);
        }
    
        public virtual ObjectResult<SP_OrderStatus_Customer_Result> SP_OrderStatus_Customer(Nullable<long> customerId, Nullable<int> pageSize, Nullable<int> pageIndex, Nullable<int> storeId, ObjectParameter totalCount)
        {
            var customerIdParameter = customerId.HasValue ?
                new ObjectParameter("CustomerId", customerId) :
                new ObjectParameter("CustomerId", typeof(long));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_OrderStatus_Customer_Result>("SP_OrderStatus_Customer", customerIdParameter, pageSizeParameter, pageIndexParameter, storeIdParameter, totalCount);
        }
    
        public virtual ObjectResult<SP_GetSubmittedtOrdersByOrderId_Result> SP_GetSubmittedtOrdersByOrderId(Nullable<int> storeId, Nullable<int> orderId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var orderIdParameter = orderId.HasValue ?
                new ObjectParameter("OrderId", orderId) :
                new ObjectParameter("OrderId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetSubmittedtOrdersByOrderId_Result>("SP_GetSubmittedtOrdersByOrderId", storeIdParameter, orderIdParameter);
        }
    
        public virtual ObjectResult<SP_GetSubmittedtOrders_Result1> SP_GetSubmittedtOrders(Nullable<int> storeId, Nullable<int> orderStatus, string dateFrom, string dateTo, string customerName)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var orderStatusParameter = orderStatus.HasValue ?
                new ObjectParameter("OrderStatus", orderStatus) :
                new ObjectParameter("OrderStatus", typeof(int));
    
            var dateFromParameter = dateFrom != null ?
                new ObjectParameter("DateFrom", dateFrom) :
                new ObjectParameter("DateFrom", typeof(string));
    
            var dateToParameter = dateTo != null ?
                new ObjectParameter("DateTo", dateTo) :
                new ObjectParameter("DateTo", typeof(string));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetSubmittedtOrders_Result1>("SP_GetSubmittedtOrders", storeIdParameter, orderStatusParameter, dateFromParameter, dateToParameter, customerNameParameter);
        }
    
        public virtual ObjectResult<SP_Categories_GetAllActiveCategories_Result1> SP_Categories_GetAllActiveCategories(Nullable<int> storeId)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Categories_GetAllActiveCategories_Result1>("SP_Categories_GetAllActiveCategories", storeIdParameter);
        }
    
        public virtual ObjectResult<SP_Materials_GetAllMaterialsNotBindToProduct_Result> SP_Materials_GetAllMaterialsNotBindToProduct(Nullable<long> productId)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("productId", productId) :
                new ObjectParameter("productId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Materials_GetAllMaterialsNotBindToProduct_Result>("SP_Materials_GetAllMaterialsNotBindToProduct", productIdParameter);
        }
    
        public virtual ObjectResult<SP_GetCustomerInfo_Result> SP_GetCustomerInfo(Nullable<int> storeId, Nullable<int> status, string registrationDate, string customerName, string email)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(int));
    
            var registrationDateParameter = registrationDate != null ?
                new ObjectParameter("RegistrationDate", registrationDate) :
                new ObjectParameter("RegistrationDate", typeof(string));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetCustomerInfo_Result>("SP_GetCustomerInfo", storeIdParameter, statusParameter, registrationDateParameter, customerNameParameter, emailParameter);
        }
    
        public virtual ObjectResult<SP_ProductSearchFront_Result> SP_ProductSearchFront(string name, Nullable<int> catId, Nullable<long> dynamicCategory, Nullable<int> gender, Nullable<int> color, Nullable<short> status, Nullable<int> featured, Nullable<int> brand, Nullable<int> storeId, Nullable<int> pageIndex, Nullable<int> pageSize, string orderByCol, string orderBy, ObjectParameter totalCount)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var catIdParameter = catId.HasValue ?
                new ObjectParameter("CatId", catId) :
                new ObjectParameter("CatId", typeof(int));
    
            var dynamicCategoryParameter = dynamicCategory.HasValue ?
                new ObjectParameter("DynamicCategory", dynamicCategory) :
                new ObjectParameter("DynamicCategory", typeof(long));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(int));
    
            var colorParameter = color.HasValue ?
                new ObjectParameter("Color", color) :
                new ObjectParameter("Color", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(short));
    
            var featuredParameter = featured.HasValue ?
                new ObjectParameter("Featured", featured) :
                new ObjectParameter("Featured", typeof(int));
    
            var brandParameter = brand.HasValue ?
                new ObjectParameter("Brand", brand) :
                new ObjectParameter("Brand", typeof(int));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var orderByColParameter = orderByCol != null ?
                new ObjectParameter("OrderByCol", orderByCol) :
                new ObjectParameter("OrderByCol", typeof(string));
    
            var orderByParameter = orderBy != null ?
                new ObjectParameter("OrderBy", orderBy) :
                new ObjectParameter("OrderBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ProductSearchFront_Result>("SP_ProductSearchFront", nameParameter, catIdParameter, dynamicCategoryParameter, genderParameter, colorParameter, statusParameter, featuredParameter, brandParameter, storeIdParameter, pageIndexParameter, pageSizeParameter, orderByColParameter, orderByParameter, totalCount);
        }
    
        public virtual ObjectResult<SP_AdvanceSearch_Result> SP_AdvanceSearch(Nullable<int> storeId, string catId, string gender, string color, string brand, string material, string minPrice, string maxPrice, Nullable<int> pageIndex, Nullable<int> pageSize, string orderByCol, string orderBy, ObjectParameter totalCount)
        {
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var catIdParameter = catId != null ?
                new ObjectParameter("CatId", catId) :
                new ObjectParameter("CatId", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var colorParameter = color != null ?
                new ObjectParameter("Color", color) :
                new ObjectParameter("Color", typeof(string));
    
            var brandParameter = brand != null ?
                new ObjectParameter("Brand", brand) :
                new ObjectParameter("Brand", typeof(string));
    
            var materialParameter = material != null ?
                new ObjectParameter("Material", material) :
                new ObjectParameter("Material", typeof(string));
    
            var minPriceParameter = minPrice != null ?
                new ObjectParameter("MinPrice", minPrice) :
                new ObjectParameter("MinPrice", typeof(string));
    
            var maxPriceParameter = maxPrice != null ?
                new ObjectParameter("MaxPrice", maxPrice) :
                new ObjectParameter("MaxPrice", typeof(string));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var orderByColParameter = orderByCol != null ?
                new ObjectParameter("OrderByCol", orderByCol) :
                new ObjectParameter("OrderByCol", typeof(string));
    
            var orderByParameter = orderBy != null ?
                new ObjectParameter("OrderBy", orderBy) :
                new ObjectParameter("OrderBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_AdvanceSearch_Result>("SP_AdvanceSearch", storeIdParameter, catIdParameter, genderParameter, colorParameter, brandParameter, materialParameter, minPriceParameter, maxPriceParameter, pageIndexParameter, pageSizeParameter, orderByColParameter, orderByParameter, totalCount);
        }
    
        public virtual ObjectResult<SP_ReturnBrandsWithNoOfProducts_Result> SP_ReturnBrandsWithNoOfProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ReturnBrandsWithNoOfProducts_Result>("SP_ReturnBrandsWithNoOfProducts");
        }
    
        public virtual ObjectResult<SP_ReturnColorsWithNoOfProducts_Result> SP_ReturnColorsWithNoOfProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ReturnColorsWithNoOfProducts_Result>("SP_ReturnColorsWithNoOfProducts");
        }
    
        public virtual ObjectResult<SP_ReturnGenderWithNoOfProducts_Result> SP_ReturnGenderWithNoOfProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ReturnGenderWithNoOfProducts_Result>("SP_ReturnGenderWithNoOfProducts");
        }
    
        public virtual ObjectResult<SP_ReturnMetarialWithNoOfProducts_Result> SP_ReturnMetarialWithNoOfProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ReturnMetarialWithNoOfProducts_Result>("SP_ReturnMetarialWithNoOfProducts");
        }
    
        public virtual ObjectResult<SP_ReturnTypeWithNoOfProducts_Result> SP_ReturnTypeWithNoOfProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ReturnTypeWithNoOfProducts_Result>("SP_ReturnTypeWithNoOfProducts");
        }
    
        public virtual ObjectResult<SP_ProductSearch_Result> SP_ProductSearch(string name, Nullable<int> catId, Nullable<long> dynamicCategory, Nullable<int> gender, Nullable<int> color, Nullable<short> status, Nullable<int> featured, Nullable<int> brand, Nullable<int> storeId, Nullable<int> pageIndex, Nullable<int> pageSize, string orderByCol, string orderBy, ObjectParameter totalCount)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var catIdParameter = catId.HasValue ?
                new ObjectParameter("CatId", catId) :
                new ObjectParameter("CatId", typeof(int));
    
            var dynamicCategoryParameter = dynamicCategory.HasValue ?
                new ObjectParameter("DynamicCategory", dynamicCategory) :
                new ObjectParameter("DynamicCategory", typeof(long));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(int));
    
            var colorParameter = color.HasValue ?
                new ObjectParameter("Color", color) :
                new ObjectParameter("Color", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(short));
    
            var featuredParameter = featured.HasValue ?
                new ObjectParameter("Featured", featured) :
                new ObjectParameter("Featured", typeof(int));
    
            var brandParameter = brand.HasValue ?
                new ObjectParameter("Brand", brand) :
                new ObjectParameter("Brand", typeof(int));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var orderByColParameter = orderByCol != null ?
                new ObjectParameter("OrderByCol", orderByCol) :
                new ObjectParameter("OrderByCol", typeof(string));
    
            var orderByParameter = orderBy != null ?
                new ObjectParameter("OrderBy", orderBy) :
                new ObjectParameter("OrderBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ProductSearch_Result>("SP_ProductSearch", nameParameter, catIdParameter, dynamicCategoryParameter, genderParameter, colorParameter, statusParameter, featuredParameter, brandParameter, storeIdParameter, pageIndexParameter, pageSizeParameter, orderByColParameter, orderByParameter, totalCount);
        }
    
        public virtual ObjectResult<SP_SearchProduct_Result> SP_SearchProduct(string searchText, Nullable<int> startIndex, Nullable<int> endIndex, Nullable<int> storeId, ObjectParameter totalCount)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var startIndexParameter = startIndex.HasValue ?
                new ObjectParameter("StartIndex", startIndex) :
                new ObjectParameter("StartIndex", typeof(int));
    
            var endIndexParameter = endIndex.HasValue ?
                new ObjectParameter("EndIndex", endIndex) :
                new ObjectParameter("EndIndex", typeof(int));
    
            var storeIdParameter = storeId.HasValue ?
                new ObjectParameter("StoreId", storeId) :
                new ObjectParameter("StoreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SearchProduct_Result>("SP_SearchProduct", searchTextParameter, startIndexParameter, endIndexParameter, storeIdParameter, totalCount);
        }
    }
}
