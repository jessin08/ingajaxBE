using AjaxING.Repository;
using System.Web.Http;

namespace AjaxING.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        #region Properties
        private IProductRepository _repository;
        #endregion

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [Route("Get")]
        public IHttpActionResult GetProductDetails([FromUri]string productGroupID)
        {
            var result = "";
            return Ok(result);
        }
    }
}
