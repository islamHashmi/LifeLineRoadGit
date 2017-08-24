using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;
using LifeLineRoad.Utilities;
using System.Globalization;

namespace LifeLineRoad.ContentPages
{
    public partial class DriverMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Bind_Combobox();

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
                Response.Redirect("~/ContentPages/DriverMasterList.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveData(LifeLineDbContext context)
        {
            Driver_Master obj = new Driver_Master();

            obj.driverName = txtDriverName.Text.Trim();
            obj.dateOfBirth = DateTime.ParseExact(txtDOB.Text,"dd/MM/yyyy",CultureInfo.InvariantCulture);
            obj.address1 = txtAddress1.Text.Trim();
            obj.address2 = txtAddress2.Text.Trim();
            obj.city = txtCity.Text.Trim();
            obj.stateId = ddlState.SelectedIndex == 0 ? null : (int?)Convert.ToInt32(ddlState.SelectedValue);
            obj.mobileNo = txtMobileNo.Text.Trim();
            obj.LicenseNo = txtLicenseNo.Text.Trim();
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToDriver_Master(obj);
        }

        private void ModifyData(LifeLineDbContext context, int id)
        {
            var obj = context.Driver_Master.First(x => x.driverId == id);

            obj.driverName = txtDriverName.Text.Trim();
            obj.dateOfBirth = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.address1 = txtAddress1.Text.Trim();
            obj.address2 = txtAddress2.Text.Trim();
            obj.city = txtCity.Text.Trim();
            obj.stateId = ddlState.SelectedIndex == 0 ? null : (int?)Convert.ToInt32(ddlState.SelectedValue);
            obj.mobileNo = txtMobileNo.Text.Trim();
            obj.LicenseNo = txtLicenseNo.Text.Trim();
            obj.entryBy = SessionHelper.UserId;
            obj.updatedOn = DateTime.Now;
        }

        private void GetData(int id)
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var com = context.Driver_Master.First(x => x.driverId == id);

            ViewState["Id"] = com.driverId;

            txtDriverName.Text = com.driverName;
            txtDOB.Text = Convert.ToDateTime(com.dateOfBirth).ToString("dd/MM/yyyy");
            txtAddress1.Text = com.address1;
            txtAddress2.Text = com.address2;
            txtCity.Text = com.city;
            ddlState.SelectedValue = Convert.ToString(com.stateId);
            txtMobileNo.Text = com.mobileNo;
            txtLicenseNo.Text = com.LicenseNo;

        }

        private void ClearFields()
        {
            ViewState["Id"] = null;

            txtDriverName.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedValue = "0";
            txtMobileNo.Text = string.Empty;
            txtLicenseNo.Text = string.Empty;
        }

        private void Bind_Combobox()
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var states = from s in context.States
                         select new
                         {
                             s.StateId,
                             s.StateName
                         };

            ddlState.DataSource = states.ToList();
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--- Select State Name ---", "0"));
        }
    }
}