﻿using Bussiness.Interface;
using Bussiness.service;
using Common.Model;
using EFCoreCodeFirstSample.Models;
using FundoNote.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        public readonly INoteBussiness noteBussiness;

        public readonly AppSettings appSettings;

        public NoteController(INoteBussiness noteBussiness, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.noteBussiness = noteBussiness;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;

        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(NoteModel model)
        {
            try
            {

                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.noteBussiness.CreateNote(model, UserId);

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
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllNote()
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.noteBussiness.GetAll(UserId);


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
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNote(NoteUpdateModel model, long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);



                var result = await this.noteBussiness.UpdateNote(model, NoteId, UserId);


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
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveNote(long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);



                var result = await this.noteBussiness.RemoveNote(NoteId, UserId);


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
                throw new Exception(ex.Message);
            }
        }


        [HttpPatch]
        [Route("Archive")]
        public async Task<IActionResult> GetArchive(long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.noteBussiness.IsArchive(NoteId, UserId);

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
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch]
        [Route("Pin")]
        public async Task<IActionResult> GetPin(long NoteId)
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
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch]
        [Route("Trash")]
        public async Task<IActionResult> GetIsTrash(long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.noteBussiness.IsTrash(NoteId, UserId);

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
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch]
        [Route("Color")]
        public async Task<IActionResult> ChangeColor(string color, long NoteId)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.noteBussiness.ChangeColor(color, NoteId, UserId);

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
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch]
        [Route("Image")]
        public async Task<IActionResult> UploadImage(long NoteId, IFormFile image)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.noteBussiness.UploadImage(UserId, NoteId, image);

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
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("redis")]
        public async Task<IActionResult> GetAllNotesUsingRedisCache()
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var cacheKey = "customerList";
                string serializedCustomerList;

                var redisCustomerList = await distributedCache.GetAsync(cacheKey);
                if (redisCustomerList != null)
                {
                    serializedCustomerList = Encoding.UTF8.GetString(redisCustomerList);
                    var notes = JsonConvert.DeserializeObject<IEnumerable<NoteEntity>>(serializedCustomerList);

                    return this.Ok(new { success = true, message = "Retrive All Successful ", data = notes });
                }
                else
                {
                    var notes = await this.noteBussiness.GetAll(UserId);
                    serializedCustomerList = JsonConvert.SerializeObject(notes);
                    redisCustomerList = Encoding.UTF8.GetBytes(serializedCustomerList);
                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                    await distributedCache.SetAsync(cacheKey, redisCustomerList, options);

                    return this.Ok(new { success = true, message = "Retrive All Successful ", data = notes });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        [HttpGet("search")]
        
        public async Task<IActionResult> GetSearchResult(string search)
        {
            try
            {
                long UserId = long.Parse(User.FindFirst("UserID").Value);

                var result = await this.noteBussiness.GetSearchResult(search, UserId);


                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Note search Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { sucess = false, message = "Note Search Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }






    }
}
