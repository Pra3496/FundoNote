using Bussiness.Interface;
using Common.Model;
using FundoNote.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repo.Entities;
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
        public IActionResult UpdateNote(NoteUpdateModel model, long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

               

                var result = this.noteBussiness.UpdateNote(model, NoteId, UserId);


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


        [HttpPatch]
        [Route("IsAchive")]
        public IActionResult GetArchive(long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = this.noteBussiness.IsArchive(NoteId, UserId);

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

        [HttpPatch]
        [Route("IsPin")]
        public IActionResult GetPin(long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = this.noteBussiness.IsPin(NoteId, UserId);

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

        [HttpPatch]
        [Route("IsTrash")]
        public IActionResult GetIsTrash(long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = this.noteBussiness.IsTrash(NoteId, UserId);

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

        [HttpPatch]
        [Route("ChangeColor")]
        public IActionResult ChangeColor(string color, long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = this.noteBussiness.ChangeColor(color, NoteId, UserId); 

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

        [HttpPatch]
        [Route("Uploadimage")]
        public IActionResult UploadImage(long NoteId, IFormFile image)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = this.noteBussiness.UploadImage(UserId, NoteId, image);

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





    }
}
