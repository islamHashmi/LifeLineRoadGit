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
    public partial class UserMaster : System.Web.UI.Page
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

        private void SaveData(LifeLineDbContext context)
        {
            User_Master obj = new User_Master();

            obj.userName = txtUserName.Text.Trim();
            obj.loginId = txtLoginId.Text.Trim();
            obj.loginKey = txtPasswd.Text.Trim();
            obj.mobileNo = txtMobileNo.Text.Trim();
            obj.emailAddress = txtEmailId.Text.Trim();
            obj.entryBy = SessionHelper.UserId;
            obj.entryDate = DateTime.Now;
            obj.updatedOn = null;

            context.AddToUser_Master(obj);
        }

        private void ModifyData(LifeLineDbContext context, int id)
        {
            var user = context.User_Master.First(x => x.userId == id);

            user.userName = txtUserName.Text.Trim();
            user.loginId = txtLoginId.Text.Trim();
            user.loginKey = txtPasswd.Text.Trim();
            user.mobileNo = txtMobileNo.Text.Trim();
            user.emailAddress = txtEmailId.Text.Trim();
            user.entryBy = 1;
            user.updatedOn = DateTime.Now;
        }

        private void GetData(int id)
        {
            LifeLineDbContext context = new LifeLineDbContext();

            var user = context.User_Master.First(x => x.userId == id);

            ViewState["Id"] = user.userId;
            txtUserName.Text = user.userName;
            txtLoginId.Text = user.loginId;
            txtPasswd.Text = user.loginKey;
            txtConPasswd.Text = user.loginKey;
            txtMobileNo.Text = user.mobileNo;
            txtEmailId.Text = user.emailAddress;
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ContentPages/UserMasterList.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearFields()
        {
            txtUserName.Text = string.Empty;
            txtLoginId.Text = string.Empty;
            txtConPasswd.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtPasswd.Text = string.Empty;

            ViewState["Id"] = null;
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
    }
}