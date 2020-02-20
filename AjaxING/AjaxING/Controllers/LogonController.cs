using AjaxING.ErrorLogging;
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
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        /// <summary>
        /// The Contructor initializer
        /// </summary>
        /// <param name="repository">ILogonRepository</param>
        public LogonController(ILogonRepository repository)
        {
            _repository = repository;
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
            //ErrorLogger.Instance = 
            return Ok(obj);
        }
    }
}
