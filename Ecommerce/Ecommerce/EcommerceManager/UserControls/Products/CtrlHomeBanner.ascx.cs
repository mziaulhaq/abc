using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class CtrlHomeBanner : UserControlBase
    {
        private long bannerId;
        private const string BannerId = "BannerId";
        private const string PImage = "HomeBannerImage";
        public readonly string UploadImagesDirectory = ConfigurationManager.AppSettings["HomeBannerImagePathAbsolute"];
        public readonly string UploadImagesUrl = ConfigurationManager.AppSettings["HomeBannerImagePathUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session[PImage] = null;
                if (Request.QueryString["bannerId"] != null && long.TryParse(Request.QueryString["bannerId"], out bannerId))
                {
                    if (Request.QueryString["Edit"] == "Edit")
                    {
                        BtnBannerEditUpdate.Text = "Update Banner";
                        PopulateProductDataForEdit();
                    }
                    else
                    {
                        BtnBannerEditUpdate.Text = "Add Banner";
                        //PopulateProductData();
                    }

                }

            }
        }

        private void PopulateProductDataForEdit()
        {

            using (var clothEntities = new ClothEntities())
            {
                var banner = clothEntities.tbl_HomePageBanners.FirstOrDefault(home => home.HPBId == bannerId);
                if (banner != null)
                {
                    bannerOrder.Visible = true;
                    lblBannerID.Text = "Banner Id : " + bannerId;
                    txtBannerTitle.Text = banner.Name;
                    rblIsFeatured.SelectedValue = EnablingAndDisabling.ReturnOneOrZero(banner.IsActive);
                    txtBannerLink.Text = banner.LinkPath;
                    txtBannerOrder.Text = banner.BannerOrder.ToString();
                    ImgHomeBanner.ImageUrl = UploadImagesUrl + banner.BannerImage;
                    Session[PImage] = banner.BannerImage;
                    ViewState["Edit"] = 1;
                    ViewState[BannerId] = banner.HPBId;
                }

            }

        }

        protected void BtnHiddenClicked(object sender, EventArgs e)
        {
            if (Session[PImage] != null)
            {
                ImgHomeBanner.ImageUrl = UploadImagesUrl + Session[PImage].ToString();
                hfImageUploaded.Value = "1";
            }
        }

        protected void AsyncFileUploadUploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {

                if (ProductImage.HasFile)
                {
                    if (txtBannerTitle.Text != string.Empty)
                    {
                        var dtNow = DateTime.Now;
                        var largeFileUrl = string.Empty;
                        var thmbFileUrl = string.Empty;
                        string productName = txtBannerTitle.Text;
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
                        Images.GenerateThumbnails(largefileSavedOn, thmbfileSavedOn, 142, 142);
                        Session[PImage] = largeFileUrl;
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

        protected void BtnAddEditClick(object sender, EventArgs e)
        {
            try
            {
                this.Page.Validate("HomeBanner");
                if (!Page.IsValid)
                {
                    return;
                }
                using (var clothEntities = new ClothEntities())
                {
                    if (ViewState["Edit"] != null && ViewState["Edit"].ToString() == "1")
                    {
                        bannerOrder.Visible = true;
                        long.TryParse(ViewState[BannerId].ToString(), out bannerId);
                        var homeBanner =
                            clothEntities.tbl_HomePageBanners.FirstOrDefault(home => home.HPBId == bannerId);
                        if (homeBanner != null)
                        {
                            homeBanner.BannerOrder = Convert.ToInt32(txtBannerOrder.Text);
                            homeBanner.LinkPath = txtBannerLink.Text;
                            homeBanner.Name = txtBannerTitle.Text;
                            homeBanner.IsActive = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsFeatured.SelectedValue);
                            homeBanner.BannerImage = Session[PImage].ToString();
                            if (clothEntities.SaveChanges() > 0)
                            {
                                Session[PImage] = null;
                                Response.Redirect("HomeBannerViewAll.aspx");
                            }

                        }
                    }
                    else
                    {
                        bannerOrder.Visible = false;
                        int maxOrderValue = clothEntities.tbl_HomePageBanners.Count() + 1;

                        var homeBanners = new tbl_HomePageBanners
                                              {
                                                  LinkPath = txtBannerLink.Text,
                                                  BannerImage = Session[PImage].ToString(),
                                                  CreatedBy = LoggedStoreId,
                                                  CreatedDate = DateTime.Now,
                                                  IsActive =
                                                      EnablingAndDisabling.ReturnBooleanFromOneOrZero(
                                                          rblIsFeatured.SelectedValue),
                                                  Name = txtBannerTitle.Text,
                                                  StoreId = LoggedStoreId,
                                                  BannerOrder = maxOrderValue
                                              };
                        clothEntities.tbl_HomePageBanners.Add(homeBanners);
                        if (clothEntities.SaveChanges() > 0)
                        {
                            Session[PImage] = null;
                            //var message = new Messages
                            //                  {Id = homeBanners.ProductID, Message = "Banner Image Successfully Added"};
                            //CreateContextMessage(message);
                            Response.Redirect("HomeBannerViewAll.aspx");
                        }
                        else
                        {
                            // ErrorOccured();
                            Response.Redirect("HomeBannerViewAll.aspx");
                        }
                    }

                }

            }
            catch (Exception)
            {


            }
        }

        protected void ImageUploadServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Session[PImage] == null)
                args.IsValid = false;
            else
            {
                args.IsValid = true;
            }
        }

    }
}