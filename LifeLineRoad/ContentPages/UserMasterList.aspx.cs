using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;

namespace LifeLineRoad.ContentPages
{
    public partial class UserMasterList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private void GetData()
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var userList = from user in context.User_Master
                    select user;

            gvList.DataSource = userList;
            gvList.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                GridViewRow gvrow = btn.NamingContainer as GridViewRow;
                string id = Convert.ToString(gvList.DataKeys[gvrow.RowIndex].Values["userId"]);

                Response.Redirect("~/ContentPages/UserMaster.aspx?id=" + id);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                GridViewRow gvrow = btn.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(gvList.DataKeys[gvrow.RowIndex].Values["userId"]);

                LifeLineDbContext context = new LifeLineDbContext();

                var user = context.User_Master.First(x => x.userId == id);

                context.User_Master.DeleteObject(user);
                context.SaveChanges();

                GetData();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ContentPages/UserMaster.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}