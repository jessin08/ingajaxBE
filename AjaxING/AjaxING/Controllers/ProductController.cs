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
        /// <param name="userID">user ID</param>
        /// <param name="productId">product ID</param>
        /// <returns>OkNegotiatedContent</returns>
        [HttpGet]
        [Route("ProductDetails")]
        public IHttpActionResult ProductDetails([FromUri]string userID, [FromUri]string productId)
        {
            _logger.Info("Product service : ProductDetails method called");
            var obj = _repository.ProductDetails(userID, productId);
            _logger.Info("Product service : ProductDetails method passed");
            return Ok(obj);
        }
    }
}
