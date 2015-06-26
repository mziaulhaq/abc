using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls.Pages
{
    public partial class CtrlPages : UserControlBase
    {
        public int PageId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.MakeLabelInvisible(ref lblMessage);
            if (hfPageName.Value != "")
            {
                PageId = Convert.ToInt32(hfPageName.Value);
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["PId"] != null && int.TryParse(Request.QueryString["PId"], out PageId))
                {
                    PopulatePageDetails();
                }
            }
        }
        private void PopulatePageDetails()
        {

            using (var clothEntities = new ClothEntities())
            {
                var page = clothEntities.tbl_Pages.FirstOrDefault(pg => pg.PageId == PageId && pg.StoreId == LoggedStoreId);
                if (page != null)
                {

                    txtPageName.Text = page.PageName;
                    txtDetails.Text = page.Details;
                    txtPageMeta.Text = page.Meta;
                    rblIsActive.SelectedIndex = page.Status ? 0 : 1;
                    hfPageName.Value = PageId.ToString();

                }
            }
        }
        protected void AddEditPage(object sender, EventArgs e)
        {
            using (var clothEntities = new ClothEntities())
            {
                if (hfPageName.Value != string.Empty)
                {
                    var page = clothEntities.tbl_Pages.FirstOrDefault(pg => pg.PageId == PageId && pg.StoreId==LoggedStoreId);
                    if (page != null)
                    {
                        var pageUpdate = new tbl_PagesUpdation()
                                             {
                                                 PageId = page.PageId,
                                                 Status = page.Status,
                                                 PageName = page.PageName,
                                                 Details = page.Details,
                                                 Meta = page.Meta,
                                                 UpdateDate =
                                                     DateUtility.ReturnNotNullDate(page.UpdateDate, page.CreatedDate),
                                                 UpdatedBy = LoggedUserId
                                                 
                                                
                                             };
                        page.PageName = txtPageName.Text;
                        page.Details = txtDetails.Text;
                        page.Meta = txtPageMeta.Text;
                        page.Status = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue);
                        page.UpdateDate = DateTime.Now;
                        page.UpdatedBy = LoggedUserId;
                        clothEntities.tbl_PagesUpdation.Add(pageUpdate);
                        if (clothEntities.SaveChanges() != 0)
                        {
                            Utility.ShowMessage(ref lblMessage, true, "Page Information Updated Successfully");
                        }
                        else
                            Utility.ShowMessage(ref lblMessage, true, "Page Information couldn't be Updated Successfully");
                        
                    }
                    else
                    {
                        Utility.ShowMessage(ref lblMessage, true, "Page data is invalid");
                    }
                    ResetControls();
                }
                else
                {
                     var page = new tbl_Pages()
                                             {
                                                 Status = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue),
                                                 PageName = txtPageName.Text,
                                                 Details = txtDetails.Text,
                                                 Meta = txtPageMeta.Text,
                                                 CreatedBy = LoggedUserId,
                                                 CreatedDate = DateTime.Now,
                                                 StoreId = LoggedStoreId

                                             };
                    clothEntities.tbl_Pages.Add(page);

                     if (clothEntities.SaveChanges() > 0)
                     {
                         Utility.ShowMessage(ref lblMessage, true, "Page Information Saved Successfully");
                     }
                     else
                         Utility.ShowMessage(ref lblMessage, true, "Page Information couldn't be Saved Successfully");
                    ResetControls();
                }
            }
        }

        private void ResetControls()
        {
            txtPageMeta.Text = string.Empty;
            txtPageName.Text = string.Empty;
            txtDetails.Text = string.Empty;
            rblIsActive.ClearSelection();
        }
    }
}