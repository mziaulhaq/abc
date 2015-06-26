using System;
using System.Globalization;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;
using System.Collections.Generic;

namespace Ecommerce.EcommerceManager.UserControls.UsersAndScreens
{
    public partial class CtrlCreateUser : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGroups();
                PopulateUsers();

            }
            Utility.MakeLabelInvisible(ref lblMessage);


        }
        private void PopulateGroups()
        {
            using (var clothEntities = new ClothEntities())
            {
                var groups = (clothEntities.tbl_Groups.Where(st => st.StoreId == LoggedStoreId)).ToList();
                ddlGroups.DataSource = groups;
                ddlGroups.DataBind();
                ddlGroups.Items.Insert(0, new ListItem("Select", "Select"));
            }
        }
        private void PopulateUsers()
        {
            if (hfEdit.Value == "0")
            {
                using (var clothEntities = new ClothEntities())
                {
                    var users = clothEntities.GetAllUsers(LoggedStoreId);
                    GdvUser.DataSource = users;
                    GdvUser.DataBind();
                }
            }
            else
            {

            }

        }
        protected void BtnCreateClicked(object sender, EventArgs e)
        {
            try
            {
                int userIdForEdit;
                if (hfEdit.Value == "0")
                {

                    using (var clothEntities = new ClothEntities())
                    {
                        if (clothEntities.tbl_Users.FirstOrDefault(us => us.UserLoginId == txtLoginId.Text) == null)
                        {
                            var user = new tbl_Users()
                                           {
                                               IsActive =
                                                   EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue),
                                               StoreId = LoggedStoreId,
                                               UserCreatedBy = LoggedUserId,
                                               UserCreatedDate = DateTime.Now,
                                               UserAddress = txtAddress.Text,
                                               UserEmail = txtEmail.Text,
                                               UserFullName = txtUserName.Text,
                                               UserLoginId = txtLoginId.Text,
                                               UserIdentityInformation = txtUserIdentityInfo.Text,
                                               UserGroupId = Convert.ToInt32(ddlGroups.SelectedValue),
                                               UserPwd = "lahorecloth@123"
                                           };
                            clothEntities.tbl_Users.Add(user);
                            if (clothEntities.SaveChanges() > 0)
                            {
                                Cancel();
                                PopulateUsers();
                                Utility.ShowMessage(ref lblMessage, true, "User Added Successfully");
                            }
                            else
                            {
                                //Cancel();
                                //PopulateUsers();
                                Utility.ShowMessage(ref lblMessage, true, "User Couldn't be Added Successfully");
                            }
                        }
                        else
                        {
                            Utility.ShowMessage(ref lblMessage, true, "Login Id Already Exist. Please Try Another");
                        }
                    }
                }
                else if (hfEdit.Value == "1" && ViewState["UserId"] != null && int.TryParse(ViewState["UserId"].ToString(), out userIdForEdit))
                {
                    using (var clothEntities = new ClothEntities())
                    {
                        var user = clothEntities.tbl_Users.FirstOrDefault(us => us.UserId == userIdForEdit);
                        if (user != null)
                        {
                            var userUpdation = new tbl_UsersUpdation()
                                                   {
                                                       IsActive = user.IsActive,
                                                       UserAddress = user.UserAddress,
                                                       UserEmail = user.UserEmail,
                                                       UserId = user.UserId,
                                                       UserPwd = user.UserPwd,
                                                       UserFullName = user.UserFullName,
                                                       UserGroupId = user.UserGroupId,
                                                       UserIdentityInformation = user.UserIdentityInformation,
                                                       UserLastModifiedDate = EcommerceUtilities.DateUtility.ReturnNotNullDate(user.UserLastModifiedDate, user.UserCreatedDate),
                                                       UserLastModifiedBy = Convert.ToInt32(user.UserLastModifiedBy ?? user.UserCreatedBy)
                                                   };
                            clothEntities.tbl_UsersUpdation.Add(userUpdation);
                            user.UserGroupId = Convert.ToInt32(ddlGroups.SelectedValue);
                            user.UserEmail = txtEmail.Text;
                            user.UserFullName = txtUserName.Text;
                            user.UserIdentityInformation = txtUserIdentityInfo.Text;
                            user.IsActive =
                                EcommerceUtilities.EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue);
                            user.UserAddress = txtAddress.Text;
                            user.UserLastModifiedBy = LoggedUserId;
                            user.UserLastModifiedDate = DateTime.Now;
                            if (clothEntities.SaveChanges() > 0)
                            {
                                Cancel();
                                PopulateUsers();
                                Utility.ShowMessage(ref lblMessage, true, "User Info Updated Successfully");
                            }
                            else
                            {
                                //Cancel();
                                //PopulateUsers();
                                Utility.ShowMessage(ref lblMessage, true, "User Info Couldn't be Updated Successfully");
                            }
                        }
                        else
                        {
                            Utility.ShowMessage(ref lblMessage, false, "Information provided for Updation are altered");
                        }
                    }
                }

            }
            catch (Exception)
            {

                Utility.ShowMessage(ref lblMessage, false, "Error Occured While Processing Request");
            }
        }
        protected void LoginTextChanged(object sender, EventArgs e)
        {
            using (var clothEntities = new ClothEntities())
            {
                var users = clothEntities.tbl_Users.FirstOrDefault(user => user.UserLoginId == txtLoginId.Text);
                if (users != null)
                {
                    Utility.ShowMessage(ref lblLoginIdExist, false, "Login Id Already Exist");
                }
                else
                {
                    Utility.ShowMessage(ref lblLoginIdExist, true, "Login is Available");
                }
            }
        }
        protected void BtnCancelClicked(object sender, EventArgs e)
        {
            Cancel();
        }
        private void Cancel()
        {
            txtUserName.Text = "";
            txtUserIdentityInfo.Text = "";
            txtLoginId.Text = "";
            txtLoginId.Enabled = true;
            txtEmail.Text = "";
            txtAddress.Text = "";
            lblLoginIdExist.Visible = false;
            hfEdit.Value = "0";
            rblIsActive.ClearSelection();
            ddlGroups.SelectedIndex = 0;
            BtnAddEdit.Text = "Add User";
            ViewState["UserId"] = null;
        }
        protected void GdvUserRowEditing(object sender, GridViewEditEventArgs e)
        {

            var dataKey = GdvUser.DataKeys[e.NewEditIndex];
            if (dataKey != null && dataKey.Values != null && dataKey.Values.Count == 2)
            {
                int userId = Convert.ToInt32(dataKey.Values[0]);
                bool isActive = Convert.ToBoolean(dataKey.Values[1]);
                if (userId != 0 && isActive)
                {
                    using (var clothEntities = new ClothEntities())
                    {
                        var user = clothEntities.tbl_Users.FirstOrDefault(us => us.UserId == userId);
                        if (user != null)
                        {

                            txtUserName.Text = user.UserFullName;
                            txtUserIdentityInfo.Text = user.UserIdentityInformation;
                            txtLoginId.Text = user.UserLoginId;
                            txtLoginId.Enabled = false;
                            txtEmail.Text = user.UserEmail;
                            txtAddress.Text = user.UserAddress;
                            lblLoginIdExist.Visible = false;
                            rblIsActive.SelectedValue = EnablingAndDisabling.ReturnOneOrZero(user.IsActive);
                            ddlGroups.SelectedIndex =
                                ddlGroups.Items.IndexOf(ddlGroups.Items.FindByValue(user.UserGroupId.ToString(CultureInfo.InvariantCulture)));
                            BtnAddEdit.Text = "Edit User Info";
                            hfEdit.Value = "1";
                            ViewState["UserId"] = user.UserId;
                        }
                    }
                }
                else
                {
                    Utility.ShowMessage(ref lblMessage, false, "User is Currently Disable, Enable before editing");
                }

            }
        }
        protected void GdvUserRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var lnkEnableButton = e.CommandSource as LinkButton;

            if (lnkEnableButton != null && e.CommandName == "Status")
            {
                string commandName = lnkEnableButton.CommandArgument;
                int rowIndex = 0;
                if (EnablingAndDisabling.ReturnCommandNameWithRowIndex(commandName, out rowIndex,
                                                                       out commandName))
                {
                    var dataKey = GdvUser.DataKeys[rowIndex];
                    if (dataKey != null)
                    {
                        int dataKeyVal = int.Parse(dataKey[0].ToString());

                        using (var clothEntities = new ClothEntities())
                        {
                            var user = clothEntities.tbl_Users.FirstOrDefault(us => us.UserId == dataKeyVal);
                            if (user != null)
                            {
                                var userUpdation = new tbl_UsersUpdation()
                                                       {
                                                           IsActive = user.IsActive,
                                                           UserAddress = user.UserAddress,
                                                           UserEmail = user.UserEmail,
                                                           UserId = user.UserId,
                                                           UserPwd = user.UserPwd,
                                                           UserFullName = user.UserFullName,
                                                           UserGroupId = user.UserGroupId,
                                                           UserIdentityInformation = user.UserIdentityInformation,
                                                           UserLastModifiedDate =
                                                               EcommerceUtilities.DateUtility.ReturnNotNullDate(
                                                                   user.UserLastModifiedDate, user.UserCreatedDate),
                                                           UserLastModifiedBy =
                                                               Convert.ToInt32(user.UserLastModifiedBy ?? user.UserCreatedBy)
                                                       };
                                clothEntities.tbl_UsersUpdation.Add(userUpdation);
                                user.IsActive = !user.IsActive;
                                if (clothEntities.SaveChanges() > 0)
                                {
                                    Cancel();
                                    PopulateUsers();
                                    Utility.ShowMessage(ref lblMessage, true, "User Info Updated Successfully");
                                }
                                else
                                {
                                    //Cancel();
                                    //PopulateUsers();
                                    Utility.ShowMessage(ref lblMessage, false, "User Info Couldn't be Updated Successfully");
                                }
                            }
                            else
                            {
                                Utility.ShowMessage(ref lblMessage, true, "User Info Couldn't be Updated Successfully");
                            }
                        }

                    }

                }
            }
        }
    }
}