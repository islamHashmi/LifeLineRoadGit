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
    public partial class VehicleMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
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
                Response.Redirect("~/ContentPages/VehicleMasterList.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearFields()
        {
            ViewState["Id"] = null;

            txtMakerName.Text = string.Empty;
            txtModelName.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
            txtEngineNo.Text = string.Empty;
            txtChasisNo.Text = string.Empty;
            txtManufacYear.Text = string.Empty;
        }

        private void SaveData(LifeLineDbContext context)
        {
            Vehicle_Master obj = new Vehicle_Master();

            obj.makerName = txtMakerName.Text.Trim();
            obj.modelName = txtModelName.Text.Trim();
            obj.vehicleNo = txtVehicleNo.Text.Trim();
            obj.engineNo = txtEngineNo.Text.Trim();
            obj.chasisNo = txtChasisNo.Text.Trim();
            obj.yearManufactured = txtManufacYear.Text;
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToVehicle_Master(obj);
        }

        private void ModifyData(LifeLineDbContext context, int id)
        {
            var obj = context.Vehicle_Master.First(x => x.vehicleId == id);

            obj.makerName = txtMakerName.Text.Trim();
            obj.modelName = txtModelName.Text.Trim();
            obj.vehicleNo = txtVehicleNo.Text.Trim();
            obj.engineNo = txtEngineNo.Text.Trim();
            obj.chasisNo = txtChasisNo.Text.Trim();
            obj.yearManufactured = txtManufacYear.Text;
            obj.entryBy = SessionHelper.UserId;
            obj.updatedOn = DateTime.Now;
        }

        private void GetData(int id)
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var com = context.Vehicle_Master.First(x => x.vehicleId == id);

            ViewState["Id"] = com.vehicleId;

            txtMakerName.Text = com.makerName;
            txtModelName.Text = com.modelName;
            txtVehicleNo.Text = com.vehicleNo;
            txtEngineNo.Text = com.engineNo;
            txtChasisNo.Text = com.chasisNo;
            txtManufacYear.Text = com.yearManufactured;
        }
    }
}