using Microsoft.AspNetCore.Mvc;

namespace Randy.Api.Controllers
{
    /// <summary>
    /// Company Controller
    /// </summary>
    public class CompanyController : ApiBaseController
    {
        /// <summary>
        /// get one Menu
        /// </summary>
        /// <returns>empty</returns>
        [HttpGet]
        public string CreateCompany()
        {
            return "Menu";
        }
         
    }


}
