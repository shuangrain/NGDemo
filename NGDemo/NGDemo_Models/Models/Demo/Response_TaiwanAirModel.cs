using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGDemo_Models.DBModels;

namespace NGDemo_Models.Models.Demo
{
    public class Response_TaiwanAirModel
    {
        public IQueryable<TaiwanAir> TaiwanAir { get; set; }
    }
}
