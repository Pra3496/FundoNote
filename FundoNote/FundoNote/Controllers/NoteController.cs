using Bussiness.Interface;
using Common.Model;
using FundoNote.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace FundoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        public readonly INoteBussiness noteBussiness;

        public readonly AppSettings appSettings;

        public NoteController(INoteBussiness noteBussiness)
        {
            this.noteBussiness = noteBussiness;
          
        }

        [HttpPost]
        [Route("addNote")]
        public IActionResult CreateNote(NoteModel model)
        {
            try
            {
                //long UserId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = this.noteBussiness.CreateNote(model, UserId);

                if(result != null)
                {
                    return Ok(new { sucess = true, message = "Note Created Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Note Created Unsuccessfully" });
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("AllNote")]
        public IActionResult GetAllNote(long userId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = this.noteBussiness.GetAll(UserId);


                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Note Created Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Note Created Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateNote")]
        public IActionResult UpdateNote(NoteModel model, long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                model.userId = UserId;

                var result = this.noteBussiness.UpdateNote(model, NoteId);


                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Note Update Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Note Update Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("removeNote")]
        public IActionResult RemoveNote(long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

               

                var result = this.noteBussiness.RemoveNote(NoteId, UserId);


                if (result != false)
                {
                    return Ok(new { sucess = true, message = "Note Remove Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Note Remove Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
