using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.UserControls.UsersAndScreens
{
    public partial class CtrlAddEditScreen : UserControlBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                PopulateScreens();
            }

        }

        private void PopulateScreens()
        {
            using (var clothEntities = new ClothEntities())
            {
                var screens = clothEntities.tbl_Screens.ToList();
                GdvScreens.DataSource = screens;
                GdvScreens.DataBind();

            }
        }

       protected void AddEditScreen(object sender, EventArgs e)
        {
            using (var clothEntities = new ClothEntities())
            {

                var screen =
                    clothEntities.tbl_Screens.FirstOrDefault(
                        sc => sc.ScreenName == txtScreenName.Text.ToLower());
                if (screen == null)
                {
                    var newScreen = new tbl_Screens()
                                        {
                                            ScreenName = txtScreenName.Text.ToLower()
                                        };
                    clothEntities.tbl_Screens.Add(newScreen);
                    if (clothEntities.SaveChanges() > 0)
                    {
                        EcommerceUtilities.Utility.ShowMessage(ref lblMessage, true, "Screen Added Successfully !!!");
                        PopulateScreens();
                    }
                    else
                    {
                        EcommerceUtilities.Utility.ShowMessage(ref lblMessage, false,
                                                               "Error Occurred while Saving Screen !!!");
                    }
                }
                else
                {
                    EcommerceUtilities.Utility.ShowMessage(ref lblMessage, false, "Screen Name Already Exist !!!");
                }

            }
        }

        protected void GdvCancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GdvScreens.EditIndex = -1;
            PopulateScreens();
        }

        protected void GdvScreensRowEditing(object sender, GridViewEditEventArgs e)
        {
            GdvScreens.EditIndex = e.NewEditIndex;
            PopulateScreens();
           
        }

        protected void GdvScreensRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var dataKey = e.Keys["ScreenId"].ToString();
            var scid = Convert.ToInt32(dataKey);
            var txtValue = GdvScreens.Rows[e.RowIndex].FindControl("txtScreen") as TextBox;
            if (scid != 0 && txtValue != null && !string.IsNullOrWhiteSpace(txtValue.Text))
                {
                    using (var clothEntities = new ClothEntities())
                    {
                        
                        var screen = clothEntities.tbl_Screens.FirstOrDefault(sc => sc.ScreenId == scid);
                        if(screen!=null)
                        {
                            screen.ScreenName = txtValue.Text;
                            if(clothEntities.SaveChanges()>0)
                            {
                                EcommerceUtilities.Utility.ShowMessage(ref lblMessage, true, "Screen Updated Successfully !!!");
                                PopulateScreens();
                            }
                            else
                            {
                                EcommerceUtilities.Utility.ShowMessage(ref lblMessage, false,
                                                                       "Error Occurred while Saving Screen !!!");
                            }
                            
                        }
                        
                    }
                }
            
                GdvScreens.EditIndex = -1;
                PopulateScreens();

            
            
        }
    }
}