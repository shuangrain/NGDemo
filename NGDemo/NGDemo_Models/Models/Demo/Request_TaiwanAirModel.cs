using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGDemo_Models.DBModels;

namespace NGDemo_Models.Models.Demo
{
    public class Request_TaiwanAirModel
    {

        public SearchModel SearchModel { get; set; }

        public TaiwanAir TaiwanAir { get; set; }

        public Request_TaiwanAirModel()
        {
            SearchModel = new SearchModel();
            TaiwanAir = new TaiwanAir();
        }
    }
}
