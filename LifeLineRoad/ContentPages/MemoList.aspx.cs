using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeLineRoad.DataContext;

namespace LifeLineRoad.ContentPages
{
    public partial class MemoList : System.Web.UI.Page
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
                Response.Redirect("~/ContentPages/Memo.aspx");
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
                string id = Convert.ToString(gvList.DataKeys[gvrow.RowIndex].Values["memoId"]);

                Response.Redirect("~/ContentPages/Memo.aspx?id=" + id);
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
                int id = Convert.ToInt32(gvList.DataKeys[gvrow.RowIndex].Values["memoId"]);

                LifeLineDbContext context = new LifeLineDbContext();

                var memo = context.Memos.First(x => x.memoId == id);

                context.Memos.DeleteObject(memo);
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

            var list = (from a in context.Memos
                              join b in context.Consignee_Master on a.consigneeId equals b.consigneeId
                              select new { 
                                memoId = a.memoId,
                                memoNumber= a.memoNumber,
                                memoDate = a.memoDate,
                                unloadingDate = a.unloadingDate,
                                consigneeName = b.consigneeName,
                                vehicleNo=a.vehicleNo,
                                pickupLocation = a.pickupLocation,
                                dropLocation = a.dropLocation,
                                weight = a.weight,
                                hireFixed = a.hireFixedAmt,
                                advanceAmt = a.advanceAmt,
                                balanceAmt=a.balanceAmt,
                                balanceAt = a.balanceAt
                              }).ToList();

            gvList.DataSource = list;
            gvList.DataBind();
        }
    }
}