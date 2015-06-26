using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls.Products
{
    
    public partial class CtrlHomeBannerViewAll : UserControlBase
    {
        private const string Status = "Status";
        private const string Name = "Name";
        private bool? _status;
        private string _name;
        public readonly string UploadImagesUrl = ConfigurationManager.AppSettings["HomeBannerImagePathUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateHomeBanners();
            }
            PopulateViewStates();
        }

        private void PopulateViewStates()
        {
            _status =ViewState[Status]!=null ? Convert.ToBoolean(ViewState[Status].ToString()):(bool?) null;
          
            _name = ViewState[Name]!=null ? ViewState[Name].ToString() : string.Empty;
        }

        private void PopulateHomeBanners()
        {
            using (var clothEntities = new ClothEntities())
            {
                var homeBanners = clothEntities.tbl_HomePageBanners.OrderByDescending(x=>x.BannerOrder).ToList();
                gdvHomeBanners.DataSource = homeBanners;
                gdvHomeBanners.DataBind();
            }
        }

        protected void IBSearchClick(object sender, ImageClickEventArgs e)
        {
            _status = null;
            _name = string.Empty;
            if(!string.IsNullOrEmpty(txtName.Text) && rblIsFeatured.SelectedIndex!=0)
            {
              
                if(rblIsFeatured.SelectedIndex!=0)
                    _status = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsFeatured.SelectedValue);
                if (!string.IsNullOrEmpty(txtName.Text))
                    _name = txtName.Text;
                gdvHomeBanners.PageIndex = 0;
                PopulateAfterButtonAndPageIndex();
            }
        }

        private void PopulateAfterButtonAndPageIndex()
        {
            var query = GetQuery(_status, _name);
            var sql = ((ObjectQuery) query).ToTraceString();
            var result = GetQuery(_status, _name).ToList();
            gdvHomeBanners.DataSource = result;
            gdvHomeBanners.DataBind();
            if (_status.HasValue)
                ViewState[Status] = _status;
            if (!string.IsNullOrEmpty(_name))
                ViewState[Name] = _name;
        }

        protected IQueryable<tbl_HomePageBanners> GetQuery(bool? status , string name)
        {
            using (var cloth= new ClothEntities())
            {
                IQueryable<tbl_HomePageBanners> filter = cloth.tbl_HomePageBanners;
                if (status.HasValue)
                   filter = filter.Where(home => home.IsActive == Convert.ToBoolean(status));
                if(!string.IsNullOrEmpty(name))
                    filter = filter.Where(home => home.Name.Contains(name));
                return filter;
            }
            
        }

        protected void GdvHomeBannersPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvHomeBanners.PageIndex = e.NewPageIndex;
            PopulateAfterButtonAndPageIndex();
        }
        
        
    }
}