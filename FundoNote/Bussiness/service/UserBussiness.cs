using Bussiness.Interface;
using Common.Model;
using EFCoreCodeFirstSample.Models;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.service
{
    public class UserBussiness : IUserBussiness
    {
        private readonly IUserRepo userRepo;

        public UserBussiness(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public UserEntity UserRegistration(UserRegestrationModel userResgistrationModel)
        {
            try
            {
                return userRepo.UserRegistration(userResgistrationModel);
            }
            catch
            {
                throw;
            }
        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                return userRepo.Login(userLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GenerateJWTToken(string email, string userId)
        {
            try
            {
                return userRepo.GenerateJWTToken(email, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<UserEntity> GetAll()
        {
            try
            {
                return userRepo.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserEntity GetById(long userId)
        {
            try
            {
                return userRepo.GetById(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string ForgetPassword(UserLogin userLogin)
        {
            try
            {
                return userRepo.ForgetPassword(userLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
