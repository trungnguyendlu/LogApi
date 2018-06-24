using System.Collections.Generic;
using System.Web.Http;
using log4net;
using ServiceStack.Text;
using TrungNguyenDlu.LogApi.Models.Base;

namespace TrungNguyenDlu.LogApi.Controllers
{
    [RoutePrefix("api/simplevalues")]
    public class SimpleValuesController : BaseApiController
    {
        private readonly ILog _logger;
        private readonly IList<string> _values;

        public SimpleValuesController()
        {
            _logger = LogManager.GetLogger("LogApi");
            _values = new List<string> { "value 1", "value 2", "value 3" };
        }

        [Route("GetAllValues")]
        public ResponseModel<IList<string>> GetAllValues()
        {
            _logger.InfoFormat("GetAllValues response: {0}", _values.Dump());
            return new ResponseModel<IList<string>>
            {
                Data = _values,
                Success = true,
                Message = "Get all values successfully."
            };
        }
    }
}
