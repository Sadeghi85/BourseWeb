using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BourseWeb.Models;

namespace BourseWeb.API
{
    /// <summary>
    /// Summary description for AveragePriceChart
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AveragePriceChart : System.Web.Services.WebService
    {

        [WebMethod]
        public void get()
        {
            //DB_BourseEntities ctx = new DB_BourseEntities();
            //string q = HttpContext.Current.Request["q"];

            //string strMasterfficeID = HttpContext.Current.Request["MasterOfficeID"];
            //if (strMasterfficeID == null) strMasterfficeID = "0";
            //int MasterfficeID = Convert.ToInt32(strMasterfficeID);

            //string strMojriOfficeID = HttpContext.Current.Request["MojriOfficeID"];
            //if (strMojriOfficeID == null) strMojriOfficeID = "0";
            //int MojriOfficeID = Convert.ToInt32(strMojriOfficeID);

            ////if (q != null && q.Length >= 2)
            ////{

            //IEnumerable<vwMojriOfficeInfo> MojriOfficeInfo;
            //MojriOfficeInfo = ctx.vwMojriOfficeInfo.Where(x =>
            //    ((string.IsNullOrEmpty(q) || (x.FullName != null && x.FullName.Contains(q))) ||
            //     (string.IsNullOrEmpty(q) || (x.EmployeeNum != null && x.EmployeeNum.Contains(q))) ||
            //     (string.IsNullOrEmpty(q) || (x.NationalCode != null && x.NationalCode.Contains(q))) ||
            //     (string.IsNullOrEmpty(q) || (x.OfficeTitle != null && x.OfficeTitle.Contains(q)))));

            //if (MasterfficeID != 0)
            //{
            //    MojriOfficeInfo = MojriOfficeInfo.Where(x => x.OfficeID == MasterfficeID);
            //}

            //if (MojriOfficeID != 0)
            //{
            //    MojriOfficeInfo = MojriOfficeInfo.Where(x => x.MojriOfficeID == MojriOfficeID);
            //}

            //MojriOfficeInfo = MojriOfficeInfo.OrderBy(x => x.FullName).Take(50);

            //var ja = new JArray();

            //var empty = new JObject
            //    {
            //        {"MojriOfficeID", 0},
            //        {"FullName", "-"},
            //        {"EmployeeNum", "-"},
            //        {"NationalCode", "-"},
            //        {"OfficeTitle", "-"},
            //    };
            //ja.Add(empty);

            //foreach (var item in MojriOfficeInfo)
            //{
            //    var itemObject = new JObject
            //        {
            //            {"MojriOfficeID", item.MojriOfficeID},
            //            {"FullName", item.FullName},
            //            {"EmployeeNum", item.EmployeeNum},
            //            {"NationalCode", item.NationalCode},
            //            {"OfficeTitle", item.OfficeTitle},

            //        };
            //    ja.Add(itemObject);
            //}

            //JObject Result = new JObject();
            //Result.Add("total", MojriOfficeInfo.Count());
            //Result.Add("rows", ja);

            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            //string str = JsonConvert.SerializeObject(Result);
            //Context.Response.Write(str);
        }
    }
}
