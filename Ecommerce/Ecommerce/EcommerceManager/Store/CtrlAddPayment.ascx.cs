using System;
using System.Collections.Generic;
using System.Linq;
using System.util;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.Store
{
    public partial class CtrlAddPayment : UserControlFront
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStores();
            }
        }

        private void PopulateStores()
        {
            using (var db = new ClothEntities())
            {
                ddlStore.DataSource = db.tbl_Stores.ToList();
                ddlStore.DataBind();
                ddlStore.Items.Insert(0, "--Select Store--");
            }
        }

        /// <summary>
        /// Code added by zia - new payment of particular store added and next payment schedule is set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddPaymentClicked(object sender, EventArgs e)
        {
            using (var db = new ClothEntities())
            {
                var storePayment = new tbl_StorePayment
                {
                    StoreId = Convert.ToInt32(ddlStore.SelectedValue),
                    StorePaymentFromDate = Convert.ToDateTime(dtFrom.Text),
                    StorePaymentToDate = Convert.ToDateTime(dtTo.Text),
                    StorePayment = Convert.ToDecimal(txtAmountToPay.Text),
                    StorePaymentDate = DateTime.Now,
                    StorePaymentInsertedBy = LoggedUser.GetUserId()
                };
                db.tbl_StorePayment.Add(storePayment);
                if (db.SaveChanges() > 0)
                {
                    var nextSchedule = new tbl_NextStorePaymentSchedule
                    {
                        StoreId = Convert.ToInt32(ddlStore.SelectedValue),
                        ScheduleDate = Convert.ToDateTime(dtTo.Text),
                        InsertionDate = DateTime.Now,
                        InsertedBy = LoggedUser.GetUserId(),
                        UpdatedBy = null
                    };
                    db.tbl_NextStorePaymentSchedule.Add(nextSchedule);
                    if (db.SaveChanges() > 0)
                    {
                        Utility.ShowPopUpMessage("Success",new List<string>(){"Payment Added successfully"},this.Page,true );
                    }
                    else
                    {
                        Utility.ShowPopUpMessage("Success", new List<string>() { "Payment Added but next payment could not be added" }, this.Page, true);
                    }
                }
                else
                {
                    Utility.ShowPopUpMessage("Success", new List<string>() { "Payment could not be added due to some error" }, this.Page, true);
                }
            }
        }

        /// <summary>
        /// Code added by zia - Check date validations
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void cvDateCheck_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(dtFrom.Text) && !string.IsNullOrEmpty(dtTo.Text))
            {
                try
                {
                    var dateFrom = Convert.ToDateTime(dtFrom.Text);
                    var dateTo = Convert.ToDateTime(dtTo.Text);
                    if (dateFrom < dateTo)
                        args.IsValid = true;
                    else
                    {
                        args.IsValid = false;
                        Utility.ShowPopUpMessage("Invalid Query Parameters", new List<string>() { "Please provide valid date to query" }, this.Page, true);
                    }

                }
                catch (Exception)
                {
                    args.IsValid = false;
                    Utility.ShowPopUpMessage("Invalid Query Parameters", new List<string>() { "Please provide valid date to query" }, this.Page, true);
                }
            }

        }

        protected void DdlStoreSelectedIndexChanged(object sender, EventArgs e)
        {
            int store;
            if (ddlStore.SelectedValue != null && int.TryParse(ddlStore.SelectedValue, out store))
            {
                using (var db=new ClothEntities())
                {
                    tbl_Stores tblStores = db.tbl_Stores.FirstOrDefault(x => x.StoreId == store);
                    if (tblStores != null)
                    {
                        string message = GetBillingTermById(Convert.ToInt32(tblStores.BillingTermId));
                        Utility.ShowMessage(ref  lblMessage,true,"This Store has billing term "+message);
                    }
                    else
                    {
                        Utility.ShowPopUpMessage("Error",new List<string>(){"No such store exist"},this.Page,true );
                    }
                }
            }
            else
            {
                Utility.ShowPopUpMessage("Error", new List<string>() { "Drop downn value could not be converted" }, this.Page, true);
            }
            
        }

        //protected void DateFromTextChanged(object sender, EventArgs e)
        //{
        //    DateTime dt = Convert.ToDateTime(dtFrom.Text);
        //    DateTime ct = DateTime.Now.Date;
        //    ct.AddMonths(5);
        //    int storeId;
        //    if (ddlStore.SelectedValue != null && int.TryParse(ddlStore.SelectedValue, out storeId))
        //    {
        //        using (var db = new ClothEntities())
        //        {
        //            var store = db.tbl_Stores.FirstOrDefault(x => x.StoreId == storeId);
        //            if (store != null)
        //            {
        //                string billingTerm = GetBillingTermById(Convert.ToInt32(store.BillingTermId));
        //                switch (billingTerm)
        //                {
        //                    case "Yearly":dt.AddYears(1);break;
        //                    case "Half Yearly":dt.AddMonths(6);break;
        //                    case "Quarterly":dt.AddMonths(3);break;
        //                    case "Monthly":dt.AddMonths(1);break;
        //                }
        //                dt.AddMonths(6);
        //                dtTo.Text = dt.ToShortDateString();
        //            }
        //        }
        //    }
        //}
    }
}