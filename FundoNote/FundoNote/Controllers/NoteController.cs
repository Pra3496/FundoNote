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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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



    }
}
