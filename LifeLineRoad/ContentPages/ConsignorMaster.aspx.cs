using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;
using LifeLineRoad.Utilities;

namespace LifeLineRoad.ContentPages
{
    public partial class ConsignorMaster : System.Web.UI.Page
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
                Response.Redirect("~/ContentPages/ConsignorMasterList.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveData(LifeLineDbContext context)
        {
            Consignor_Master obj = new Consignor_Master();

            obj.consignorName = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : txtCompanyName.Text;
            obj.firstName = string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text;
            obj.lastName = string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text;
            obj.companyAddress = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text;
            obj.city = string.IsNullOrWhiteSpace(txtCity.Text) ? null : txtCity.Text;
            obj.stateId = ddlState.SelectedIndex == 0 ? null : (int?)Convert.ToInt32(ddlState.SelectedValue);
            obj.pincode = string.IsNullOrWhiteSpace(txtPincode.Text) ? null : txtPincode.Text;
            obj.phoneNumber = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text;
            obj.mobileNumber = string.IsNullOrWhiteSpace(txtMobile.Text) ? null : txtMobile.Text;
            obj.faxNumber = string.IsNullOrWhiteSpace(txtFaxNo.Text) ? null : txtFaxNo.Text;
            obj.emailAddress = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;
            obj.vatNumber = string.IsNullOrWhiteSpace(txtVatNo.Text) ? null : txtVatNo.Text;
            obj.cstNumber = string.IsNullOrWhiteSpace(txtCstNo.Text) ? null : txtCstNo.Text;
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToConsignor_Master(obj);
        }

        private void ModifyData(LifeLineDbContext context, int id)
        {
            var obj = context.Consignor_Master.First(x => x.consignorId == id);

            obj.consignorName = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : txtCompanyName.Text;
            obj.firstName = string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text;
            obj.lastName = string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text;
            obj.companyAddress = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text;
            obj.city = string.IsNullOrWhiteSpace(txtCity.Text) ? null : txtCity.Text;
            obj.stateId = ddlState.SelectedIndex == 0 ? null : (int?)Convert.ToInt32(ddlState.SelectedValue);
            obj.pincode = string.IsNullOrWhiteSpace(txtPincode.Text) ? null : txtPincode.Text;
            obj.phoneNumber = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text;
            obj.mobileNumber = string.IsNullOrWhiteSpace(txtMobile.Text) ? null : txtMobile.Text;
            obj.faxNumber = string.IsNullOrWhiteSpace(txtFaxNo.Text) ? null : txtFaxNo.Text;
            obj.emailAddress = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;
            obj.vatNumber = string.IsNullOrWhiteSpace(txtVatNo.Text) ? null : txtVatNo.Text;
            obj.cstNumber = string.IsNullOrWhiteSpace(txtCstNo.Text) ? null : txtCstNo.Text;
            obj.entryBy = SessionHelper.UserId;
            obj.updatedOn = DateTime.Now;
        }

        private void GetData(int id)
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var com = context.Consignor_Master.First(x => x.consignorId == id);

            ViewState["Id"] = com.consignorId;

            txtCompanyName.Text = com.consignorName;
            txtFirstName.Text = com.firstName;
            txtLastName.Text = com.lastName;
            txtAddress.Text = com.companyAddress;
            txtCity.Text = com.city;
            ddlState.SelectedValue = Convert.ToString(com.stateId);
            txtPincode.Text = com.pincode;
            txtPhone.Text = com.phoneNumber;
            txtMobile.Text = com.mobileNumber;
            txtFaxNo.Text = com.faxNumber;
            txtEmail.Text = com.emailAddress;
            txtVatNo.Text = com.vatNumber;
            txtCstNo.Text = com.cstNumber;
        }

        private void ClearFields()
        {
            ViewState["Id"] = null;

            txtCompanyName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedValue = "0";
            txtPincode.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtFaxNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtVatNo.Text = string.Empty;
            txtCstNo.Text = string.Empty;
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