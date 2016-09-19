using System.Linq;
using NGDemo_Models.Models.Demo;
using NGDemo_Models.Models.Base;
using NGDemo_Repository;

namespace NGDemo_Session
{
    public class TaiwanAir
    {
        RTaiwanAir _API = null;
        Response_TaiwanAirModel _ResponseModel = null;

        public TaiwanAir()
        {
            _API = new RTaiwanAir();
            _ResponseModel = new Response_TaiwanAirModel();
        }

        public Response_TaiwanAirModel Get(Request_TaiwanAirModel RequestModel, ref Result Result)
        {
            _ResponseModel.TaiwanAir = _API.Select(RequestModel.SearchModel, ref Result);
            return _ResponseModel;
        }

        public void Add(Request_TaiwanAirModel RequestModel, ref Result Result)
        {
            _API.Insert(RequestModel.TaiwanAir, ref Result);
        }

        public void Edit(Request_TaiwanAirModel RequestModel, ref Result Result)
        {
            _API.Update(RequestModel.TaiwanAir, ref Result);
        }

        public void Delete(Request_TaiwanAirModel RequestModel, ref Result Result)
        {
            _API.Delete(RequestModel.TaiwanAir, ref Result);
        }
    }
}
