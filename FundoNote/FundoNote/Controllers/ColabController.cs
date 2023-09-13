using Bussiness.Interface;
using Common.Model;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColabController : ControllerBase
    {
        public readonly IColabBussiness colabBussiness;

        private readonly IPublishEndpoint publishEndpoint;

        public ColabController(IColabBussiness IcolabBussiness, IPublishEndpoint publishEndpoint)
        {
            this.colabBussiness = IcolabBussiness;
            this.publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            long UserId = long.Parse(User.FindFirst("UserID").Value);

            string colabs = User.FindFirst("Colabs").Value; 

            try
            {
                var result = await colabBussiness.GetAll(UserId, colabs);
                if(result != null)
                {
                    return Ok(new { sucess = true, message = "Colaboration Create Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Colaboration Create Unsuccessfully" });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(long NoteId, ColabModel model)
        {
            long UserId = long.Parse(User.FindFirst("UserID").Value);

            try
            {
                var result = await colabBussiness.CreateColab(NoteId, UserId, model);


                if (result != null)
                {
                    ColabEmailModel colabEmailModel = new ColabEmailModel()
                    {
                        ColabId = result.ColabId,
                        Email = result.Email
                    };

                    await publishEndpoint.Publish<ColabEmailModel>(colabEmailModel);

                    return Ok(new { sucess = true, message = "Colaboration Create Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Colaboration Create Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteColab(long ColabId, long NoteId)
        {
            long UserId = long.Parse(User.FindFirst("UserID").Value);

            try
            {
                var result = await colabBussiness.DeleteColab(ColabId, NoteId, UserId);

                if (result == true)
                {
                    return Ok(new { sucess = true, message = "Colaboration Remove Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Colaboration Remove Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
