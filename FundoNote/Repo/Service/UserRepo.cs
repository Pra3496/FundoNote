using EFCoreCodeFirstSample.Models;
using Repo.Context;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using Common.Model;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Repo.Service
{
    public class UserRepo : IUserRepo
    {

        public readonly IConfiguration Iconfiguration;

        private readonly FundoContext fundoContext;

        public UserRepo(FundoContext fundoContext, IConfiguration Iconfiguration)
        {
            this.fundoContext = fundoContext;
            this.Iconfiguration = Iconfiguration;
        }
        

        public UserEntity UserRegistration(UserRegestrationModel userResgistrationModel)
        {
            try
            {
                UserEntity userEntity = new UserEntity();

                userEntity.FirstName = userResgistrationModel.FirstName;
                userEntity.LastName = userResgistrationModel.LastName;
                
                userEntity.Email = userResgistrationModel.Email;

                userEntity.Password = EncryptPass(userResgistrationModel.Password);

                fundoContext.Users.Add(userEntity);

                fundoContext.SaveChanges();


                if(userEntity != null)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }

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
                UserEntity user = new UserEntity();

                user = fundoContext.Users.FirstOrDefault(x => x.Email == userLogin.Email);

                string email = user.Email;
                string Dpassword = Decrpt(user.Password);
                string userId = Convert.ToString(user.UserID);

                if (user != null && Dpassword == userLogin.Password)
                {
                    var token = GenerateJWTToken(email, userId);
                    return token;
                  
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<UserEntity> GetAll()
        {
            try
            {
                var users = fundoContext.Users.ToList();



                if (users != null)
                {
                    return users;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserEntity GetById(long userId)
        {
            try
            {
                var user = fundoContext.Users.FirstOrDefault(x => x.UserID == userId);



                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GenerateJWTToken(string email, string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(Iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, email),
                        new Claim("UserID", userId)
                    }
                    
                    ),
              
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


        public string ForgetPassword(string email)
        {
            try
            {
                UserEntity user = new UserEntity();


                user = fundoContext.Users.FirstOrDefault(x => x.Email == email);
                
                string userId = user.UserID.ToString();

                

                if (user != null)
                {
                    string Token = GenerateJWTToken(email, userId);

                    MSMQService sMQService = new MSMQService();

                    sMQService.sendData2Queue(Token);

                    return Token;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                throw;
            }


        }

        public bool ResetPassword(string Token, string Pass, string CPass)
        {

            string GetEmail = jwtToken(Token);
            //string GetuserId = User.FindFirst("UserID").Value.ToString();

            try
            {
                UserEntity user = new UserEntity();


                user = fundoContext.Users.FirstOrDefault(x => x.Email == GetEmail);
                
                
                if (user != null && Pass == CPass)
                {
                    user.Password = EncryptPass(Pass);

                    fundoContext.Users.Update(user);

                    fundoContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                throw;
            }


        }

        public string EncryptPass(string password)
        {
            try
            {
                string msg = "";
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                msg = Convert.ToBase64String(encode);
                return msg;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Decrpt(string encodedData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string jwtToken(string token)
        {
            var decodedToken = token;
            var handlaer = new JwtSecurityTokenHandler();
            var jsonToken = handlaer.ReadJwtToken(decodedToken);
            var result = jsonToken.Claims.FirstOrDefault().Value;
            return result;
        }


    }
}
