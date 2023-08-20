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

namespace FundoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBussiness userBussiness;

        private readonly AppSettings _appSettings;




        public UserController(IUserBussiness userBussiness)
        {
            this.userBussiness = userBussiness;

        }




        [HttpPost]
        [Route("Register")]
        public IActionResult UserRegistration(UserRegestrationModel model)
        {
            try
            {
                var result = userBussiness.UserRegistration(model);

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
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserLogin userLogin)
        {
            try
            {
                string Login = userBussiness.Login(userLogin);

                if (Login != null)
                {

                    return this.Ok(new { success = true, message = $"login successful for {userLogin.Email}", token = Login });
                }
                else
                {

                    return BadRequest(new { Success = false, message = $"login failed for {userLogin.Email}" });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("Users")]
        public IActionResult Users()
        {
            try
            {
                IEnumerable<UserEntity> GetAll = userBussiness.GetAll();

                if (GetAll != null)
                {
                    return this.Ok(new { success = true, message = "Retrive All Successful ", data = GetAll });


                }
                else
                {

                    return this.Ok(new { success = true, message = "Retrive All Unsuccessful " });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
        
        [HttpGet("")]
        [Route("GetById")]
        public IActionResult GetById([FromQuery]long getById)
            {
            try
            {
                var user = userBussiness.GetById(getById);

                if (user != null)
                {

                    return this.Ok(new { success = true, message = "User Found successful ", data = user });
                }
                else
                {

                    return BadRequest(new { Success = false, message = "User Not Found" });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     */
        [HttpPost]
        [Route("forget-password/{email}")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {

                var result = userBussiness.ForgetPassword(email);

                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Forget Password Token Generated Successfully", Token = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Forget Password Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [Route("reset-password/{pass}/{cpass}/{token}")]
        public IActionResult ResetPassword(string pass, string cpass, string token)
        {
            try
            {
                string GetEmail = User.FindFirst(ClaimTypes.Email).Value.ToString();

                var result = userBussiness.ResetPassword(token, pass, cpass);

                if (result == true)
                {
                    return Ok(new { sucess = true, message = "Forget Password Token Generated Successfully" });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Forget Password Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        



    }

 
}
