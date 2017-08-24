using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;

namespace LifeLineRoad.ContentPages
{
    public partial class ExpenseMasterList : System.Web.UI.Page
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ContentPages/ExpenseMaster.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                GridViewRow gvrow = btn.NamingContainer as GridViewRow;
                string id = Convert.ToString(gvList.DataKeys[gvrow.RowIndex].Values["expenseId"]);

                Response.Redirect("~/ContentPages/ExpenseMaster.aspx?id=" + id);
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
                int id = Convert.ToInt32(gvList.DataKeys[gvrow.RowIndex].Values["expenseId"]);

                LifeLineDbContext context = new LifeLineDbContext();

                var user = context.Expense_Master.First(x => x.expenseId == id);

                context.Expense_Master.DeleteObject(user);
                context.SaveChanges();

                GetData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetData()
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var driver = (from d in context.Expense_Master
                          select d);

            gvList.DataSource = driver.ToList();
            gvList.DataBind();
        }
    }
}