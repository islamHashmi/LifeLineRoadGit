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
    public partial class CompanyMaster : System.Web.UI.Page
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
                Response.Redirect("~/ContentPages/CompanyMasterList.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveData(LifeLineDbContext context)
        {
            Company_Master obj = new Company_Master();

            obj.companyName = txtCompanyName.Text.Trim();
            obj.signatoryType = txtSignType.Text.Trim();
            obj.title = txtTitle.Text.Trim();
            obj.address1 = txtAddress1.Text.Trim();
            obj.address2 = txtAddress2.Text.Trim();
            obj.area = txtArea.Text.Trim();
            obj.city = txtCity.Text.Trim();
            obj.stateId = ddlState.SelectedIndex == 0 ? null : (int?)Convert.ToInt32(ddlState.SelectedValue);
            obj.pincode = txtPincode.Text.Trim();
            obj.phoneNumber = txtPhoneNo.Text.Trim();
            obj.mobileNumber = txtMobileNo.Text.Trim();
            obj.faxNumber = txtFaxNo.Text.Trim();
            obj.emailId = txtEmail.Text.Trim();
            obj.taxSaleValue = string.IsNullOrWhiteSpace(txtTaxSaleValue.Text) ? null : (int?)Convert.ToDecimal(txtTaxSaleValue.Text);
            obj.VatTinNo = txtVatNo.Text.Trim();
            obj.CstTinNo = txtCstNo.Text.Trim();
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToCompany_Master(obj);
        }

        private void ModifyData(LifeLineDbContext context, int id)
        {
            var obj = context.Company_Master.First(x => x.companyId == id);

            obj.companyName = txtCompanyName.Text.Trim();
            obj.signatoryType = txtSignType.Text.Trim();
            obj.title = txtTitle.Text.Trim();
            obj.address1 = txtAddress1.Text.Trim();
            obj.address2 = txtAddress2.Text.Trim();
            obj.area = txtArea.Text.Trim();
            obj.city = txtCity.Text.Trim();
            obj.stateId = ddlState.SelectedIndex == 0 ? null : (int?)Convert.ToInt32(ddlState.SelectedValue);
            obj.pincode = txtPincode.Text.Trim();
            obj.phoneNumber = txtPhoneNo.Text.Trim();
            obj.mobileNumber = txtMobileNo.Text.Trim();
            obj.faxNumber = txtFaxNo.Text.Trim();
            obj.emailId = txtEmail.Text.Trim();
            obj.taxSaleValue = string.IsNullOrWhiteSpace(txtTaxSaleValue.Text) ? null : (int?)Convert.ToDecimal(txtTaxSaleValue.Text);
            obj.VatTinNo = txtVatNo.Text.Trim();
            obj.CstTinNo = txtCstNo.Text.Trim();
            obj.entryBy = SessionHelper.UserId;
            obj.updatedOn = DateTime.Now; 
        }

        private void GetData(int id)
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var com = context.Company_Master.First(x => x.companyId == id);

            ViewState["Id"] = com.companyId;

            txtCompanyName.Text = com.companyName;
            txtSignType.Text = com.signatoryType;
            txtTitle.Text = com.title;
            txtAddress1.Text = com.address1;
            txtAddress2.Text = com.address2;
            txtArea.Text = com.area;
            txtCity.Text = com.city;
            ddlState.SelectedValue = Convert.ToString(com.stateId);
            txtPincode.Text = com.pincode;
            txtPhoneNo.Text = com.phoneNumber;
            txtMobileNo.Text = com.mobileNumber;
            txtFaxNo.Text = com.faxNumber;
            txtEmail.Text = com.emailId;
            txtTaxSaleValue.Text = Convert.ToString(com.taxSaleValue);
            txtVatNo.Text = com.VatTinNo;
            txtCstNo.Text = com.CstTinNo;

        }

        private void ClearFields()
        {
            ViewState["Id"] = null;

            txtCompanyName.Text = string.Empty;
            txtSignType.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtArea.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedValue = "0";
            txtPincode.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtFaxNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTaxSaleValue.Text = string.Empty;
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