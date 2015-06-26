using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls.Products
{
    public partial class CtrlProducts : UserControlBase
    {
        private long _pId;
        private const string EditText = "Edit Product";
        private const string PImage = "ProductImage";
        public readonly string UploadImagesDirectory = ConfigurationManager.AppSettings["ProductImagePathAbsolute"];
        public readonly string UploadImagesUrl = ConfigurationManager.AppSettings["ProductImagePathUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !ProductImage.HasFile)
            {
                
                PopulateBrandsAndSalesTax();
                PopulateProductStatus();
                if ((Request.QueryString["PId"] != null && Request.QueryString["Edit"] != null) && long.TryParse(Request.QueryString["PId"], out _pId))
                {
                    PopulateProductForEdit();
                }
            }
        }
        private void PopulateProductForEdit()
        {
            using (var clothEntities = new ClothEntities())
            {
                var product =
                    clothEntities.tbl_Products.FirstOrDefault(pd => pd.ProductID == _pId && pd.StoreId == LoggedStoreId);
                if (product != null)
                {
                    txtInStock.Text = product.ProductInStock.ToString(CultureInfo.InvariantCulture);
                    txtProductDescription.Text = product.ProductDescription;
                    txtPriceDescription.Text = product.ProductPriceDescription;
                    txtProductName.Text = product.ProductName;
                    txtSale.Text = product.ProductSale.ToString(CultureInfo.InvariantCulture);
                    txtUnitPrice.Text = product.ProductUnitPrice.ToString(CultureInfo.InvariantCulture);
                    txtPurchasedPrice.Text = product.PurchasePrice.ToString();
                    ddlBrands.SelectedIndex =
                        ddlBrands.Items.IndexOf(ddlBrands.Items.FindByValue(product.ProductBrandId.ToString()));
                    ddlSalesTax.SelectedIndex =
                        ddlSalesTax.Items.IndexOf(ddlSalesTax.Items.FindByValue(product.SalesTaxId.ToString()));
                    rblIsFeatured.SelectedValue = EnablingAndDisabling.ReturnOneOrZero(Convert.ToBoolean(product.ProductIsFeatured));
                    rblIsActive.SelectedIndex =
                        rblIsActive.Items.IndexOf(rblIsActive.Items.FindByValue(product.ProductStatus.ToString()));
                    if (!string.IsNullOrEmpty(product.ProductImage))
                        EditImage.ImageUrl = UploadImagesUrl + product.ProductImage;
                    BtnAddEdit.Text = EditText;
                    CreateProductSessions(_pId, product.ProductName);
                    ProductAddedFirstStep();
                }
            }
        }

        private void ProductAddedFirstStep()
        {
            this.Page.GetType().InvokeMember("FirstStepDone", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, null);
        }

        private void CreateProductSessions(long pid, string name)
        {
            Session["PId"] = pid;
            Session["PName"] = name;
        }

        private void PopulateBrandsAndSalesTax()
        {
            using (var clothEntities = new ClothEntities())
            {
                var brands = clothEntities.tbl_Brands.Where(brand => brand.StoreId == LoggedStoreId && brand.IsActive).ToList();
                ddlBrands.DataSource = brands;
                ddlBrands.DataBind();
                ddlBrands.Items.Insert(0, new ListItem("Select", "Select"));
                var salesTax = clothEntities.tbl_SalesTaxRates.Where(sales => sales.StoreId == LoggedStoreId || sales.StoreId == null).ToList();
                ddlSalesTax.DataSource = salesTax;
                ddlSalesTax.DataBind();
                ddlSalesTax.Items.Insert(0, new ListItem("Select", "Select"));
            }

        }

        private void PopulateProductStatus()
        {
            rblIsActive.DataSource = ProductStatus.ListOfProductStatus();
            rblIsActive.DataBind();
        }

        protected void BtnAddEditClick(object sender, EventArgs e)
        {
            bool statusAddEdit = false;
            try
            {
                using (var clothEntities = new ClothEntities())
                {

                    if (ViewState["EditText"] != null && Session["PId"] != null && long.TryParse(Session["PId"].ToString(), out _pId))
                    {
                        var product =
                            clothEntities.tbl_Products.FirstOrDefault(
                                prod => prod.ProductID == _pId && prod.StoreId == LoggedStoreId);
                        if (product != null)
                        {
                            product.ProductInStock = Convert.ToInt64(txtInStock.Text);
                            product.ProductDescription = txtProductDescription.Text;
                            product.ProductPriceDescription = txtPriceDescription.Text;
                            product.ProductName = txtProductName.Text;
                            product.ProductSale = Convert.ToInt32(txtSale.Text);
                            product.ProductUnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                            product.ProductBrandId = Convert.ToInt32(ddlBrands.SelectedValue);
                            product.SalesTaxId = Convert.ToInt32(ddlSalesTax.SelectedValue);
                            product.ProductIsFeatured = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsFeatured.SelectedValue);
                            product.ProductStatus = Convert.ToInt32(rblIsActive.SelectedValue);
                            product.PurchasePrice = Convert.ToInt32(txtPurchasedPrice.Text);
                            if (Session[PImage] != null)
                                product.ProductImage = Session[PImage].ToString();
                            if (clothEntities.SaveChanges() > 0)
                            {
                                statusAddEdit = true;
                                CreateProductSessions(product.ProductID, product.ProductName);
                                Session[PImage] = null;
                                ProductAddedFirstStep();
                            }

                        }

                    }
                    else
                    {
                        var product = new tbl_Products
                                          {
                                              ProductInStock = Convert.ToInt64(txtInStock.Text),
                                              ProductDescription = txtProductDescription.Text,
                                              ProductPriceDescription = txtPriceDescription.Text,
                                              ProductName = txtProductName.Text,
                                              ProductSale = Convert.ToInt32(txtSale.Text),
                                              ProductUnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                                              ProductBrandId = Convert.ToInt32(ddlBrands.SelectedValue),
                                              SalesTaxId = Convert.ToInt32(ddlSalesTax.SelectedValue),
                                              ProductIsFeatured =
                                                  EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsFeatured.SelectedValue),
                                              ProductStatus = Convert.ToInt32(rblIsActive.SelectedValue),
                                              ProductInsertedBy = LoggedUserId,
                                              ProductInsertedDate = DateTime.Now,
                                              PurchasePrice = Convert.ToInt32(txtPurchasedPrice.Text),
                                              StoreId = LoggedStoreId
                                          };
                        if (Session[PImage] != null)
                            product.ProductImage = Session[PImage].ToString();
                        clothEntities.tbl_Products.Add(product);
                        if (clothEntities.SaveChanges() > 0)
                        {
                            if (product.ProductID > 0)
                            {
                                statusAddEdit = true;
                                CreateProductSessions(product.ProductID, product.ProductName);
                                Session[PImage] = null;

                            }
                        }
                    }
                    if (statusAddEdit)
                    {
                        ProductAddedFirstStep();
                        Response.Write(this.Page.GetType());
                        Response.Write(this.Page.GetType().InvokeMember("ChangeWizardStep", System.Reflection.BindingFlags.InvokeMethod, null,
                                    this.Page, new object[] { "Next" }));
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string str = string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (BtnAddEdit.Text == EditText)
            {
                ViewState["EditText"] = EditText;

            }
            else
            {
                ViewState["EditText"] = null;

            }
        }

        protected void AsyncFileUploadUploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {

                if (ProductImage.HasFile)
                {
                    if (txtProductName.Text != string.Empty)
                    {
                        var dtNow = DateTime.Now;
                        var largeFileUrl = string.Empty;
                        var thmbFileUrl = string.Empty;
                        string productName = txtProductName.Text;
                        string fileName = productName + "_" + dtNow.Ticks + System.IO.Path.GetExtension(e.FileName);
                        // File Name for the file to be saved
                        string fileToSave = productName + DateUtility.UniqueStringFromDate() + @"\Large\";
                        // This will give the absolute directory for the image to be saved
                        var largefileSavedOn = UploadImagesDirectory + fileToSave;
                        var thmbfileSavedOn = largefileSavedOn.Replace(@"\Large\", @"\ThmbNail\");
                        if (!Directory.Exists(largefileSavedOn))
                        {
                            Directory.CreateDirectory(largefileSavedOn);
                        }
                        if (!Directory.Exists(thmbfileSavedOn))
                        {
                            Directory.CreateDirectory(thmbfileSavedOn);
                        }
                        largefileSavedOn += fileName;
                        // Concatenating file Name to absolute directory, to get the full absolute path for the file
                        thmbfileSavedOn += fileName;
                        ProductImage.SaveAs(largefileSavedOn);
                        largeFileUrl = fileToSave.Replace(@"\", "/") + fileName;
                        thmbFileUrl = largeFileUrl.Replace(@"/Large/", "/ThmbNail/");
                        System.Drawing.Image img = System.Drawing.Image.FromFile(largefileSavedOn);
                        Images.GenerateThumbnails(largefileSavedOn, thmbfileSavedOn, 200, 176);
                        Session[PImage] = thmbFileUrl;
                    }
                    else
                    {
                        ProductImage.ClearFileFromPersistedStore();
                        ProductImage.ClearAllFilesFromPersistedStore();
                    }

                }
            }

            catch
            {

            }

        }

        protected void BtnHiddenClicked(object sender, EventArgs e)
        {
            if (Session[PImage] != null)
            {
                EditImage.ImageUrl = UploadImagesUrl + Session[PImage].ToString();
            }
        }
    }
}


