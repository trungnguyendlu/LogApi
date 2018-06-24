using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using log4net;
using Newtonsoft.Json;
using ServiceStack.Text;
using TrungNguyenDlu.LogApi.Models.Base;

namespace TrungNguyenDlu.LogApi.Infrastructure.Attributes
{
    public sealed class HandleErrorAttribute : ExceptionFilterAttribute
    {
        private readonly ILog _log;

        public HandleErrorAttribute()
        {
            _log = LogManager.GetLogger("LogApi");
        }

        public override async void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception?.InnerException ?? context.Exception;

            var response = new ResponseModel<object>
            {
                Success = false,
                Message = "Internal server error",
                Data = null
            };

            var json = JsonConvert.SerializeObject(response);
            context.Response = new HttpResponseMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var input = string.Empty;
            if (context.Request.Content != null)
            {
                input = await context.Request.Content.ReadAsStringAsync();
            }

            _log.FatalFormat("Exception {0} - message: {1} - input: {2} - response: {3}", context.Request.RequestUri, exception.Dump(), input.Dump(), context.Dump());
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext context, CancellationToken cancellationToken)
        {
            var task = base.OnExceptionAsync(context, cancellationToken);
            return task.ContinueWith(t =>
            {
                OnException(context);
            }, cancellationToken);
        }
    }
}
