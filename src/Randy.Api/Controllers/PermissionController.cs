using Microsoft.AspNetCore.Mvc;

namespace Randy.Api.Controllers
{
    /// <summary>
    /// Permission Controller
    /// </summary>
    public class PermissionController : ApiBaseController
    {
        /// <summary>
        /// get one Menu
        /// </summary>
        /// <returns>empty</returns>
        [HttpGet]
        public string GetOne()
        {
            return "Menu";
        }

    }


}
