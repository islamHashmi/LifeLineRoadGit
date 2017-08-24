using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LifeLineRoad.DataContext;
using AjaxControlToolkit;

namespace LifeLineRoad.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class VehiclesList : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> VehicleNoList(string prefixText, int count)
        {
            List<string> list = new List<string>();

            using (LifeLineDbContext context = new LifeLineDbContext())
            {
                var vehicles = (from a in context.Vehicle_Master
                                  select new
                                  {
                                      vehicleId = a.vehicleId,
                                      vehicleNo = a.vehicleNo
                                  }).ToList();

                foreach (var a in vehicles)
                {
                    string str = AutoCompleteExtender.CreateAutoCompleteItem(a.vehicleNo, a.vehicleId.ToString());
                    list.Add(str);
                }
            }

            return list;
        }
    }
}
