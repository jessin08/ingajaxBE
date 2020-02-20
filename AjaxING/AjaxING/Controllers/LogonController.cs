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

        [Route("GetData")]
        public IHttpActionResult GetProducts([FromUri]string userID, [FromUri]string password)
        {
            _logger.Debug("Hello log");
            JObject o1 = JObject.Parse("{ 'userToken': 'gdjasdghjafsdgf', 'userType' : 'Customer', 'productDetails' : [ { 'productGroupId': 1, 'productGroupName': 'Spaaren', 'products': [ { 'productId':1, 'productName' : 'Spaardeposito' }, {'productId':1, 'productName' : 'Spaardeposito' }, { 'productId':1, 'productName' : 'Spaardeposito' } ] } ] }");
           
            return Ok(o1);
        }
    }
}
