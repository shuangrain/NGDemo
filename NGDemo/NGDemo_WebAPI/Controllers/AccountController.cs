using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using NGDemo_Models.Models.Base;

namespace NGDemo_WebAPI.Controllers
{

    /// <summary>
    /// 帳號
    /// </summary>
    public class AccountController : ApiController
    {
        Base_Response _Response = null;

        /// <summary>
        /// 初始化
        /// </summary>
        public AccountController()
        {
            _Response = new Base_Response();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="LoginModel"></param>
        /// <returns></returns>
        [Route("api/Account/Login")]
        public HttpResponseMessage Login([FromBody]Base_Login LoginModel)
        {
            try
            {
                if (LoginModel == null)
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
                    if (LoginModel.Account.ToUpper() != "admin".ToUpper() ||
                        LoginModel.Password.ToUpper() != "admin".ToUpper())
                    {
                        throw new Exception("帳號或密碼錯誤 !!");
                    }
                    else
                    {
                        HttpContext.Current.Session["Authenticated"] = true;
                    }

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
    }
}
