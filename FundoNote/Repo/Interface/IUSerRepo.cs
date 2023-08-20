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

        public string ForgetPassword(string email);

        public bool ResetPassword(string Token, string Pass, string CPass);




        //Review Purpose

        public IEnumerable<UserEntity> GetAll();

        public UserEntity GetById(long userId);





    }
}
