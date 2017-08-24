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
    public class ConsigneesList : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> ConsigneeNameList(string prefixText, int count)
        {
            List<string> list = new List<string>();

            using (LifeLineDbContext context = new LifeLineDbContext())
            {
                var consignees = (from a in context.Consignee_Master
                                  select new
                                  {
                                      consigneeId = a.consigneeId,
                                      consigneeName = a.consigneeName
                                  }).ToList();

                foreach (var a in consignees)
                {
                    string str = AutoCompleteExtender.CreateAutoCompleteItem(a.consigneeName, a.consigneeId.ToString());
                    list.Add(str);
                }
            }

            return list;
        }
    }
}
