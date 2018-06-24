using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace TrungNguyenDlu.LogApi.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : BaseApiController
    {
        private readonly IList<string> _values;

        public ValuesController()
        {
            _values = new List<string> {"value 1", "value 2", "value 3"};
        }

        [Route("GetAllValues")]
        public HttpResponseMessage GetAllValues()
        {
            return SuccessMessage(_values, "Get all values successfully.");
        }

        [Route("GetByIndex/{index}")]
        public HttpResponseMessage GetByIndex(int index)
        {
            if (index < 0 || index >= _values.Count)
            {
                return ErrorMessage("Index was out of range. Must be non-negative and less than the size of the collection");
            }
            return SuccessMessage(_values[index], "Get value successfully.");
        }
    }
}
