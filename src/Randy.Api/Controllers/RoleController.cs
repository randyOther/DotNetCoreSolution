using Microsoft.AspNetCore.Mvc;
using Randy.DomainCore;
using Randy.DomainCore.DTO;
using Randy.Infrastructure;
using Randy.Api.Models;
using Randy.Api.RequestModels;
using Randy.Infrastructure.entities;

namespace Randy.Api.Controllers
{
    /// <summary>
    /// Role Controller
    /// </summary>
    public class RoleController : ApiBaseController
    {

        public IRoleService RoleService { get; set; }

        public RoleController(IRoleService roleService)
        {
            RoleService = roleService;
        }


        /// <summary>
        /// User info list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnPagedModel<ls_role> GetUserInfos([FromBody]QueryPagedModel query)
        {
            return RoleService.GetRoles(query);
        }

        /// <summary>
        /// CreateRole
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel SetRolePermission([FromBody]SetRolePermisonRequest input)
        {
            return RoleService.SetRolePermission(input.roleIds, input.permissions);
        }


        /// <summary>
        /// CreateRole
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel CreateRole([FromBody]Role role)
        {
            return RoleService.CreateRole(role);
        }

        /// <summary>
        /// UpdateRole
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel UpdateRole([FromBody]Role role)
        {
            return RoleService.UpdateRole(role);
        }



        /// <summary>
        /// RemoveRole
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel RemoveRole([FromBody]Role role)
        {
            return RoleService.RemoveRole(role);
        }


        /// <summary>
        /// get one Menu
        /// </summary>
        /// <returns>empty</returns>
        [HttpGet]
        public string GetOne()
        {
            return "Role";
        }

    }


}
