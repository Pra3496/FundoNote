using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FundoNote.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabelController : ControllerBase
    {
        public readonly ILabelBussiness labelBussiness;

        public LabelController(ILabelBussiness labelBussiness)
        {
            this.labelBussiness = labelBussiness;
        }


        [HttpPost]
        public async Task<IActionResult> AddLabel(LabelModel model)
        {
            try
            {

                long UserId = long.Parse(User.FindFirst("UserID").Value);

                model.userId= UserId;

                var result = await this.labelBussiness.AddLabel(model);

                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Label Created Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Label Created Unsuccessfully" });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(long noteId)
        {
            try
            {

                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.labelBussiness.GetLabels(UserId, noteId);

                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Labels Retrivel Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Labels Retrivel Unsuccessfully" });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateLabel(string LabelName, long LabelId)
        {
            try
            {

                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.labelBussiness.UpdateLabel(LabelName, UserId, LabelId);

                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Label Updated Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Label Updated Unsuccessfully" });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLabel(long NoteId, long LabelId)
        {
            try
            {

                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.labelBussiness.RemoveLabel(UserId, NoteId, LabelId);
                    

                if (result != false)
                {
                    return Ok(new { sucess = true, message = "Label Remove Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Label Remove Unsuccessfully" });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
