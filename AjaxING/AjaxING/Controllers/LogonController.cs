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
        private IProductRepository _productRepository;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        public LogonController(ILogonRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetData")]
        public IHttpActionResult LoginUser([FromUri]string userID, [FromUri]string password)
        {
            var obj = _repository.LoginUser(userID, password);
            return Ok(obj);
        }

        [HttpGet]
        [Route("ProductDetails")]
        public IHttpActionResult ProductDetails([FromUri]string userID, [FromUri]string productId)
        {
            var obj = _productRepository.ProductDetails(userID, productId);
            return Ok(obj);
        }
    }
}
