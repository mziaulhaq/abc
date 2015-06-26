using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Ecommerce.App_Start;
using System.IO;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.UserControls.Products
{
    public partial class CtrlUploadProductImages : UserControlBase
    {
        public readonly string UploadImagesDirectory = ConfigurationManager.AppSettings["ProductImagePathAbsolute"];
        public readonly string UploadImagesUrl = ConfigurationManager.AppSettings["ProductImagePathUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckFileUploads();
            }
        }

        protected void UploadImagesComplete(object sender, AjaxFileUploadEventArgs e)
        {
            if (Session["PId"] != null)
            {
                try
                {
                    if (CheckFileUploads() <= 4)
                    {
                        var dtNow = DateTime.Now;
                        string productName = Session["PName"].ToString().Replace(' ', '_');
                        string productId = Session["PId"].ToString();
                        string fileName = productName + productId + "_" + dtNow.Ticks + System.IO.Path.GetExtension(e.FileName);
                        // File Name for the file to be saved
                        string fileToSave = productName + productId + @"\Large\";
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

                        productImagesUpload.SaveAs(largefileSavedOn);
                        string largeFileUrl = fileToSave.Replace(@"\", "/") + fileName;
                        string thmbFileUrl = largeFileUrl.Replace(@"/Large/", "/ThmbNail/");
                        System.Drawing.Image img = System.Drawing.Image.FromFile(largefileSavedOn);
                        var thumbnail = new Bitmap(img, 120, 120);
                        thumbnail.Save(thmbfileSavedOn, img.RawFormat);

                        using (var clothEntities = new ClothEntities())
                        {
                            var productImages = new tbl_ProductImages()
                                                    {
                                                        ImagePathLarge = largeFileUrl,
                                                        ImagePathThumbNail = thmbFileUrl,
                                                        ProductId = Convert.ToInt64(Session["PId"].ToString())
                                                    };
                            clothEntities.tbl_ProductImages.Add(productImages);
                            clothEntities.SaveChanges();
                        }
                    }

                }
                catch (Exception)
                {

                }
            }

        }


        protected void ButtonFileUploadClicked(object sender, EventArgs e)
        {
            CheckFileUploads();
        }
        private int CheckFileUploads()
        {
            int id = 0;
            if (Session["PId"] != null)
            {
                long pid = Convert.ToInt64(Session["PId"].ToString());
                using (var clothEntities = new ClothEntities())
                {
                    id = clothEntities.tbl_ProductImages.Count(img => img.ProductId == pid);

                    if (id == 4)
                    {
                        productImagesUpload.Visible = false;
                        limitReached.Visible = true;

                    }
                    else if (id < 4)
                    {
                        productImagesUpload.Visible = true;
                        limitReached.Visible = false;
                        productImagesUpload.MaximumNumberOfFiles = 4 - id;

                    }
                }
            }
            return id;
        }

    }
}