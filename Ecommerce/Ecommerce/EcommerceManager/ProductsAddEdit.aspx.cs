using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Ecommerce.App_Start;

namespace Ecommerce.EcommerceManager
{
    public partial class ProductsAddEdit : AdminBasePage
    {
        public readonly string UploadImagesDirectory = ConfigurationManager.AppSettings["ProductImagePathAbsolute"];
        public readonly string UploadImagesUrl = ConfigurationManager.AppSettings["ProductImagePathUrl"];
        private const string PImage = "ProductImage";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        public void ChangeWizardStep(object move)
        {
            string movement = move.ToString();
            if (movement == "Next")
                MakeToNext();
            else if (movement == "First")
                ProductWizard.ActiveStepIndex = 0;
            else if (movement == "4")
                ProductWizard.ActiveStepIndex = 4;
        }
        public void MakeToNext()
        {
            var wizardSteps = ProductWizard.WizardSteps;
            if (ProductWizard.ActiveStep == null)
                return;
            int activeStepIndex = wizardSteps.IndexOf(ProductWizard.ActiveStep);
            int wizardStepCounts = wizardSteps.Count;
            if (activeStepIndex < wizardStepCounts - 1 && ProductWizard.WizardSteps[activeStepIndex + 1] != null)
            {
                ProductWizard.MoveTo(ProductWizard.WizardSteps[activeStepIndex + 1]);
                FirstStepDone();
            }

        }
        public int ReturnActiveIndex()
        {
            return ProductWizard.ActiveStepIndex;
        }
        public void FirstStepDone()
        {
            ViewState["FirstStepDone"] = 1;
            if (Request.QueryString["PId"] == null)
                Response.Redirect("ProductsAddEdit.aspx?PId=" + Session["PId"].ToString() + "&Edit=Edit");
        }
        public void MakeToPrevious()
        {

        }
        protected void WizardPreRender(object sender, EventArgs e)
        {
            var sideBarList = ProductWizard.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
            if (sideBarList == null) return;
            sideBarList.DataSource = ProductWizard.WizardSteps;
            sideBarList.DataBind();
            if (ProductWizard.WizardSteps[0] == ProductWizard.ActiveStep && ViewState["FirstStepDone"] == null)
            {
                ProductWizard.StartNextButtonStyle.CssClass = "DontShow";
            }
        }
        protected string GetClassForWizardStep(object wizardStep)
        {
            var step = wizardStep as WizardStep;

            if (step == null)
            {
                return "";
            }
            int stepIndex = ProductWizard.WizardSteps.IndexOf(step);

            if (stepIndex < ProductWizard.ActiveStepIndex)
            {
                return "prevStep";
            }
            else if (stepIndex > ProductWizard.ActiveStepIndex)
            {
                return "nextStep";
            }
            else
            {
                return "currentStep";
            }
        }

        protected void ProductWizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            var wizardSteps = ProductWizard.WizardSteps;
            if (ProductWizard.ActiveStep == null)
                return;
            int activeStepIndex = wizardSteps.IndexOf(ProductWizard.ActiveStep);
            int wizardStepCounts = wizardSteps.Count;
            if (activeStepIndex == 1)
                ProductWizard.MoveTo(ProductWizard.WizardSteps[0]);
        }

        protected void ProductWizardFinishButtonClicked(object sender, WizardNavigationEventArgs e)
        {
            Session["PId"] = null;
            Session["PName"] = null;
            Session[PImage] = null;
            ProductWizard.ActiveStepIndex = 0;
            Response.Redirect("ProductViewAll.aspx");
        }

        protected void btnHidden_Click(object sender, EventArgs e)
        {
            if (hdnNavText.Value.ToLower() == "add product")
            {
                ProductWizard.ActiveStepIndex = 0;
            }
            else if (hdnNavText.Value.ToLower() == "add categories")
            {
                ProductWizard.ActiveStepIndex = 1;
            }
            else if (hdnNavText.Value.ToLower() == "color and gender")
            {
                ProductWizard.ActiveStepIndex = 2;
            }
            else if (hdnNavText.Value.ToLower() == "dynamic properties")
            {
                ProductWizard.ActiveStepIndex = 3;
            }
            else if (hdnNavText.Value.ToLower() == "upload images")
            {
                ProductWizard.ActiveStepIndex = 4;
            }
        }
    }
}