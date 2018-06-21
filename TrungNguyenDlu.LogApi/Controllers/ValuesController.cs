using System.Collections.Generic;
using System.Web.Http;
using TrungNguyenDlu.LogApi.Models.Base;

namespace TrungNguyenDlu.LogApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public ResponseModel<int> Get(int id)
        {
            return ResponseModel<int>.SuccessResponse(id, "success");
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
