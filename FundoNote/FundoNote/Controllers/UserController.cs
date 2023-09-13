using Bussiness.Interface;
using Bussiness.service;
using Common.Model;
using EFCoreCodeFirstSample.Models;
using FundoNote.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repo.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FundoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBussiness userBussiness;

        public UserController(IUserBussiness userBussiness)
        {
            this.userBussiness = userBussiness;

        }




        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> UserRegistration(UserRegestrationModel model)
        {
            try
            {
                var result = await userBussiness.UserRegistration(model);

                if (result != null)
                {
                    return Ok(new { sucess = true, message = "User Registration Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "User Registration Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            try
            {
                var result = await userBussiness.Login(userLogin);

                if (result != null)
                {

                    return this.Ok(new { success = true, message = "Retrive All Successful ", data = result });
                }
                else
                {

                    return BadRequest(new { Success = false, message = "Login Unsuccessful" });

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Users()
        {
            try
            {
                var result = await userBussiness.GetAll();

                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Retrive All Successful ", data = result });


                }
                else
                {

                    return this.Ok(new { success = true, message = "Retrive All Unsuccessful " });

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        [HttpPost]
        [Route("forgetpassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {

                var result = userBussiness.ForgetPassword(email);

                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Forget Password Done Successfully", Token = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Forget Password Done Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword(string pass, string cpass)
        {
            try
            {
                long userId = long.Parse(User.FindFirst("UserID").Value);

                var result = await userBussiness.ResetPassword(userId, pass, cpass);

                if (result == true)
                {
                    return Ok(new { sucess = true, message = "Password Reset Successfully" });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Password Reset Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        

        
        



    }

 
}
