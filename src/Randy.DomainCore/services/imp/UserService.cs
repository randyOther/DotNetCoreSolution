using AutoMapper;
using Randy.DomainCore.DTO;
using Randy.DomainCore.enums;
using Randy.DomainCore.eventHandler;
using Randy.FrameworkCore;
using Randy.FrameworkCore.reposiories;
using Randy.Infrastructure;
using Randy.Infrastructure.entities;
using Randy.Infrastructure.interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.DomainCore
{
    [LogRequest]
    public class UserService : ApplicationServices, IUserService
    {

        public IRepository<ls_user> UserRepository { get; set; }
        public IRepository<ls_user_info> UserInfoRepository { get; set; }
        public IEventBus EventBus { get; set; }
        public IRepository<ls_role> RoleRepository { get; set; }
        public IRepository<ls_role_authority> RolePermissionRepository { get; set; }
        public IRepository<ls_authority> AuthorityRepository { get; set; }
        public IRepository<ls_user_role> UserRoleRepository { get; set; }

        public ReturnModel<User> Login(string userName, string password, string ip = "")
        {
            ReturnModel<User> result = new ReturnModel<DTO.User>();
            var repository = UserRepository.Get(s => (s.Email == userName || s.Phone == userName));

            if (repository != null)
            {

                var pwd = Encryptor.Md5Encrypt(password + repository.CreateDate.ToString("yyyyMMddHHmmss"));

                if (repository.Pwd == pwd)
                {
                    result.Success = true;
                    result.RerutnModel = Mapper.Map<User>(repository);
                    EventBus.Trigger(new LoginEventData { UserId = repository.UserId, LoginIp = ip });
                }
                else
                {
                    result.ReturnMessage = "密码错误/Passwrod Error";
                }

            }
            else
            {
                result.ReturnMessage = "用户不存在/User Not Exist";
            }
            return result;
        }

        public ReturnModel SignUp(SignUpInput input)
        {
            var now = DateTime.Now;
            ReturnModel result = new ReturnModel();

            var repository = UserRepository.Get(s => (s.Email == input.UserName || s.Phone == input.UserName));
            if (repository != null)
            {
                result.ReturnMessage = "用户名重复/User Name is Duplicated";
            }
            else
            {
                var lsUser = UserRepository.Insert(new ls_user
                {
                    Email = input.UserName,
                    Pwd = Encryptor.Md5Encrypt(input.Password + now.ToString("yyyyMMddHHmmss")),
                    CreateDate = now,
                    Status = UserStatusEnumType.ACTIVE.ToString(),
                    LastLoginIP = "",
                    LastLoginTime = now,
                    IsDelete = false
                });
                result.Success = true;
            }

            return result;
        }

        public ReturnModel SetUserInfo(UserInfo info)
        {
            ReturnModel result = new ReturnModel();
            if (info.UserInfoId > 0)
            {
                var repository = UserInfoRepository.Get(s => s.UserInfoId == info.UserInfoId);
                repository.Tel = info.Tel;
                repository.Address = info.Address;
                repository.BirthDate = info.BirthDate;
                repository.ExtendInfo = info.ExtendInfo;
                repository.IdCardNo = info.IdCardNo;
                repository.IdCardType = info.IdCardType;
                repository.NickName = info.NickName;
                repository.Phone = info.Phone;
                repository.RealName = info.RealName;
                repository.Remark = info.Remark;
                UserInfoRepository.Update(repository);
            }
            else
            {
                var dbentity = Mapper.Map<ls_user_info>(info);
                UserInfoRepository.Insert(dbentity);
            }

            return result;
        }

        public ReturnModel<UserDetail> GetUserDetail(int userId)
        {
            ReturnModel<UserDetail> result = new ReturnModel<UserDetail>() { RerutnModel = new UserDetail() };
            var userInfo = UserInfoRepository.Get(s => s.UserId == userId);
            result.RerutnModel.Info = Mapper.Map<UserInfo>(userInfo);
            result.RerutnModel.Roles = GetRolesByUserId(userId);
            return result;
        }

        private List<Role> GetRolesByUserId(int userId)
        {
            List<Role> roles = null;
            //Get User Role
            var q = from ur in UserRoleRepository.GetAll()
                    join r in RoleRepository.GetAll() on ur.RoleId equals r.RoleId
                    //join rp in RolePermissionRepository.GetAll() on r.RoleId equals rp.RoleId
                    where ur.UserId == userId
                    select new Role
                    {
                        RoleId = r.RoleId,
                        Name = r.Name,
                        Code = r.Code,
                        Permissions = (from rp in RolePermissionRepository.GetAll()
                                       join p in AuthorityRepository.GetAll() on rp.AuthorityId equals p.AuthorityId
                                       where rp.RoleId == r.RoleId
                                       select new Permission
                                       {
                                           AuthorityId = p.AuthorityId,
                                           Name = p.Name,
                                       }).ToList()
                    };


            roles = q.ToList();

            return roles;
        }
    }

}
