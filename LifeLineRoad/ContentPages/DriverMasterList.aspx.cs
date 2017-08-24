using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;
using System.Data.Objects;

namespace LifeLineRoad.ContentPages
{
    public partial class DriverMasterList : System.Web.UI.Page
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
                Response.Redirect("~/ContentPages/DriverMaster.aspx");
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
                string id = Convert.ToString(gvList.DataKeys[gvrow.RowIndex].Values["driverId"]);

                Response.Redirect("~/ContentPages/DriverMaster.aspx?id=" + id);
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
                int id = Convert.ToInt32(gvList.DataKeys[gvrow.RowIndex].Values["driverId"]);

                LifeLineDbContext context = new LifeLineDbContext();

                var user = context.Driver_Master.First(x => x.driverId == id);

                context.Driver_Master.DeleteObject(user);
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

            var driver = (from d in context.Driver_Master
                          join st in context.States on d.stateId equals st.StateId
                          select new
                          {
                              driverId = d.driverId,
                              driverName = d.driverName,
                              dateOfBirth = d.dateOfBirth,
                              address1 = d.address1,
                              address2 = d.address2,
                              city = d.city,
                              StateName = st.StateName,
                              mobileNo = d.mobileNo,
                              LicenseNo = d.LicenseNo
                          }).ToList();

            gvList.DataSource = driver.ToList();
            gvList.DataBind();
        }
    }
}