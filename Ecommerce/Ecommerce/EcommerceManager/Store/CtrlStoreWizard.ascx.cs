using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;
using Microsoft.Web.Administration;
using Org.BouncyCastle.Ocsp;

namespace Ecommerce.EcommerceManager.Store
{
    public partial class CtrlStoreWizard : UserControlFront
    {
        private string _tempName;
        private int _tempId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStep1PackageDetail();
                PopulateStep2TemplateDetail();
                PopulateBillingTerm();
                PopulateCountry();
                rblStatus.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Step-1 Package Information
        /// </summary>
        private void PopulateStep1PackageDetail()
        {
            int packageId;
            if (Request.QueryString["PackId"] != null && int.TryParse(Request.QueryString["PackId"], out packageId))
            {
                using (var db = new ClothEntities())
                {
                    lstPackage.DataSource = db.tbl_Packages.Where(x => x.PackageId == packageId).ToList();
                    lstPackage.DataBind();
                }
            }
        }
        /// <summary>
        /// Step-2 Template Selection
        /// </summary>
        private void PopulateStep2TemplateDetail()
        {
            using (var db = new ClothEntities())
            {
                rptTemplates.DataSource = db.tbl_Templates.ToList();
                rptTemplates.DataBind();
            }
        }

        /// <summary>
        /// Step-3 Populate Billing Terms in radio button list
        /// </summary>
        private void PopulateBillingTerm()
        {
            using (var db = new ClothEntities())
            {
                //var data = (from bterm in db.tbl_BillingTerm
                //            select new
                //            {
                //                bterm.BTId,
                //                BillingTerm = string.Format("{0},{1}: USD/month", bterm.BTTitle, Convert.ToString(bterm.BTBill))
                //            }).ToList();
                var raw = (from bterm in db.tbl_BillingTerm
                           select new
                           {
                               bterm.BTId,
                               bterm.BTTitle,
                               bterm.BTBill
                           }).ToList();

                var data = raw.Select(bterm => new
                {
                    bterm.BTId,
                    BillingTerm = string.Format(
                        "{0} {1}: USD/month",
                        bterm.BTTitle,
                        bterm.BTBill)
                });
                rblBillingTerm.DataSource = data;
                rblBillingTerm.DataBind();
                rblBillingTerm.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Step-3 Populate Country in dropdown list
        /// </summary>
        private void PopulateCountry()
        {
            using (var db = new ClothEntities())
            {
                ddlStoreCountry.DataSource = db.tbl_Country.ToList();
                ddlStoreCountry.DataBind();
                ddlStoreCountry.Items.Insert(0, "--Selecte Country--");
            }
        }


        protected override void OnPreRender(EventArgs e)
        {

            if (wzStoreRegistration.ActiveStepIndex == 1)
            {
                wzStoreRegistration.HeaderText = "Step 2-Select Template";
            }
            if (wzStoreRegistration.ActiveStepIndex == 2)
            {
                wzStoreRegistration.HeaderText = "Step 3-Complete Form";
            }
            if (wzStoreRegistration.ActiveStepIndex == 3)
            {
                wzStoreRegistration.HeaderText = "Step 4-Summery";
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// Next Button event of wizard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NextButtonClicked(object sender, WizardNavigationEventArgs e)
        {

            if (e.CurrentStepIndex == 2)
            {
                PopulateSummeryData();
            }
            var imgUrl = lblTemplateId.Text;
            var x = txtTemplateId.Text;
        }

        /// <summary>
        /// Step-4 Show Summery
        /// </summary>
        private void PopulateSummeryData()
        {
            _tempName = string.Empty;
            _tempName = txtTemplateId.Text.Substring(txtTemplateId.Text.LastIndexOf("/", System.StringComparison.Ordinal) + 1);
            hdTemplateId.Value = GetTemplateIdByName(_tempName).ToString();
            _tempId = Convert.ToInt32(hdTemplateId.Value);
            int packageId;
            if (Request.QueryString["PackId"] != null && int.TryParse(Request.QueryString["PackId"], out packageId))
            {

                lblOwnerName.Text = txtOwnerName.Text;
                lblOwnerEmail.Text = txtOwnerEmail.Text;
                lblOwnerContact.Text = txtOwnerContact.Text;
                lblBusinessName.Text = txtStoreName.Text;
                lblDomain.Text = txtDomainName.Text;
                lblPackage.Text = GetPackageNameById(packageId);
                lblBillingTerm.Text = GetBillingTermById(Convert.ToInt32(rblBillingTerm.SelectedValue));
                lblCountry.Text = GetCountryNameById(Convert.ToInt32(ddlStoreCountry.SelectedValue));
                lblCity.Text = txtStoreCity.Text;
                lblStoreStatus.Text = rblStatus.SelectedItem.ToString();
                lblPostCode.Text = txtStorePostCode.Text;
                lblContact.Text = txtStoreContact.Text;
                lblAddress.Text = txtStoreAddress.Text;
                imgTemplate.ImageUrl = ConfigurationManager.AppSettings["GetTemplates"] + "/" + GetTemplateNameById(Convert.ToInt32(hdTemplateId.Value));
            }
        }

        protected void FinishButtonClicked(object sender, WizardNavigationEventArgs e)
        {
            int x = Convert.ToInt32(hdTemplateId.Value);
            using (var db = new ClothEntities())
            {
                var stores = new tbl_Stores
                {
                    StoreName = lblBusinessName.Text,
                    StoreOwnerName = lblOwnerName.Text,
                    StoreOwnerContact = lblOwnerContact.Text,
                    StoreOwnerEmail = lblOwnerEmail.Text,
                    StoreDomainName = lblDomain.Text,
                    TemplateId = Convert.ToInt32(hdTemplateId.Value),
                    PackageId = Convert.ToInt32(Request.QueryString["PackId"]),
                    StoreLogo = null,
                    StoreStatus = rblStatus.SelectedItem.ToString() == "Enabled",
                    StoreStatusComment = null,
                    StoreStatusUpdatedDate = null,
                    StoreStatusUpdatedby = null,
                    BillingTermId = Convert.ToInt32(rblBillingTerm.SelectedValue),
                    CountryId = Convert.ToInt32(ddlStoreCountry.SelectedValue),
                    StoreCity = lblCity.Text,
                    StorePostCode = lblPostCode.Text,
                    StoreContact = lblContact.Text,
                    SotreAddress = lblAddress.Text
                };
                db.tbl_Stores.Add(stores);
                if (db.SaveChanges() > 0)
                {
                    if (!IsWebsiteExists(txtStoreName.Text))
                    {
                        Test();
                        //ConfigureSiteInIis();
                        //IisVirtualConfiguration.CreateApplicaiton("Default Web Site", "http://localhost:40433/EcommerceManager/EcomerceHome",
                        //    "G:\\projects\\MyEcommerce\\Ecommerce\\Ecommerce", "testpool");
                    }
                    else
                    {
                        //lblMessage.Text = "Site Could not be created. Please check the detail";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                    }

                }
            }
        }



        /// <summary>
        /// Configuring the new store created on IIS
        /// </summary>
        //private void ConfigureSiteInIis()
        //{
        //    string strWebsitename = txtStoreName.Text; // abc
        //    const string strApplicationPool = "DefaultAppPool"; // set your deafultpool :4.0 in IIS
        //    string strhostname = txtDomainName.Text; //abc.com
        //    const string stripaddress = "localhost:40411"; // ip address
        //    string bindinginfo = stripaddress + ":80:" + strhostname;
        //    var serverMgr = new ServerManager();
        //    //Site mySite = serverMgr.Sites.Add(txtStoreName.Text, "http", bindinginfo, "C:\\inetpub\\wwwroot\\yourWebsite");
        //    Site mySite = serverMgr.Sites.Add(txtStoreName.Text, "http", bindinginfo, "G:\\projects\\MyEcommerce\\Ecommerce\\Ecommerce\\Ecommerce");
        //    mySite.ApplicationDefaults.ApplicationPoolName = strApplicationPool;
        //    mySite.TraceFailedRequestsLogging.Enabled = true;
        //    mySite.TraceFailedRequestsLogging.Directory = "C:\\inetpub\\customfolder\\site";
        //    serverMgr.CommitChanges();
        //    lblMessage.Text = "New website  " + strWebsitename + " added sucessfully";
        //    lblMessage.ForeColor = System.Drawing.Color.Green;
        //}

        private void Test()
        {
            try
            {
                var serverMgr = new ServerManager();
                string strWebsitename = txtStoreName.Text; // abc
                const string strApplicationPool = "DefaultAppPool"; // set your deafultpool :4.0 in IIS
                string strhostname = txtDomainName.Text; //abc.com
                const string stripaddress = "http://localhost/Ecommerce/"; // ip address
                string bindinginfo = stripaddress + ":80:" + strhostname;

                //check if website name already exists in IIS
                Boolean bWebsite = IsWebsiteExists(strWebsitename);
                if (!bWebsite)
                {
                    Site mySite = serverMgr.Sites.Add(strWebsitename.ToString(), "http", bindinginfo, "C:\\inetpub\\wwwroot\\yourWebsite");
                    mySite.ApplicationDefaults.ApplicationPoolName = strApplicationPool;
                    mySite.TraceFailedRequestsLogging.Enabled = true;
                    mySite.TraceFailedRequestsLogging.Directory = "C:\\inetpub\\customfolder\\site";
                    serverMgr.CommitChanges();
                    lblmsg.Text = "New website  " + strWebsitename + " added sucessfully";
                }
                else
                {
                    lblmsg.Text = "Name should be unique, " + strWebsitename + "  is already exists. ";
                }
            }
            catch (Exception ae)
            {
                Response.Redirect(ae.Message);
            }

        }


        /// <summary>
        /// Check is website with same name already exist or not?
        /// </summary>
        /// <param name="strWebsitename"></param>
        /// <param name="serverMgr"></param>
        /// <returns></returns>
        public bool IsWebsiteExists(string strWebsitename)
        {
            var serverMgr = new ServerManager();
            Boolean flagset = false;
            SiteCollection sitecollection = serverMgr.Sites;
            foreach (Site site in sitecollection)
            {
                if (site.Name == strWebsitename.ToString())
                {
                    flagset = true;
                    break;
                }
            }
            return flagset;
        }
    }
}