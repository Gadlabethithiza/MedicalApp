using System;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace eMedicalManagmentODataAPI.Security
{
    public class HttpBasicAuthorizeAttribute : AuthorizeAttribute
    {
        //public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        //{
        //    if (actionContext.Request.Headers.Authorization != null)
        //    {
        //        // get the Authorization header value from the request and base64 decode it
        //        string userInfo = Encoding.Default.GetString(Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter));

        //        // custom authentication logic
        //        if (string.Equals(userInfo, string.Format("{0}:{1}", "Parry", "123456")))
        //        {
        //            IsAuthorized(actionContext);
        //        }
        //        else
        //        {
        //            HandleUnauthorizedRequest(actionContext);
        //        }
        //    }
        //    else
        //    {
        //        HandleUnauthorizedRequest(actionContext);
        //    }
        //}

        //protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        //{
        //    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
        //    {
        //        ReasonPhrase = "Unauthorized"
        //    };
        //}
    }
}

