using AjaxING.Repository;
using System.Web.Http;
using NLog;

namespace AjaxING.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        #region Properties
        private IProductRepository _repository;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// The Contructor initializer
        /// </summary>
        /// <param name="repository">IProductRepository</param>
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get the product details based on product category
        /// </summary>
        /// <param name="productGroupID">productGroupID</param>
        /// <returns>OkNegotiatedContent</returns>
        [Route("Get")]
        public IHttpActionResult GetProductDetails([FromUri]string productGroupID)
        {
            _logger.Info("Logon service : GetProductDetails method called");
            var result = "";
            _logger.Info("Logon service : GetProductDetails method passed");
            return Ok(result);
        }
    }
}
