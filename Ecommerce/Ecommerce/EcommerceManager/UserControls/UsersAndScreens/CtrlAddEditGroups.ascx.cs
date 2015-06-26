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
    public partial class CtrlAddEditGroups : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateGroups();
            Utility.MakeLabelInvisible(ref lblMessage);
        }

        protected void GdvCancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GdvGroup.EditIndex = -1;
            PopulateGroups();

        }
        private void PopulateGroups()
        {
            using (var clothEntities = new ClothEntities())
            {
                var groups = clothEntities.tbl_Groups.Where(gp => gp.StoreId == LoggedStoreId).ToList();
                GdvGroup.DataSource = groups;
                GdvGroup.DataBind();
            }
        }

        protected void CancelClicked(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtGroupName.Text = "";
            rblIsActive.ClearSelection();
            BtnAddEdit.Text = "Add Group";
            hdnEdit.Value = "0";


        }
        protected void AddEditGroup(object sender, EventArgs e)
        {
            using (var clothEntities = new ClothEntities())
            {
                int groupId;
                if (hdnEdit.Value != "0" && BtnAddEdit.Text == "Edit Group" && int.TryParse(hdnEdit.Value, out groupId))
                {
                    var group = clothEntities.tbl_Groups.FirstOrDefault(gp => gp.GroupId == groupId);
                    if (group != null)
                    {
                        group.GroupName = txtGroupName.Text;
                        group.GroupDescription = txtDescription.Text;
                        group.Status = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue);
                        if (clothEntities.SaveChanges() > 0)
                        {
                            Utility.ShowMessage(ref lblMessage, true, "Group Information Has Been Successfully Updated");
                            PopulateGroups();
                        }
                        else
                        {
                            Utility.ShowMessage(ref lblMessage, false, "Error Occurred While Updating Group Information ");
                        }
                    }
                    else
                    {
                        Utility.ShowMessage(ref lblMessage, false, "No Information to fulfill the update request");
                    }

                }
                else
                {
                    var group = new tbl_Groups()
                                    {
                                        GroupName = txtGroupName.Text,
                                        GroupDescription = txtDescription.Text,
                                        StoreId = LoggedStoreId,
                                        Status = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue),
                                        GroupCreatedBy = LoggedUserId,
                                        GroupCreatedDate = DateTime.Now
                                    };
                    clothEntities.tbl_Groups.Add(group);
                    if (clothEntities.SaveChanges() > 0)
                    {
                        Utility.ShowMessage(ref lblMessage, true, "Group Information Has Been Successfully Added");

                    }
                    else
                    {
                        Utility.ShowMessage(ref lblMessage, true, "Error Occurred While Adding Group Information ");
                    }

                }
            }
            PopulateGroups();
            CancelClicked(BtnCancel, new EventArgs());
        }

        protected void GdvScreensRowEditing(object sender, GridViewEditEventArgs e)
        {
            var dataKey = GdvGroup.DataKeys[e.NewEditIndex];
            if (dataKey != null)
            {
                int groupId = Convert.ToInt32(dataKey.Value.ToString());
                using (var clothEntities = new ClothEntities())
                {
                    var groups =
                        clothEntities.tbl_Groups.FirstOrDefault(gp => gp.StoreId == LoggedStoreId && gp.GroupId == groupId);
                    if (groups != null)
                    {
                        txtGroupName.Text = groups.GroupName;
                        txtDescription.Text = groups.GroupDescription;
                        rblIsActive.SelectedValue =
                            EnablingAndDisabling.ReturnOneOrZero(groups.Status);
                        BtnAddEdit.Text = "Edit Group";
                        hdnEdit.Value = groups.GroupId.ToString();
                    }
                }
            }
        }

        protected void GdvGroupRowCommand(object sender, GridViewCommandEventArgs e)
        {

            var lnkEnableButton = e.CommandSource as LinkButton;
            if (lnkEnableButton != null)
            {
                string commandName = lnkEnableButton.CommandArgument;
                int rowIndex = 0;
                if (EnablingAndDisabling.ReturnCommandNameWithRowIndex(commandName, out rowIndex,
                                                                       out commandName))
                {
                    var dataKey = GdvGroup.DataKeys[rowIndex];
                    if (dataKey != null)
                    {
                        int dataKeyVal = int.Parse(dataKey[0].ToString());

                        using (var clothEntities = new ClothEntities())
                        {
                            var group =
                                clothEntities.tbl_Groups.FirstOrDefault(gp => gp.GroupId == dataKeyVal);
                            if (group != null)
                            {
                                group.Status = !(group.Status);
                                int rowsUpdated = clothEntities.SaveChanges();
                                if (rowsUpdated > 0)
                                {
                                    Utility.ShowMessage(ref lblMessage, true, "Group Information Has Been Successfully Updated");
                                    PopulateGroups();
                                }
                                else
                                {
                                    Utility.ShowMessage(ref lblMessage, false, "Group Information Couldn't be Successfully Updated");
                                }
                            }
                        }
                    }

                }
                else
                {
                    Utility.ShowMessage(ref lblMessage, false, "Group Information Couldn't be Successfully Updated");
                }
            }

        }
    }
}