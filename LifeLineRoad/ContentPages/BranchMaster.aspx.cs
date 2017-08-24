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
    public partial class BranchMaster : System.Web.UI.Page
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
                Response.Redirect("~/ContentPages/BranchMasterList.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveData(LifeLineDbContext context)
        {
            Branch_Master obj = new Branch_Master();

            obj.branchName = txtBranchName.Text.Trim();
            obj.companyId = Convert.ToInt32(ddlCompany.SelectedValue);
            obj.branchAddress = txtAddress1.Text.Trim();
            obj.city = txtCity.Text.Trim();
            obj.stateId = Convert.ToInt32(ddlState.SelectedValue);
            obj.pincode = txtPincode.Text.Trim();
            obj.mobileNo = txtMobileNo.Text.Trim();
            obj.phoneNo = txtPhoneNo.Text.Trim();
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToBranch_Master(obj);
        }

        private void ModifyData(LifeLineDbContext context, int id)
        {
            var obj = context.Branch_Master.First(x => x.branchId == id);

            obj.branchName = txtBranchName.Text.Trim();
            obj.companyId = Convert.ToInt32(ddlCompany.SelectedValue);
            obj.branchAddress = txtAddress1.Text.Trim();
            obj.city = txtCity.Text.Trim();
            obj.stateId = Convert.ToInt32(ddlState.SelectedValue);
            obj.pincode = txtPincode.Text.Trim();
            obj.mobileNo = txtMobileNo.Text.Trim();
            obj.phoneNo = txtPhoneNo.Text.Trim();
            obj.entryBy = SessionHelper.UserId;
            obj.updatedOn = DateTime.Now;
        }

        private void GetData(int id)
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var com = context.Branch_Master.First(x => x.branchId == id);

            ViewState["Id"] = com.branchId;

            txtBranchName.Text = com.branchName;
            ddlCompany.SelectedValue = Convert.ToString(com.companyId);
            txtAddress1.Text = com.branchName;
            txtCity.Text = com.city;
            ddlState.SelectedValue = Convert.ToString(com.stateId);
            txtPincode.Text = com.pincode;
            txtMobileNo.Text = com.mobileNo;
            txtPhoneNo.Text = com.phoneNo;
        }

        private void ClearFields()
        {
            ViewState["Id"] = null;

            txtBranchName.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedValue = "0";
            ddlCompany.SelectedValue = "0";
            txtPincode.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
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


            context = new LifeLineDbContext();

            var com = (from a in context.Company_Master
                       select new
                       {
                           a.companyId,
                           a.companyName
                       });

            ddlCompany.DataSource = com.ToList();
            ddlCompany.DataTextField = "companyName";
            ddlCompany.DataValueField = "companyId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("--- Select Company Name ---", "0"));

        }
    }
}