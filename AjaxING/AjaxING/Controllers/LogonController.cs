using AjaxING.Repository;
using System.Web.Http;
using NLog;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace AjaxING.Controllers
{
    [RoutePrefix("api/logon")]
    public class LogonController : ApiController
    {
        #region Properties
        private ILogonRepository _repository;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        public LogonController(ILogonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetData")]
        public IHttpActionResult LoginUser([FromUri]string userID, [FromUri]string password)
        {
            var obj = _repository.LoginUser(userID, password);
            return Ok(obj);
        }
    }
}
