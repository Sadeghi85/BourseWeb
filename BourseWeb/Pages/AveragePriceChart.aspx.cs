using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BourseWeb.Models;

namespace BourseWeb.Pages
{
    public partial class AveragePriceChart : System.Web.UI.Page
    {
        protected string PriceDataSerialized = "";
        protected string VolumeDataSerialized = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DB_BourseEntities ctx = new DB_BourseEntities();
                var data = ctx.spAvgPrice().OrderBy(x => x.Date).ToList();

                List<PriceModel> PriceData = new List<PriceModel>();
                List<VolumeModel> VolumeData = new List<VolumeModel>();


                for (int i = 0; i < data.Count; i++)
                {
                    string color = "rgba(85, 185, 136, 0.8)";

                    if (i > 2)
                    {
                        if (((double)((data[i - 3].AvgPrice.Value - data[i].AvgPrice.Value) / data[i].AvgPrice.Value) > 0.035) && data[i].AvgPrice.Value < data[i - 2].AvgPrice.Value && data[i].AvgPrice.Value < data[i - 3].AvgPrice.Value && data[i - 1].AvgPrice.Value < data[i - 3].AvgPrice.Value && data[i - 2].AvgPrice.Value < data[i - 3].AvgPrice.Value)
                        {
                            color = "rgba(234,82,82, 0.8)";
                        }
                        else
                        {
                            color = "rgba(85, 185, 136, 0.8)";
                        }
                    }

                    if (color == "rgba(234,82,82, 0.8)")
                    {
                        VolumeData[i - 3].color = "rgba(234,82,82, 0.8)";
                        VolumeData[i - 2].color = "rgba(234,82,82, 0.8)";
                        VolumeData[i - 1].color = "rgba(234,82,82, 0.8)";
                    }

                    PriceData.Add(new PriceModel() { time = data[i].Date.ToString("yyyy-MM-dd"), value = data[i].AvgPrice });
                    VolumeData.Add(new VolumeModel() { time = data[i].Date.ToString("yyyy-MM-dd"), value = data[i].AvgVolume, color = color });

                }
 

                PriceDataSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(PriceData);
                VolumeDataSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(VolumeData);
            }
        }

        public class PriceModel
        {
            public string time { get; set; }
            //public decimal? value { get; set; }
            public double? value { get; set; }
        }

        public class VolumeModel
        {
            public string time { get; set; }
            public double? value { get; set; }
            public string color { get; set; }
        }
    }
}