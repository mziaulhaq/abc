using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls
{
    public partial class CtrlBrandUpdateInformation : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                if (Request.QueryString["Id"] != null && int.TryParse(Request.QueryString["Id"], out id))
                {
                    PopulateBrandsUpdationHistory(id);
                }
            }
        }
        private void PopulateBrandsUpdationHistory(int id)
        {
            int userId = LoggedUser.GetUserId();
            int storeId = LoggedUser.GetStoreId();
            using (var clothEntities = new ClothEntities())
            {

                var brandsToUserInformation = clothEntities.BrandToUserInformation(id, storeId).FirstOrDefault();
                if (brandsToUserInformation != null)
                {
                    lblBrandDes.InnerText = brandsToUserInformation.BrandDescription;
                    lblBrandName.InnerText = brandsToUserInformation.BrandName;
                    lblBrandStatus.InnerText =
                        EcommerceUtilities.EnablingAndDisabling.EnableDisableLiteral(
                            brandsToUserInformation.IsActive);
                    lblModifiedOn.InnerText =
                        DateUtility.ReturnNotNullDate(brandsToUserInformation.BrandLastUpdatedDate,
                                                      brandsToUserInformation.BrandUploadedDate).ToShortDateString();
                    lblUserName.InnerText = brandsToUserInformation.UserFullName;

                }

                var brandUpdateInformation = clothEntities.ReturnBrandsUpdateInformation(id, userId).ToList();
                GridView1.DataSource = brandUpdateInformation;
                GridView1.DataBind();

            }
        }
    }
}