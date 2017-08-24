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
    public partial class EmployeeMaster : System.Web.UI.Page
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
                Response.Redirect("~/ContentPages/EmployeeMasterList.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ddlEmpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlEmpStatus.SelectedValue == "R")
                {
                    divrelDate.Visible = true;
                }
                else
                {
                    divrelDate.Visible = false;
                    txtReleasedOn.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveData(LifeLineDbContext context)
        {
            Employee_Master obj = new Employee_Master();

            obj.firstName = string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text;
            obj.middleName = string.IsNullOrWhiteSpace(txtMiddleName.Text) ? null : txtMiddleName.Text;
            obj.lastName = string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text;
            obj.empAddress = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text;
            obj.city = string.IsNullOrWhiteSpace(txtCity.Text) ? null : txtCity.Text;
            obj.stateId = ddlState.SelectedIndex == 0 ? null : (int?)Convert.ToInt32(ddlState.SelectedValue);
            obj.pincode = string.IsNullOrWhiteSpace(txtPincode.Text) ? null : txtPincode.Text;
            obj.phoneNumber = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text;
            obj.mobileNumber = string.IsNullOrWhiteSpace(txtMobile.Text) ? null : txtMobile.Text;
            obj.emailAddress = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;
            obj.empStatus = string.IsNullOrWhiteSpace(ddlEmpStatus.SelectedValue) ? null : ddlEmpStatus.SelectedValue;
            obj.releasedOnDate = string.IsNullOrWhiteSpace(txtReleasedOn.Text) ? null : (DateTime?)DateTime.ParseExact(txtReleasedOn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToEmployee_Master(obj);
        }

        private void ModifyData(LifeLineDbContext context, int id)
        {
            var obj = context.Employee_Master.First(x => x.employeeId == id);

            obj.firstName = string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text;
            obj.middleName = string.IsNullOrWhiteSpace(txtMiddleName.Text) ? null : txtMiddleName.Text;
            obj.lastName = string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text;
            obj.empAddress = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text;
            obj.city = string.IsNullOrWhiteSpace(txtCity.Text) ? null : txtCity.Text;
            obj.stateId = ddlState.SelectedIndex == 0 ? null : (int?)Convert.ToInt32(ddlState.SelectedValue);
            obj.pincode = string.IsNullOrWhiteSpace(txtPincode.Text) ? null : txtPincode.Text;
            obj.phoneNumber = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text;
            obj.mobileNumber = string.IsNullOrWhiteSpace(txtMobile.Text) ? null : txtMobile.Text;
            obj.emailAddress = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;
            obj.empStatus = string.IsNullOrWhiteSpace(ddlEmpStatus.SelectedValue) ? null : ddlEmpStatus.SelectedValue;
            obj.releasedOnDate = string.IsNullOrWhiteSpace(txtReleasedOn.Text) ? null : (DateTime?)DateTime.ParseExact(txtReleasedOn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.entryBy = SessionHelper.UserId;
            obj.updatedOn = DateTime.Now;
        }

        private void GetData(int id)
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var com = context.Employee_Master.First(x => x.employeeId == id);

            ViewState["Id"] = com.employeeId;

            txtFirstName.Text = com.firstName;
            txtMiddleName.Text = com.middleName;
            txtLastName.Text = com.lastName;
            txtAddress.Text = com.empAddress;
            txtCity.Text = com.city;
            ddlState.SelectedValue = Convert.ToString(com.stateId);
            txtPincode.Text = com.pincode;
            txtPhone.Text = com.phoneNumber;
            txtMobile.Text = com.mobileNumber;
            txtEmail.Text = com.emailAddress;

            if (com.empStatus == "R")
            {
                ddlEmpStatus.SelectedValue = Convert.ToString(com.empStatus);
                txtReleasedOn.Text = Convert.ToDateTime(com.releasedOnDate).ToString("dd/MM/yyyy");
                divrelDate.Visible = true;
            }
            else
            {
                ddlEmpStatus.SelectedValue = Convert.ToString(com.empStatus);
                txtReleasedOn.Text = string.Empty;
                divrelDate.Visible = false;
            }            
        }

        private void ClearFields()
        {
            ViewState["Id"] = null;

            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedValue = "0";
            txtPincode.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlEmpStatus.SelectedIndex = 0;
            txtReleasedOn.Text = string.Empty;
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