using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CodeProject.Generic_Repository;
using WebAPI_CodeProject.BusinessEntities;
using AutoMapper;

namespace WebAPI_CodeProject.BusinessServices
{
    public class UserServices : IUserServices
    {
        private IUnitOfWork unitofwork = new UnitOfWork();
        public UserEntity Authenticate(string username, string password)
        {
            var user = unitofwork.UserRepository.Get(s => s.UserName == username && s.Password == password);
            if (!(user==null) && user.UserId > 0)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User,UserEntity>(); });
                var mapper = config.CreateMapper();
                var userModel = mapper.Map<User, UserEntity>(user);
                return userModel;

            }

            return null;
        }
    }
}