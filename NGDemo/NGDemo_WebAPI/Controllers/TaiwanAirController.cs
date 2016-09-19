using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NGDemo_Models.Models.Base;
using NGDemo_Models.Models.Demo;
using NGDemo_Session;
using NGDemo_WebAPI.CustomAttribute;
using Sheng_Core;

namespace NGDemo_WebAPI.Controllers
{
    /// <summary>
    /// 台灣空氣品質API
    /// </summary>
    public class TaiwanAirController : ApiController
    {
        TaiwanAir _Service = null;
        Result _Result = null;
        Request_TaiwanAirModel _RequestModel = null;
        Base_Response _Response = null;

        /// <summary>
        /// 初始化
        /// </summary>
        public TaiwanAirController()
        {
            _Service = new TaiwanAir();
            _Result = new Result();
            _RequestModel = new Request_TaiwanAirModel();
            _Response = new Base_Response();
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="SearchModel">搜尋條件</param>
        /// <returns>結果</returns>
        // GET: api/TaiwanAir/
        public HttpResponseMessage Get([FromUri]SearchModel SearchModel)
        {
            _RequestModel.SearchModel = SearchModel;

            try
            {
                Response_TaiwanAirModel responseModel = _Service.Get(_RequestModel, ref _Result);
                _Response = Text.CopyModel<Result, Base_Response>(_Result);

                if (_Result.Success == true)
                {
                    _Response.CurrentPage = _RequestModel.SearchModel.CurrentPage;
                    _Response.Total = responseModel.TaiwanAir.Count();
                    _Response.Data = responseModel.TaiwanAir.Skip((SearchModel.CurrentPage - 1) * SearchModel.PageSize).Take(SearchModel.PageSize);
                }

                return Request.CreateResponse(HttpStatusCode.OK, _Response);
            }
            catch (Exception ex)
            {
                _Response.Success = false;
                _Response.Message = ex.Message.ToString();
                return Request.CreateResponse(HttpStatusCode.BadRequest, _Response);
            }
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        /// <param name="id">目標編號</param>
        /// <returns></returns>
        // GET: api/TaiwanAir/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Response_TaiwanAirModel responseModel = _Service.Get(_RequestModel, ref _Result);
                _Response = Text.CopyModel<Result, Base_Response>(_Result);

                if (_Result.Success == true)
                {
                    _Response.Data = responseModel.TaiwanAir.Where(x => x.TaiwanAir_ID == id);
                }

                return Request.CreateResponse(HttpStatusCode.OK, _Response);
            }
            catch (Exception ex)
            {
                _Response.Success = false;
                _Response.Message = ex.Message.ToString();
                return Request.CreateResponse(HttpStatusCode.BadRequest, _Response);
            }
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="DBModel">DBModel</param>
        /// <returns></returns>
        // POST: api/TaiwanAir
        public HttpResponseMessage Post([FromBody]NGDemo_Models.DBModels.TaiwanAir DBModel)
        {
            try
            {
                if (DBModel == null)
                {
                    ModelState.AddModelError("", "請輸入資料 !!");
                }
                if (ModelState.IsValid == false)
                {
                    _Response.Success = ModelState.IsValid;
                    _Response.Message = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
                    return Request.CreateResponse(HttpStatusCode.OK, _Response);
                }
                else
                {
                    _RequestModel.TaiwanAir = DBModel;
                    _Service.Add(_RequestModel, ref _Result);
                    _Response = Text.CopyModel<Result, Base_Response>(_Result);

                    return Request.CreateResponse(HttpStatusCode.OK, _Response);
                }
            }
            catch (Exception ex)
            {
                _Response.Success = false;
                _Response.Message = ex.Message.ToString();
                return Request.CreateResponse(HttpStatusCode.BadRequest, _Response);
            }
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="id">目標編號</param>
        /// <param name="DBModel">DBModel</param>
        // PUT: api/TaiwanAir/5
        [HttpPut]
        public HttpResponseMessage Put([FromBody]NGDemo_Models.DBModels.TaiwanAir DBModel)
        {
            try
            {
                if (DBModel == null)
                {
                    ModelState.AddModelError("", "請輸入資料 !!");
                }
                if (ModelState.IsValid == false)
                {
                    _Response.Success = ModelState.IsValid;
                    _Response.Message = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
                    return Request.CreateResponse(HttpStatusCode.OK, _Response);
                }
                else
                {
                    _RequestModel.TaiwanAir = DBModel;
                    _Service.Edit(_RequestModel, ref _Result);
                    _Response = Text.CopyModel<Result, Base_Response>(_Result);

                    return Request.CreateResponse(HttpStatusCode.OK, _Response);
                }
            }
            catch (Exception ex)
            {
                _Response.Success = false;
                _Response.Message = ex.Message.ToString();
                return Request.CreateResponse(HttpStatusCode.BadRequest, _Response);
            }
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">目標編號</param>
        // DELETE: api/TaiwanAir/5
        [AuthorizePlus]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _RequestModel.TaiwanAir.TaiwanAir_ID = id;
                _Service.Delete(_RequestModel, ref _Result);
                _Response = Text.CopyModel<Result, Base_Response>(_Result);
                return Request.CreateResponse(HttpStatusCode.OK, _Response);
            }
            catch (Exception ex)
            {
                _Response.Success = false;
                _Response.Message = ex.Message.ToString();
                return Request.CreateResponse(HttpStatusCode.BadRequest, _Response);
            }
        }
    }
}
