using Microsoft.AspNetCore.Mvc;

namespace Randy.Api.Controllers
{
    /// <summary>
    /// Token Controller
    /// </summary>
    public class TokenController : ApiBaseController
    {
        /// <summary>
        /// Get Token
        /// </summary>
        /// <returns>empty</returns>
        public string GetToken()
        {
            return "GetToken";
        }
         
    }


}
