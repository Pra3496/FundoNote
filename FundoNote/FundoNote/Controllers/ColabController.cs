using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        [Route("GetAll")]
        public IActionResult GetAll(long NoteId) 
        {
            long UserId = long.Parse(User.FindFirst("UserID").Value);

            try
            {
                var result = colabBussiness.GetAll(NoteId, UserId);
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
        [Route("Create")]
        public IActionResult Create(long NoteId, ColabModel model)
        {
            long UserId = long.Parse(User.FindFirst("UserID").Value);

            try
            {
                var result = colabBussiness.CreateColab(NoteId, UserId, model);

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
        [Route("Remove")]
        public IActionResult DeleteColab(long ColabId, long NoteId)
        {
            long UserId = long.Parse(User.FindFirst("UserID").Value);

            try
            {
                var result = colabBussiness.DeleteColab(ColabId, NoteId, UserId);

                if (result != true)
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
