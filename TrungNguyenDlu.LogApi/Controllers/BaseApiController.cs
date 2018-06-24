using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using TrungNguyenDlu.LogApi.Models.Base;

namespace TrungNguyenDlu.LogApi.Controllers
{
    [Infrastructure.Attributes.HandleError]
    public class BaseApiController : ApiController
    {
        
        protected HttpResponseMessage ErrorMessage(string message)
        {
            return ResponseMessage(new ResponseModel<object>
            {
                Data = null,
                Success = false,
                Message = message
            });
        }

        protected HttpResponseMessage SuccessMessage<T>(T data, string message = null)
        {
            return ResponseMessage(new ResponseModel<T>
            {
                Data = data,
                Success = true,
                Message = message
            });
        }

        protected HttpResponseMessage ResponseMessage<T>(ResponseModel<T> responseWrapper)
        {
            var json = JsonConvert.SerializeObject(responseWrapper);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        }

    }
}
