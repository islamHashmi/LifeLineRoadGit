using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;

namespace LifeLineRoad.ContentPages
{
    public partial class EmployeeMasterList : System.Web.UI.Page
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
                Response.Redirect("~/ContentPages/EmployeeMaster.aspx");
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
                string id = Convert.ToString(gvList.DataKeys[gvrow.RowIndex].Values["employeeId"]);

                Response.Redirect("~/ContentPages/EmployeeMaster.aspx?id=" + id);
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
                int id = Convert.ToInt32(gvList.DataKeys[gvrow.RowIndex].Values["employeeId"]);

                LifeLineDbContext context = new LifeLineDbContext();

                var user = context.Employee_Master.First(x => x.employeeId == id);

                context.Employee_Master.DeleteObject(user);
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
            
            var compList = (from emp in context.Employee_Master
                           join s in context.States on emp.stateId equals s.StateId into es
                           from cs in es.DefaultIfEmpty()
                           select new
                           {
                               employeeId = emp.employeeId,
                               firstName = emp.firstName,
                               middleName = emp.middleName,
                               lastName = emp.lastName,
                               mobileNo = emp.mobileNumber,
                               phoneNo = emp.phoneNumber,
                               emailId = emp.emailAddress,
                               empAddress = emp.empAddress,
                               city = emp.city,
                               stateName = cs.StateName,
                               pincode = emp.pincode,
                               empStatus = emp.empStatus == "R" ? "Released" : "Working"
                           }).ToList();

            gvList.DataSource = compList;
            gvList.DataBind();
        }
    }
}