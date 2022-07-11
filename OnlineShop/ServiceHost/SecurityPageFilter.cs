using System.Linq;
using System.Reflection;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceHost
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            //Get Method Permission
            var handlerPermission = (NeedsPermissionAttribute) context
                .HandlerMethod.MethodInfo
                .GetCustomAttribute(typeof(NeedsPermissionAttribute));

            if (handlerPermission == null)
                return;

            //Get Account Permission
            var accountPermissions = _authHelper.GetPermissions();

            var ap = accountPermissions;
            if (accountPermissions.All(x => x != handlerPermission.Permission))
                context.HttpContext.Response.Redirect("/Account");
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}
