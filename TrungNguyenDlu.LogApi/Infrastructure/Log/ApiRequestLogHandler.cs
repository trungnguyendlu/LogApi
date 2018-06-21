using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using ServiceStack;
using TrungNguyenDlu.LogApi.Models.Base;

namespace TrungNguyenDlu.LogApi.Infrastructure.Log
{
    public class ApiRequestLogHandler : DelegatingHandler
    {
        private readonly ILog _logger;

        public ApiRequestLogHandler()
        {
            _logger = LogManager.GetLogger("");
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var input = string.Empty;
            if (request.Content != null)
            {
                input = await request.Content.ReadAsStringAsync();
            }

            var url = request.RequestUri.ToString();

            return await base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var result = task.Result;
                var output = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                WriterLog(input, output, request.Method.Method.ToUpper(), url);

                return result;
            }, cancellationToken);
        }

        private void WriterLog(string input, string output, string method, string url)
        {
            var response = output.FromJson<ResponseModel<object>>();
            if (response.Success)
            {
                _logger.InfoFormat("[{0}] Success {1} - input: {2} - output: {3}", method.ToUpperInvariant(), url, input, output);
            }
            else
            {
                _logger.ErrorFormat("[{0}] Fail {1} - error: {2} - input : {3} - output: {4}", method.ToUpperInvariant(), url, response.Message, input, output);
            }
        }
    }
}