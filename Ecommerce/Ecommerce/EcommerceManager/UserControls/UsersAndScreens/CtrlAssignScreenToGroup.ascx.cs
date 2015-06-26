using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;


namespace Ecommerce.EcommerceManager.UserControls.UsersAndScreens
{
    public partial class CtrlAssignScreenToGroup : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateScreenNames();
                PopulateGroupNames();
            }
            Utility.MakeLabelInvisible(ref lblMessage);
        }

        private void PopulateScreenNames()
        {
            using (var clothEntities = new ClothEntities())
            {
                CkhScreens.DataSource = clothEntities.tbl_Screens.ToList();
                CkhScreens.DataBind();
            }
        }

        private void PopulateGroupNames()
        {
            using (var clothEntities = new ClothEntities())
            {

                ddlGroupName.DataSource = clothEntities.tbl_Groups.ToList();
                ddlGroupName.DataBind();
                ddlGroupName.Items.Insert(0,new ListItem("Select","Select"));
            }
        }

        protected void CancelClicked(object sender, EventArgs e)
        {
            ddlGroupName.SelectedIndex = 0;
            CkhScreens.ClearSelection();

        }

        protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateScreens();
        }

        private void PopulateScreens()
        {
            CkhScreens.ClearSelection();
            if (ddlGroupName.SelectedIndex != 0)
            {
                int groupId = Convert.ToInt32(ddlGroupName.SelectedValue);
                if (groupId != 0)
                {
                    using (var clothEntities = new ClothEntities())
                    {
                        var screenTogroup = (from sg in clothEntities.tbl_ScreensToGroup
                                             where sg.GroupId == groupId && sg.StoreId ==LoggedStoreId
                                             select sg.ScreenId).ToList();
                        foreach (ListItem li in CkhScreens.Items)
                        {
                            int id;
                            if (int.TryParse(li.Value, out id) && screenTogroup.Contains(id))
                                li.Selected = true;
                        }
                    }
                }
            }
            
        }

        protected void AddEditAssignSceenGroupClicked(object sender, EventArgs e)
        {
            var selectedScreens = new List<int>();
            var unselectedScreens = new List<int>();
            int groupId = Convert.ToInt32(ddlGroupName.SelectedValue);
            foreach (ListItem listItem in CkhScreens.Items)             // Getting list of selected and unselected screens 
            {
                int id;
                if (listItem.Selected && int.TryParse(listItem.Value,out id))
                {
                    selectedScreens.Add(id);
                }
                else if(!listItem.Selected && int.TryParse(listItem.Value,out id))
                {
                    unselectedScreens.Add(id);
                }
            }
            using (var clothEntities = new ClothEntities())
            {
                var selectedScreenFromDb =
                    (clothEntities.tbl_ScreensToGroup.Where(
                        stg => selectedScreens.Contains(stg.ScreenId) &&
                        stg.GroupId == groupId && stg.StoreId == LoggedStoreId)).ToList();         // Here i am getting all the selected screens from db if exist
                var unSelectedScreensFromDb =
                     (clothEntities.tbl_ScreensToGroup.Where(
                        stg => unselectedScreens.Contains(stg.ScreenId) &&
                        stg.GroupId == groupId && stg.StoreId==LoggedStoreId)).ToList();        // Here i am getting all the unselected screens from db if already exist
                foreach (var tblScreensToGroup in unSelectedScreensFromDb)
                {
                    clothEntities.tbl_ScreensToGroup.Remove(tblScreensToGroup);
                }
                var screentogroupIds= selectedScreenFromDb.Select(tblScreensToGroup => tblScreensToGroup.ScreenId).ToList();
                foreach (var screentogroupId in selectedScreens.Where(sqi => !screentogroupIds.Contains(sqi)))
                {
                   
                    {
                        var screentogroup = new tbl_ScreensToGroup()
                                                {
                                                    StoreId = LoggedStoreId,
                                                    GroupId = groupId,
                                                    ScreenId = screentogroupId
                                                    
                                                };
                        clothEntities.tbl_ScreensToGroup.Add(screentogroup);
                    }
                }
                    
                if(clothEntities.SaveChanges() > 0)
                {
                    Utility.ShowMessage(ref lblMessage, true, "Screen Assignment Has Been Successfully Updated");
                    PopulateScreens();
                   
                }
                else
                {

                    Utility.ShowMessage(ref lblMessage, false, "Screen Assignment Couldn't be Successfully Updated");
                }
                             
            }


        }

       
    }
}