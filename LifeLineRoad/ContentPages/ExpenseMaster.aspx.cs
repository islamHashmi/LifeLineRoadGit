using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;
using System.Globalization;
using LifeLineRoad.Utilities;

namespace LifeLineRoad.ContentPages
{
    public partial class ExpenseMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int id = 0;

                        int.TryParse(Request.QueryString["id"], out id);

                        GetData(id);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LifeLineDbContext context = new LifeLineDbContext();

                int id = 0;
                int.TryParse(Convert.ToString(ViewState["Id"]), out id);

                if (id != 0)
                {
                    ModifyData(context, id);
                }
                else
                {
                    SaveData(context);
                }

                context.SaveChanges();
                ClearFields();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ContentPages/ExpenseMasterList.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveData(LifeLineDbContext context)
        {
            Expense_Master obj = new Expense_Master();

            obj.expenseName = txtExpenseName.Text.Trim();
            obj.effectiveDate = DateTime.ParseExact(txtEffectiveDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToExpense_Master(obj);
        }

        private void ModifyData(LifeLineDbContext context, int id)
        {
            var obj = context.Expense_Master.First(x => x.expenseId == id);

            obj.expenseName = txtExpenseName.Text.Trim();
            obj.effectiveDate = DateTime.ParseExact(txtEffectiveDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.entryBy = SessionHelper.UserId;
            obj.updatedOn = DateTime.Now;
        }

        private void GetData(int id)
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var com = context.Expense_Master.First(x => x.expenseId == id);

            ViewState["Id"] = com.expenseId;

            txtExpenseName.Text = com.expenseName;
            txtEffectiveDate.Text = Convert.ToDateTime(com.effectiveDate).ToString("dd/MM/yyyy");
        }

        private void ClearFields()
        {
            ViewState["Id"] = null;

            txtExpenseName.Text = string.Empty;
            txtEffectiveDate.Text = string.Empty;
        }

    }
}