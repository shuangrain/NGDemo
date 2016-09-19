using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NGDemo_Models.DBModels
{
    public class TaiwanAir
    {
        public int TaiwanAir_ID { get; set; }

        [Required]
        [Display(Name = "站台名稱")]
        public string TaiwanAir_SiteName { get; set; }

        [Display(Name = "地區")]
        public string TaiwanAir_County { get; set; }
        public Nullable<double> TaiwanAir_PSI { get; set; }
        public string TaiwanAir_MajorPollutant { get; set; }
        public Nullable<double> TaiwanAir_SO2 { get; set; }
        public Nullable<double> TaiwanAir_CO { get; set; }
        public Nullable<double> TaiwanAir_O3 { get; set; }
        public Nullable<double> TaiwanAir_PM10 { get; set; }
        public Nullable<double> TaiwanAir_PM25 { get; set; }
        public Nullable<double> TaiwanAir_NO2 { get; set; }
        public Nullable<double> TaiwanAir_WindSpeed { get; set; }
        public Nullable<double> TaiwanAir_WindDirec { get; set; }
        [Display(Name = "狀態")]
        public string TaiwanAir_Status { get; set; }
        public Nullable<System.DateTime> TaiwanAir_PublishTime { get; set; }
        public Nullable<System.DateTime> TaiwanAir_Update { get; set; }
    }
}
