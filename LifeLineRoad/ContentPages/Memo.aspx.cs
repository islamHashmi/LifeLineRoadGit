using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;
using LifeLineRoad.Utilities;
using System.Globalization;
using System.Data.Objects;

namespace LifeLineRoad.ContentPages
{
    public partial class Challan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Bind_Combobox();
                    Autogenerate_MemoNo();

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
                string msg = string.Empty;

                if (string.IsNullOrWhiteSpace(hfVehicleIdSave.Value))
                    msg = "Vehicle Number not found in master.";
                else if (string.IsNullOrWhiteSpace(hfConsigneeIdSave.Value))
                    msg = "Consignee name not found in master.";

                bool isValid = ToggleMessage(msg);

                if (!isValid)
                    return;

                using (LifeLineDbContext context = new LifeLineDbContext())
                {
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
                Response.Redirect("~/ContentPages/MemoList.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hfConsigneeIdSave.Value = string.Empty;
                hfConsigneeIdSave.Value = hfConsigneeId.Value;
                hfConsigneeId.Value = string.Empty;

                string msg = string.Empty;

                if (string.IsNullOrWhiteSpace(hfConsigneeIdSave.Value))
                    msg = "Consignee name not found in master.";

                ToggleMessage(msg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void txtVehicleNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hfVehicleIdSave.Value = string.Empty;
                hfVehicleIdSave.Value = hfVehicleId.Value;
                hfVehicleId.Value = string.Empty;

                string msg = string.Empty;

                if (string.IsNullOrWhiteSpace(hfVehicleIdSave.Value))
                    msg = "Vehicle Number not found in master.";

                ToggleMessage(msg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveData(LifeLineDbContext context)
        {
            Memo obj = new Memo();

            obj.memoNumber = Convert.ToInt32(txtMemoNo.Text);
            obj.memoDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.consigneeId = Convert.ToInt32(txtCompanyName.Text);
            obj.vehicleNo = string.IsNullOrWhiteSpace(txtVehicleNo.Text) ? null : txtVehicleNo.Text;
            obj.pickupLocation = string.IsNullOrWhiteSpace(txtPickupLoc.Text) ? null : txtPickupLoc.Text;
            obj.dropLocation = string.IsNullOrWhiteSpace(txtDropLoc.Text) ? null : txtDropLoc.Text;
            obj.weight = string.IsNullOrWhiteSpace(txtWeight.Text) ? null : (decimal?)Convert.ToDecimal(txtWeight.Text);
            obj.hireFixedAmt = string.IsNullOrWhiteSpace(txtHireFixedAmt.Text) ? null : (decimal?)Convert.ToDecimal(txtHireFixedAmt.Text);
            obj.advanceAmt = string.IsNullOrWhiteSpace(txtAdvanceAmt.Text) ? null : (decimal?)Convert.ToDecimal(txtAdvanceAmt.Text);
            obj.balanceAmt = string.IsNullOrWhiteSpace(txtBalanceAmt.Text) ? null : (decimal?)Convert.ToDecimal(txtBalanceAmt.Text);
            obj.balanceAt = string.IsNullOrWhiteSpace(txtBalanceAt.Text) ? null : txtBalanceAt.Text;
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToMemos(obj);
        }

        private void ModifyData(LifeLineDbContext context, int id)
        {
            var obj = context.Memos.First(x => x.memoId == id);

            obj.memoNumber = Convert.ToInt32(txtMemoNo.Text);
            obj.memoDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.consigneeId = Convert.ToInt32(txtCompanyName.Text);
            obj.vehicleNo = string.IsNullOrWhiteSpace(txtVehicleNo.Text) ? null : txtVehicleNo.Text;
            obj.pickupLocation = string.IsNullOrWhiteSpace(txtPickupLoc.Text) ? null : txtPickupLoc.Text;
            obj.dropLocation = string.IsNullOrWhiteSpace(txtDropLoc.Text) ? null : txtDropLoc.Text;
            obj.weight = string.IsNullOrWhiteSpace(txtWeight.Text) ? null : (decimal?)Convert.ToDecimal(txtWeight.Text);
            obj.hireFixedAmt = string.IsNullOrWhiteSpace(txtHireFixedAmt.Text) ? null : (decimal?)Convert.ToDecimal(txtHireFixedAmt.Text);
            obj.advanceAmt = string.IsNullOrWhiteSpace(txtAdvanceAmt.Text) ? null : (decimal?)Convert.ToDecimal(txtAdvanceAmt.Text);
            obj.balanceAmt = string.IsNullOrWhiteSpace(txtBalanceAmt.Text) ? null : (decimal?)Convert.ToDecimal(txtBalanceAmt.Text);
            obj.balanceAt = string.IsNullOrWhiteSpace(txtBalanceAt.Text) ? null : txtBalanceAt.Text;
            obj.entryBy = SessionHelper.UserId;
            obj.updatedOn = DateTime.Now;
        }

        private void GetData(int id)
        {
            using (LifeLineDbContext context = new LifeLineDbContext())
            {
                var com = (from a in context.Memos
                           join b in context.Consignee_Master on a.consigneeId equals b.consigneeId
                           where a.memoId == id
                           select new
                           {
                               memoId = a.memoId,
                               memoNumber = a.memoNumber,
                               memoDate = a.memoDate,
                               consigneeId = a.consigneeId,
                               consigneeName = b.consigneeName,
                               vehicleNo = a.vehicleNo,
                               pickupLocation = a.pickupLocation,
                               dropLocation = a.dropLocation,
                               weight = a.weight,
                               hireFixedAmt = a.hireFixedAmt,
                               advanceAmt = a.advanceAmt,
                               balanceAmt = a.balanceAmt,
                               balanceAt = a.balanceAt
                           }).Single();

                ViewState["Id"] = com.memoId;

                txtMemoNo.Text = Convert.ToString(com.memoNumber);
                txtDate.Text = Convert.ToDateTime(com.memoDate).ToString("dd/MM/yyyy");
                txtCompanyName.Text = Convert.ToString(com.consigneeName);
                hfConsigneeIdSave.Value = Convert.ToString(com.consigneeId);
                txtVehicleNo.Text = Convert.ToString(com.vehicleNo);
                txtPickupLoc.Text = Convert.ToString(com.pickupLocation);
                txtDropLoc.Text = Convert.ToString(com.dropLocation);
                txtWeight.Text = Convert.ToString(com.weight);
                txtHireFixedAmt.Text = Convert.ToString(com.hireFixedAmt);
                txtAdvanceAmt.Text = Convert.ToString(com.advanceAmt);
                txtBalanceAmt.Text = Convert.ToString(com.balanceAmt);
                txtBalanceAt.Text = Convert.ToString(com.balanceAt);
            }
        }

        private void ClearFields()
        {
            ViewState["Id"] = null;

            txtMemoNo.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
            txtPickupLoc.Text = string.Empty;
            txtDropLoc.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtHireFixedAmt.Text = string.Empty;
            txtAdvanceAmt.Text = string.Empty;
            txtBalanceAmt.Text = string.Empty;
            txtBalanceAt.Text = string.Empty;
        }

        private void Bind_Combobox()
        {
            using (LifeLineDbContext context = new LifeLineDbContext())
            {
                var states = from s in context.States
                             select new
                             {
                                 s.StateId,
                                 s.StateName
                             };
            }
        }

        private bool ToggleMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                lblErrorMsg.Text = message;
                pnlMessage.Visible = true;
                return false;
            }
            else
            {
                lblErrorMsg.Text = string.Empty;
                pnlMessage.Visible = false;
                return true;
            }
        }

        private void Autogenerate_MemoNo()
        {
            using (LifeLineDbContext context = new LifeLineDbContext())
            {
                int memoNo = context.Memos.Any() ? context.Memos.Max(m => m.memoNumber) : 0;

                memoNo = memoNo == 0 ? 1 : memoNo + 1;

                txtMemoNo.Text = memoNo.ToString();
            }
        }

    }
}