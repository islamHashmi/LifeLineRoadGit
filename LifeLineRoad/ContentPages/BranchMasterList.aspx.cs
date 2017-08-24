using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;

namespace LifeLineRoad.ContentPages
{
    public partial class BranchMasterList : System.Web.UI.Page
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
                Response.Redirect("~/ContentPages/BranchMaster.aspx");
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
                string id = Convert.ToString(gvList.DataKeys[gvrow.RowIndex].Values["branchId"]);

                Response.Redirect("~/ContentPages/BranchMaster.aspx?id=" + id);
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
                int id = Convert.ToInt32(gvList.DataKeys[gvrow.RowIndex].Values["branchId"]);

                LifeLineDbContext context = new LifeLineDbContext();

                var user = context.Branch_Master.First(x => x.branchId == id);

                context.Branch_Master.DeleteObject(user);
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

            var list = (from d in context.Branch_Master
                        join st in context.States on d.stateId equals st.StateId
                        join c in context.Company_Master on d.companyId equals c.companyId
                        select new
                        {
                            companyId = d.companyId,
                            companyName = c.companyName,
                            branchId = d.branchId,
                            branchName = d.branchName,
                            branchAddress = d.branchAddress,
                            city = d.city,
                            stateName = st.StateName,
                            pincode = d.pincode,
                            mobileNo = d.mobileNo,
                            phoneNo = d.phoneNo
                        }).ToList();

            gvList.DataSource = list;
            gvList.DataBind();
        }
    }
}