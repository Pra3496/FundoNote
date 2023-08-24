using Bussiness.Interface;
using Common;
using Common.Model;
using EFCoreCodeFirstSample.Models;
using Newtonsoft.Json.Linq;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.service
{
    public class UserBussiness : IUserBussiness
    {
        private readonly IUserRepository userRepo;

        public UserBussiness(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public async Task<UserEntity> UserRegistration(UserRegestrationModel userResgistrationModel)
        {
            try
            {
                return await userRepo.UserRegistration(userResgistrationModel);
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserLoginResult> Login(UserLogin userLogin)
        {
            try
            {
                return await userRepo.Login(userLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            try
            {
                return await userRepo.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<string> ForgetPassword(string email)
        {
            try
            {
                return await userRepo.ForgetPassword(email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ResetPassword(long UserId, string Pass, string CPass)
        {
            try
            {
                return await userRepo.ResetPassword(UserId, Pass, CPass);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
