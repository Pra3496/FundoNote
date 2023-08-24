using Common.Model;
using EFCoreCodeFirstSample.Models;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IUserRepository
    {
        Task<UserEntity> UserRegistration(UserRegestrationModel userResgistrationModel);

        Task<UserLoginResult> Login(UserLogin userLogin);

        Task<IEnumerable<UserEntity>> GetAll();

        Task<UserEntity> GetById(long userId);

        Task<string> ForgetPassword(string email);

        Task<bool> ResetPassword(long UserId, string Pass, string CPass);


    }
}
