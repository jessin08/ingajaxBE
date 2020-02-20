using AjaxING.Repository;
using NLog;
using System.Web.Http;

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

        /// <summary>
        /// Login user - populates product categories
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <param name="password">password</param>
        /// <returns>OkNegotiatedContent</returns>
        [HttpGet]
        [Route("GetData")]
        public IHttpActionResult LoginUser([FromUri]string userID, [FromUri]string password)
        {
            _logger.Info("Logon service : LoginUser method called");
            var obj = _repository.LoginUser(userID, password);
            _logger.Info("Logon service : LoginUser method passed");
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
