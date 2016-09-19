using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace NGDemo_WebAPI.CustomAttribute
{
    public class AuthorizePlus : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (HttpContext.Current.Session["Authenticated"] != null &&
                (bool)HttpContext.Current.Session["Authenticated"] == true)
            {
                //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                base.OnAuthorization(actionContext);
            }

        }
    }
}