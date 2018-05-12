using System;
using System.Net;
using System.Web.Mvc;

namespace CP.Core.Contract.Permission.Models
{
    public class MvcError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Exception e = context.Exception;
            context.ExceptionHandled = true;
            context.Result = new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}