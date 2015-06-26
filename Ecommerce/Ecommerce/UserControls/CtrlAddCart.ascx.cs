using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.UserControls
{
    public partial class CtrlAddCart : UserControlFront
    {
        private long _pId;
        private const string Pid = "_pId";
        private string _productImageMain;
        private string _productImageThumNail;
        protected override void OnPreRender(EventArgs e)
        {
            //hlkcheckOut.Enabled = LoggedCustomer.GetCartItems().Count != 0;
            btnCheckOut.Enabled = LoggedCustomer.GetCartItems().Count != 0;
            base.OnPreRender(e);
        }

        protected string ProductImageMain
        {
            get { return _productImageMain; }
            set { _productImageMain = _imagePath + value.ToString().Replace("ThmbNail", "Large"); }
        }

        public string ProductImageThumbNail
        {
            get { return _productImageThumNail; }
            set { _productImageThumNail = _imagePath + value; }
        }

        private readonly string _imagePath = ConfigurationManager.AppSettings["ProductImagePathUrl"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PId"] != null && long.TryParse(Request.QueryString["PId"], out _pId))
                {
                    ProductDetail();
                }
                else
                {
                    Response.Redirect(Request.UrlReferrer == null ? "~/index.aspx" : Request.UrlReferrer.ToString());
                }

            }

        }

        private void ProductDetail()
        {
            using (var clothEntities = new ClothEntities())
            {
                var product = (from prod in clothEntities.tbl_Products
                               join brand in clothEntities.tbl_Brands
                                   on prod.ProductBrandId equals brand.BrandId
                               join sales in clothEntities.tbl_SalesTaxRates
                               on prod.SalesTaxId equals sales.SalesTaxId
                               where (prod.StoreId == StoreId && prod.ProductStatus != 0 && prod.ProductID == _pId)
                               select new
                                          {
                                              Name = prod.ProductName,
                                              Description = prod.ProductDescription,
                                              Price = prod.ProductUnitPrice,
                                              PriceDescription = prod.ProductDescription,
                                              Stock = prod.ProductInStock,
                                              SaleAmount = prod.ProductSale,
                                              sales.SalesTaxRate,
                                              sales.SalesTaxSector,
                                              prod.SalesTaxId,
                                              brand.BrandName,
                                              brand.BrandImage,
                                              brand.BrandId,
                                              prod.ProductImage

                                          }).ToList();

                if (product.Count == 1)
                {
                    int rates = product[0].SalesTaxRate;
                    var stocklst =
                     (clothEntities.tbl_Orders.Where(
                            order => order.OrderStatus == 0 && order.ProductId == _pId && order.StoreID == StoreId).
                            Select(od => od.Quantity)).ToList();
                    long processCount = stocklst.Count != 0 ? stocklst.Sum() : 0;
                    long stock = product[0].Stock - processCount;
                    spBrandName.InnerText = product[0].BrandName;
                    spPrice.InnerText = Convert.ToInt64(clothEntities.SP_CalculateProductPrice(_pId).ToList()[0]).ToString();
                    spProductDescription.InnerText = product[0].Description;
                    spProductName.InnerText = product[0].Name;
                    int itemCount;
                    LoggedCustomer.IsProductExistPlusProductQuantity(_pId, out itemCount);
                    if (itemCount != 0)
                    {
                        ltlAlreadyExist.Text = string.Format("Already Added Quantity : {0} in the Cart ", itemCount);
                        ltlAlreadyExist.Visible = true;
                        stock = stock - itemCount;
                    }
                    else
                    {
                        ltlAlreadyExist.Visible = false;
                    }
                    //spProductInStock.InnerText = stock > 0 ? stock.ToString() : "0";
                    if (stock == 0)
                        txtQuantity.Enabled = false;
                    hdnstock.Value = stock.ToString();
                    ViewState["hdnStock"] = stock.ToString();
                    ViewState[Pid] = _pId;
                    if (!string.IsNullOrEmpty(product[0].ProductImage))
                    {
                        ProductImageMain = product[0].ProductImage;
                        ProductImageThumbNail = product[0].ProductImage;
                        imgMainThumbnail.ImageUrl = ProductImageThumbNail;
                        hyMainLarge.NavigateUrl = ProductImageMain;

                    }
                    liMainImage.Visible = IsMainProductImage;
                    ltHeaderMessage.Text = "Product Detail  >> " + product[0].Name;
                    var allDynamicCategories = (from prodCat in clothEntities.tbl_ProductCategories
                                                join
                                                    cat in clothEntities.tbl_Categories
                                                    on prodCat.PCCatId equals cat.CatId
                                                where prodCat.PCProductId == _pId
                                                select new
                                                           {
                                                               cat.CatName,
                                                           }).ToList();
                    if (allDynamicCategories.Count > 0)
                    {
                        lstCategories.DataSource = allDynamicCategories;
                        lstCategories.DataBind();
                    }
                    //trCategories.Visible = allDynamicCategories.Count > 0;
                    var allProductImages = (from prodImage in clothEntities.tbl_ProductImages
                                            where prodImage.ProductId == _pId
                                            select new
                                                       {
                                                           Large = _imagePath + prodImage.ImagePathLarge,
                                                           ThumbNail = _imagePath + prodImage.ImagePathThumbNail
                                                       }).ToList();
                    lstImages.DataSource = allProductImages;
                    lstImages.DataBind();
                    //trImages.Visible = allProductImages.Count > 0;
                    var allDynamicCat = (from dyCat in clothEntities.tbl_ProductDynamicCategories
                                         join dyCatVal in clothEntities.tbl_ProductDynamicAttributes
                                             on dyCat.PDCId equals dyCatVal.PDCId
                                         where dyCatVal.ProductID == _pId
                                         select new
                                                    {
                                                        DyCatName = dyCat.PCDName,
                                                        DyCatValue = dyCatVal.PDCValue
                                                    }).ToList();
                    lstDynamicCategories.DataSource = allDynamicCat;
                    lstDynamicCategories.DataBind();

                }
                else
                    Response.Redirect("~/Index.aspx");
            }
        }

        protected bool IsMainProductImage
        {
            get
            {
                return ProductImageThumbNail != string.Empty && ProductImageMain != null;
            }
        }

        private bool VerifyAddToCart()
        {
            
            long inStock;
            long quantity;
            if (ViewState["hdnStock"] != null && !string.IsNullOrEmpty(txtQuantity.Text) &&
                long.TryParse(ViewState["hdnStock"].ToString(), out inStock) && long.TryParse(txtQuantity.Text, out quantity) &&
                inStock >= quantity)
            {
                return true;
            }
            else
            {
                var messages = new List<string>()
                                   {
                                       "Must be Integer",
                                       "Must be less than stock quantity"
                                   };

                Utility.ShowPopUpMessage("Add Cart Error", messages, this.Page, true,
                                         "Please Care the Following for adding items to cart");
                return false;
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if(!VerifyAddToCart())
                return;
            if (Page.IsValid && ViewState[Pid] != null && long.TryParse(ViewState[Pid].ToString(), out _pId))
            {
                if (LoggedCustomer.AddToCart(_pId, int.Parse(txtQuantity.Text)))
                {
                    var messages = new List<string>() { string.Format("Product Item Successfully Added to Cart") };
                    var msg = new Messages()
                                  {
                                      MessageLists = messages,
                                      Title = "Cart Items Added"
                                  };
                    ProductDetail();

                    //Utility.ShowPopUpMessage("Cart Items Added", messages, this.Page, true);

                }
                else
                {
                    //var messages = new List<string>()
                    //                           {
                    //                               "CouldNot be added to Cart"
                    //                           };
                    //Utility.ShowPopUpMessage("Add To Cart Error", messages, this.Page, true);
                }
            }
            else
            {
                //var messages = new List<string>()
                //                               {
                //                                   "CouldNot be added to Cart"
                //                               };
                //Utility.ShowPopUpMessage("Add To Cart Error", messages, this.Page, true);
            }
            txtQuantity.Text = "";
        }

        protected void btnAddCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartItems.aspx");
        }
    }
}