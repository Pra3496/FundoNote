using Common.Model;
using EFCoreCodeFirstSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface IUserBussiness
    {
        public UserEntity UserRegistration(UserRegestrationModel userResgistrationModel);
        public string Login(UserLogin userLogin);

        public string GenerateJWTToken(string email, string userId);

        public string ForgetPassword(string email);

        public bool ResetPassword(string Token, string Pass, string CPass);




        //Review Portion
        public IEnumerable<UserEntity> GetAll();

        public UserEntity GetById(long userId);


    }
}
