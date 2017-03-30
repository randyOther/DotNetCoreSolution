using Microsoft.AspNetCore.Mvc;
using Randy.DomainCore;
using Randy.Infrastructure;
using Randy.Infrastructure.entities;

namespace Randy.Api.Controllers
{
    /// <summary>
    /// Permission Controller
    /// </summary>
    public class PermissionController : ApiBaseController
    {
        public IPermissionService PermissionService { get; set; }

        public PermissionController(IPermissionService pService)
        {
            PermissionService = pService;
        }


        /// <summary>
        /// permission manager list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnPagedModel<ls_authority> GetUserInfos([FromBody]QueryPagedModel query)
        {
            return PermissionService.GetPermissions(query);
        }


        /// <summary>
        /// Create Permission
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel CreatePermission([FromBody]Permission permission)
        {
            return PermissionService.CreatePermission(permission);
        }

        /// <summary>
        /// Update Permission
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel UpdatePermission([FromBody]Permission permission)
        {
            return PermissionService.UpdatePermission(permission);
        }



        /// <summary>
        /// Remove Permission
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel RemovePermission([FromBody]Permission permission)
        {
            return PermissionService.RemovePermission(permission);
        }

    }


}
