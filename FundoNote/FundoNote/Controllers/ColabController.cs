using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ColabController(IColabBussiness IcolabBussiness)
        {
            this.colabBussiness = IcolabBussiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(long NoteId) 
        {
            long UserId = long.Parse(User.FindFirst("UserID").Value);

            try
            {
                var result = await colabBussiness.GetAll(NoteId, UserId);
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
                throw ex;
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
                    return Ok(new { sucess = true, message = "Colaboration Create Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Colaboration Create Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }

    }
}
