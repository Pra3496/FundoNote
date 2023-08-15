using Common.Model;
using EFCoreCodeFirstSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repo.Interface
{
    public interface IUserRepo
    {
        public UserEntity UserRegistration(UserRegestrationModel userResgistrationModel);
        public string Login(UserLogin userLogin);

        public string GenerateJWTToken(string email, string userId);

        public List<UserEntity> GetAll();

        public UserEntity GetById(long userId);

        public string ForgetPassword(UserLogin userLogin);





    }
}
