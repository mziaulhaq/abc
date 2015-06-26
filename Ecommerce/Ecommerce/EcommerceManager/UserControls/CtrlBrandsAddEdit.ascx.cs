using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls
{
    public partial class CtrlBrandsAddEdit : System.Web.UI.UserControl
    {
        private const string EditText = "Edit Brand";
        public readonly string UploadImagesDirectory = ConfigurationManager.AppSettings["BrandImagePathAbsolute"] ;
        public readonly string UploadImagesUrl = ConfigurationManager.AppSettings["BrandImagePathUrl"] ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["BrandImage"] = null;
                int id = 0;
                if (Request.QueryString["Edit"] != null && Request.QueryString["Id"] != null && int.TryParse(Request.QueryString["Id"], out id))
                {
                    BtnAddEdit.Text = EditText;
                    PopulateBrand(id);

                }
            }

        }
        private void PopulateBrand(int id)
        {
            using (var clothEntities = new ClothEntities())
            {
                var tblBrand = clothEntities.tbl_Brands.FirstOrDefault(brand => brand.BrandId == id);
                if (tblBrand != null)
                {
                    txtBrandName.Text = tblBrand.BrandName;
                    txtDescription.Text = tblBrand.BrandDescription;
                    rblIsActive.SelectedValue =
                        EnablingAndDisabling.ReturnOneOrZero(tblBrand.IsActive);
                    EditImage.ImageUrl = UploadImagesUrl + tblBrand.BrandImage;
                    ViewState[EditText] = id;
                }
            }

        }

        protected void AddEditBrand(object sender, EventArgs e)
        {
            int id = 0;
            if (BtnAddEdit.Text == EditText && ViewState[EditText] != null && int.TryParse(ViewState[EditText].ToString(), out id))
            {

                using (var clothEntities = new ClothEntities())
                {
                    var brands =
                        clothEntities.tbl_Brands.FirstOrDefault(brand => brand.BrandId == id);
                    if (brands != null)
                    {
                        var brandsUpadtion = new tbl_BrandsUpdation()
                        {
                            BrandDescription = brands.BrandDescription,
                            BrandId = brands.BrandId,
                            BrandsModifiedBy =
                                brands.BrandLastUpdatedBy ??
                                brands.BrandUploadedBy,
                            BrandName = brands.BrandName,
                            IsActive = brands.IsActive,
                            BrandImage = brands.BrandImage,
                            BrandsModifiedDate = DateTime.Now
                        };

                        brands.IsActive = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue);
                        brands.BrandDescription = txtDescription.Text;
                        brands.BrandName = txtBrandName.Text;
                        if (Session["BrandImage"] != null)
                            brands.BrandImage = Session["BrandImage"].ToString();
                        brands.BrandLastUpdatedBy = LoggedUser.GetUserId();
                        brands.BrandLastUpdatedDate = DateTime.Now;
                        clothEntities.tbl_BrandsUpdation.Add(brandsUpadtion);
                        int rowsUpdated = clothEntities.SaveChanges();
                        if (rowsUpdated > 0)
                        {
                            Utility.ShowMessage(ref lblMessage, true, "Brand Information Has Been Successfully Updated");
                            ResetAllFields();
                        }
                        else
                        {
                            Utility.ShowMessage(ref lblMessage, false, "Brand Information Couldn't be Successfully Updated");
                            ResetAllFields();
                        }
                    }
                }

            }
            else
            {
                using (var clothEntities = new ClothEntities())
                {
                    var tblBrand = new tbl_Brands()
                    {
                        BrandName = txtBrandName.Text,
                        BrandDescription = txtDescription.Text,
                        IsActive = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue),
                        StoreId = LoggedUser.GetStoreId(),

                        BrandUploadedBy = LoggedUser.GetUserId(),
                        BrandUploadedDate = DateTime.Now
                    };
                    if (Session["BrandImage"] != null)
                        tblBrand.BrandImage = Session["BrandImage"].ToString();
                    clothEntities.tbl_Brands.Add(tblBrand);
                    if (clothEntities.SaveChanges() > 0)
                    {
                        ResetAllFields();
                        Utility.ShowMessage(ref lblMessage,true,"Brand Information Added Successfully");
                    }
                    else
                    {
                        ResetAllFields();
                        Utility.ShowMessage(ref lblMessage, true, "Brand Information Couldn't be Added Successfully");
                    }
                }
            }
        }

        private void ResetAllFields()
        {
            txtBrandName.Text = "";
            txtDescription.Text = "";
            rblIsActive.ClearSelection();
            ViewState[EditText] = null;
            Session["BrandImage"] = null;
            BtnAddEdit.Text = "Add Brand";
        }

        protected void AsyncFileUploadUploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            
            if(BrandImage.HasFile)
            {
                try
                {
                        var FileName = txtBrandName.Text; 
                        var dtNow = DateTime.Now;
                        var largeFileUrl = string.Empty;
                        var thmbFileUrl = string.Empty;
                        string productName = FileName != string.Empty ? FileName : DateUtility.UniqueStringFromDate();
                        string fileName = productName  + System.IO.Path.GetExtension(e.FileName);
                        // File Name for the file to be saved
                        string fileToSave =  @"\original\";
                        // This will give the absolute directory for the image to be saved
                        var largefileSavedOn = UploadImagesDirectory + fileToSave;
                        var thmbfileSavedOn = largefileSavedOn.Replace(@"\original\", @"\");
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
                        BrandImage.SaveAs(largefileSavedOn);
                        largeFileUrl = fileToSave.Replace(@"\", "/") + fileName;
                        thmbFileUrl = largeFileUrl.Replace(@"/original/", "/");
                        Images.GenerateThumbnails(largefileSavedOn, thmbfileSavedOn, 312, 140);
                        Session["BrandImage"] = thmbFileUrl;
                        EditImage.ImageUrl = "";
                        EditImage.Visible = false;
                    //EditImage.ImageUrl = UploadImagesUrl + thmbFileUrl;
                }
                catch
                {

                }
            }
        }
    }
}