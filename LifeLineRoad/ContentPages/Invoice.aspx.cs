using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;
using System.Data;
using System.Transactions;
using System.Globalization;
using LifeLineRoad.Utilities;

namespace LifeLineRoad.ContentPages
{
    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtNetAmount.Attributes.Add("readonly", "readonly");
                    Autogenerate_MemoNo();

                    if (Request.QueryString["id"] != null)
                    {
                        long id = 0;

                        long.TryParse(Request.QueryString["id"], out id);

                        GetData(id);
                    }
                }
            }
            catch (Exception ex)
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

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        using (LifeLineDbContext context = new LifeLineDbContext())
                        {
                            long id = 0;
                            long.TryParse(Convert.ToString(ViewState["Id"]), out id);

                            if (id != 0)
                            {
                                ModifyData(context, id);
                            }
                            else
                            {
                                SaveData(context);
                                //throw new Exception();
                            }

                            decimal totalAmount = InvoiceDetailInsert();

                            if (totalAmount != 0)
                            {
                                long.TryParse(Convert.ToString(ViewState["Id"]), out id);

                                var invobj = context.Invoice_Header.FirstOrDefault(x => x.invoiceId == id);

                                invobj.totalAmount = totalAmount;
                                context.SaveChanges();
                            }

                            context.AcceptAllChanges();

                            scope.Complete();

                            //ClearFields();
                        }
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveData(LifeLineDbContext context)
        {
            Invoice_Header obj = new Invoice_Header();

            obj.invoiceNumber = Convert.ToInt32(txtBillNo.Text);
            obj.invoiceDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.consigneeId = Convert.ToInt32(hfConsigneeIdSave.Value);
            obj.vehicleId = string.IsNullOrWhiteSpace(hfVehicleIdSave.Value) ? null : (int?)Convert.ToInt32(hfVehicleIdSave.Value);
            obj.fromLocation = string.IsNullOrWhiteSpace(txtPickupLoc.Text) ? null : txtPickupLoc.Text;
            obj.toLocation = string.IsNullOrWhiteSpace(txtDropLoc.Text) ? null : txtDropLoc.Text;
            obj.TENon = string.IsNullOrWhiteSpace(txtTENno.Text) ? null : txtTENno.Text;
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToInvoice_Header(obj);
            context.SaveChanges();

            ViewState["Id"] = obj.invoiceId;
        }

        private void ModifyData(LifeLineDbContext context, long id)
        {
            var obj = context.Invoice_Header.First(x => x.invoiceId == id);

            obj.invoiceNumber = Convert.ToInt32(txtBillNo.Text);
            obj.invoiceDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.consigneeId = Convert.ToInt32(hfConsigneeIdSave.Value);
            obj.vehicleId = string.IsNullOrWhiteSpace(hfVehicleIdSave.Value) ? null : (int?)Convert.ToInt32(hfVehicleIdSave.Value);
            obj.fromLocation = string.IsNullOrWhiteSpace(txtPickupLoc.Text) ? null : txtPickupLoc.Text;
            obj.toLocation = string.IsNullOrWhiteSpace(txtDropLoc.Text) ? null : txtDropLoc.Text;
            obj.TENon = string.IsNullOrWhiteSpace(txtTENno.Text) ? null : txtTENno.Text;
            obj.entryBy = SessionHelper.UserId;
            obj.updatedOn = DateTime.Now;

            context.SaveChanges();
        }

        private decimal InvoiceDetailInsert()
        {
            LifeLineDbContext context = new LifeLineDbContext();
            long _invoiceId = 0;
            long.TryParse(Convert.ToString(ViewState["Id"]), out _invoiceId);

            decimal totalAmount = 0;

            if (_invoiceId != 0)
            {
                DataTable dt = Create_DT();

                if (dt.Rows.Count <= 0)
                    return 0;

                var inv = context.Invoice_Detail.Where(x => x.invoiceId == _invoiceId);

                if (inv != null)
                {
                    context.Invoice_Detail.Where(x => x.invoiceId == _invoiceId).ToList().ForEach(x => context.Invoice_Detail.DeleteObject(x));
                    context.SaveChanges();
                }

                foreach (DataRow row in dt.Rows)
                {
                    Invoice_Detail obj = new Invoice_Detail();

                    obj.invoiceId = _invoiceId;
                    obj.loadingDate = Convert.ToString(row["LoadingDate"]) == string.Empty ? null
                                        : (DateTime?)DateTime.ParseExact(Convert.ToString(row["LoadingDate"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    obj.unloadingDate = Convert.ToString(row["UnloadingDate"]) == string.Empty ? null
                                        : (DateTime?)DateTime.ParseExact(Convert.ToString(row["UnloadingDate"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    decimal _freight = 0, _advance = 0, _balance = 0, _toPay = 0, _hamali = 0, _detention = 0, _otherCharge = 0, _netAmount = 0;

                    if (decimal.TryParse(Convert.ToString(row["Freight"]), out _freight))
                        obj.freight = _freight;

                    if (decimal.TryParse(Convert.ToString(row["Advance"]), out _advance))
                        obj.advance = _advance;

                    if (decimal.TryParse(Convert.ToString(row["Balance"]), out _balance))
                        obj.balance = _balance;

                    if (decimal.TryParse(Convert.ToString(row["ToPay"]), out _toPay))
                        obj.toPay = _toPay;

                    if (decimal.TryParse(Convert.ToString(row["Hamali"]), out _hamali))
                        obj.hamali = _hamali;

                    if (decimal.TryParse(Convert.ToString(row["Detention"]), out _detention))
                        obj.detention = _detention;

                    if (decimal.TryParse(Convert.ToString(row["OtherCharge"]), out _otherCharge))
                        obj.otherCharge = _otherCharge;

                    if (decimal.TryParse(Convert.ToString(row["NetAmount"]), out _netAmount))
                        obj.netAmount = _netAmount;

                    totalAmount += _netAmount;

                    context.AddToInvoice_Detail(obj);
                    context.SaveChanges();
                }
            }

            return totalAmount;
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
                Response.Redirect("~/ContentPages/InvoiceList.aspx");
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
                int InvNo = context.Invoice_Header.Any() ? context.Invoice_Header.Max(m => m.invoiceNumber) : 0;

                InvNo = InvNo == 0 ? 1 : InvNo + 1;

                txtBillNo.Text = InvNo.ToString();
            }
        }

        private void ClearFields()
        {
            ViewState["Id"] = null;
            ViewState["ItemDT"] = null;

            txtBillNo.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
            txtPickupLoc.Text = string.Empty;
            txtDropLoc.Text = string.Empty;
            txtTENno.Text = string.Empty;
        }

        private DataTable Dt_AddColumns(DataTable dt)
        {
            dt.Columns.Add("LoadingDate", typeof(string));
            dt.Columns.Add("UnloadingDate", typeof(string));
            dt.Columns.Add("Freight", typeof(string));
            dt.Columns.Add("Advance", typeof(string));
            dt.Columns.Add("Balance", typeof(string));
            dt.Columns.Add("ToPay", typeof(string));
            dt.Columns.Add("Hamali", typeof(string));
            dt.Columns.Add("Detention", typeof(string));
            dt.Columns.Add("OtherCharge", typeof(string));
            dt.Columns.Add("NetAmount", typeof(string));

            return dt;
        }

        private DataTable Create_DT()
        {
            DataTable dt = null;
            if (ViewState["ItemDT"] != null)
            {
                dt = ViewState["ItemDT"] as DataTable;

                if (dt != null)
                {
                    if (dt.Columns.Count > 0)
                        return dt;
                    else
                        dt = Dt_AddColumns(new DataTable());
                }
            }
            else
                dt = Dt_AddColumns(new DataTable());

            return dt;
        }

        protected void btnItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Create_DT();

                string loadingDate = txtLoadingDate.Text;
                string unloadingDate = txtUnloadingDate.Text;
                string freight = txtFrieght.Text;
                string advance = txtAdvance.Text;
                string balance = txtBalance.Text;
                string toPay = txtToPay.Text;
                string hamali = txtHamali.Text;
                string detention = txtDetention.Text;
                string otherCharge = txtOtherCharge.Text;
                string netAmount = txtNetAmount.Text;

                if (!string.IsNullOrWhiteSpace(netAmount))
                {
                    DataRow dr = dt.NewRow();

                    dr["LoadingDate"] = loadingDate;
                    dr["UnloadingDate"] = unloadingDate;
                    dr["Freight"] = freight;
                    dr["Advance"] = advance;
                    dr["Balance"] = balance;
                    dr["ToPay"] = toPay;
                    dr["Hamali"] = hamali;
                    dr["Detention"] = detention;
                    dr["OtherCharge"] = otherCharge;
                    dr["NetAmount"] = netAmount;

                    dt.Rows.Add(dr);
                }

                gvItemList.DataSource = dt;
                gvItemList.DataBind();

                ViewState["ItemDT"] = dt;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnItemClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear_Items();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Clear_Items()
        {
            txtLoadingDate.Text = string.Empty;
            txtUnloadingDate.Text = string.Empty;
            txtFrieght.Text = string.Empty;
            txtAdvance.Text = string.Empty;
            txtBalance.Text = string.Empty;
            txtToPay.Text = string.Empty;
            txtHamali.Text = string.Empty;
            txtDetention.Text = string.Empty;
            txtOtherCharge.Text = string.Empty;
            txtNetAmount.Text = string.Empty;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                GridViewRow gvrow = btn.NamingContainer as GridViewRow;
                //int id = Convert.ToInt32(gvItemList.DataKeys[gvrow.RowIndex].Values["InvoiceId"]);

                DataTable dt = Create_DT();

                if (dt.Rows.Count > 0)
                {
                    txtLoadingDate.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["LoadingDate"]);
                    txtUnloadingDate.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["UnloadingDate"]);
                    txtFrieght.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["Freight"]);
                    txtAdvance.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["Advance"]);
                    txtBalance.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["Balance"]);
                    txtToPay.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["ToPay"]);
                    txtHamali.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["Hamali"]);
                    txtDetention.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["Detention"]);
                    txtOtherCharge.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["OtherCharge"]);
                    txtNetAmount.Text = Convert.ToString(dt.Rows[gvrow.RowIndex]["NetAmount"]);

                    dt.Rows.RemoveAt(gvrow.RowIndex);
                }
                else
                {
                    txtLoadingDate.Text = string.Empty;
                    txtUnloadingDate.Text = string.Empty;
                    txtFrieght.Text = string.Empty;
                    txtAdvance.Text = string.Empty;
                    txtBalance.Text = string.Empty;
                    txtToPay.Text = string.Empty;
                    txtHamali.Text = string.Empty;
                    txtDetention.Text = string.Empty;
                    txtOtherCharge.Text = string.Empty;
                    txtNetAmount.Text = string.Empty;
                }

                ViewState["ItemDT"] = dt;

                gvItemList.DataSource = dt;
                gvItemList.DataBind();
            }
            catch (Exception ex)
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
                //int id = Convert.ToInt32(gvItemList.DataKeys[gvrow.RowIndex].Values["InvoiceId"]);

                DataTable dt = Create_DT();

                dt.Rows.RemoveAt(gvrow.RowIndex);

                ViewState["ItemDT"] = dt;

                gvItemList.DataSource = dt;
                gvItemList.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        decimal totalNetAmount = 0;
        protected void gvItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal netamt = 0;

                    Label lblNet = e.Row.FindControl("lblNetAmt") as Label;

                    if (lblNet != null)
                        decimal.TryParse(lblNet.Text, out netamt);

                    totalNetAmount += netamt;
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblfooter = e.Row.FindControl("lblTotalNetAmt") as Label;

                    if (lblfooter != null)
                        lblfooter.Text = totalNetAmount.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void GetData(long id)
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var inv = (from a in context.Invoice_Header
                       join b in context.Consignee_Master on a.consigneeId equals b.consigneeId
                       join c in context.Vehicle_Master on a.vehicleId equals c.vehicleId
                       where a.invoiceId == id
                       select new
                       {
                           InvoiceId = a.invoiceId,
                           InvoiceNo = a.invoiceNumber,
                           InvoiceDate = a.invoiceDate,
                           ConsigneeId = a.consigneeId,
                           ConsigneeName = b.consigneeName,
                           FromLocation = a.fromLocation,
                           ToLocation = a.toLocation,
                           VehicleId = a.vehicleId,
                           VehicleNo = c.vehicleNo,
                           TENNo = a.TENon,
                           TotalAMount = a.totalAmount
                       }).SingleOrDefault();

            if (inv != null)
            {
                txtBillNo.Text = Convert.ToString(inv.InvoiceNo);
                txtDate.Text = Convert.ToString(inv.InvoiceDate.ToString("dd/MM/yyyy"));

                txtCompanyName.Text = Convert.ToString(inv.ConsigneeName);
                hfConsigneeIdSave.Value = Convert.ToString(inv.ConsigneeId);

                txtPickupLoc.Text = Convert.ToString(inv.FromLocation);
                txtDropLoc.Text = Convert.ToString(inv.ToLocation);

                txtVehicleNo.Text = Convert.ToString(inv.VehicleNo);
                hfVehicleIdSave.Value = Convert.ToString(inv.VehicleId);

                txtTENno.Text = Convert.ToString(inv.TENNo);

                var details = (from a in context.Invoice_Detail
                               where a.invoiceId == id
                               select a);

                ViewState["ItemDT"] = null;

                DataTable dt = Create_DT();

                foreach (var item in details)
                {
                    DataRow row = dt.NewRow();

                    row["LoadingDate"] = item.loadingDate == null ? string.Empty : Convert.ToDateTime(item.loadingDate).ToString("dd/MM/yyyy");
                    row["UnloadingDate"] = item.unloadingDate == null ? string.Empty : Convert.ToDateTime(item.unloadingDate).ToString("dd/MM/yyyy");
                    row["Freight"] = item.freight;
                    row["Advance"] = item.advance;
                    row["Balance"] = item.balance;
                    row["ToPay"] = item.toPay;
                    row["Hamali"] = item.hamali;
                    row["Detention"] = item.detention;
                    row["OtherCharge"] = item.otherCharge;
                    row["NetAmount"] = item.netAmount;

                    dt.Rows.Add(row);
                }

                gvItemList.DataSource = dt;
                gvItemList.DataBind();

                ViewState["Id"] = inv.InvoiceId;
                ViewState["ItemDT"] = dt;
            }
        }
    }
}