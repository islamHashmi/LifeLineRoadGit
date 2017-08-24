using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;

namespace LifeLineRoad.ContentPages
{
    public partial class InvoiceList : System.Web.UI.Page
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
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ContentPages/Invoice.aspx");
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
                string id = Convert.ToString(gvList.DataKeys[gvrow.RowIndex].Values["InvoiceId"]);

                Response.Redirect("~/ContentPages/Invoice.aspx?id=" + id);
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
                int id = Convert.ToInt32(gvList.DataKeys[gvrow.RowIndex].Values["InvoiceId"]);

                LifeLineDbContext context = new LifeLineDbContext();

                var user = context.Invoice_Header.First(x => x.invoiceId == id);

                context.Invoice_Header.DeleteObject(user);
                context.SaveChanges();

                GetData();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void GetData()
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var listHeader = (from a in context.Invoice_Header
                              join b in context.Consignee_Master on a.consigneeId equals b.consigneeId
                              join c in context.Vehicle_Master on a.vehicleId equals c.vehicleId
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
                                  TotalAmount = a.totalAmount
                              }).ToList();
            gvList.DataSource = listHeader;
            gvList.DataBind();
        }
    }
}