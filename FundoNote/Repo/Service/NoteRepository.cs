using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common.Model;
using EFCoreCodeFirstSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repo.Context;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Service
{
    public class NoteRepository : INoteRepository
    {
        public readonly IConfiguration Iconfiguration;

        public readonly FundoContext context;

       
        public NoteRepository(IConfiguration Iconfiguration, FundoContext context) 
        { 
            this.Iconfiguration = Iconfiguration;
            this.context = context;
        }

        public async Task<NoteEntity> CreateNote(NoteModel model, long UserId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity.Tittle = model.Tittle;
                noteEntity.Note = model.Note;
                noteEntity.Color = model.Color;
                noteEntity.RemindMe = model.RemindMe;

                noteEntity.CreateTime = DateTime.Now;
                noteEntity.UpdateTime = DateTime.Now;
                noteEntity.userId = UserId;

                if (noteEntity != null)
                {
                    await context.Notes.AddAsync(noteEntity);
                    await context.SaveChangesAsync();
                    return noteEntity;
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

        public async Task<IEnumerable<NoteEntity>> GetAll(long UserId)
        {
            try
            {
                var users = await context.Notes.ToListAsync();

                var specificUsers = users.FindAll(x => x.userId == UserId);

                if (specificUsers != null)
                {
                    return specificUsers;
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

        public async Task<NoteEntity> UpdateNote(NoteUpdateModel model, long NoteId, long UserId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = await context.Notes.FirstOrDefaultAsync(x => x.userId == UserId && x.NoteId == NoteId);


                if (noteEntity != null)
                {
                    noteEntity.Tittle = model.Tittle;
                    noteEntity.Note = model.Note;
                    noteEntity.UpdateTime = DateTime.Now;

                    await context.SaveChangesAsync();

                    return noteEntity;

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


        public async Task<bool> RemoveNote(long NoteId, long UserId)
        {
            try
            {

                var user = await context.Notes.FirstOrDefaultAsync(x => x.NoteId == NoteId && x.userId == UserId);


                if (user != null)
                {
                    context.Notes.Remove(user);
                    await context.SaveChangesAsync();

                    return true;

                }
                else
                {
                    return false;
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NoteEntity> IsArchive(long NoteId, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = await context.Notes.FirstOrDefaultAsync(x => x.userId == userId && x.NoteId == NoteId);


                if (noteEntity != null)
                {
                    if (noteEntity.IsArchive == false)
                    {
                        noteEntity.IsArchive = true;
                    }
                    else
                    {
                        noteEntity.IsArchive = false;
                    }

                    context.Notes.Update(noteEntity);

                    await context.SaveChangesAsync();

                    return noteEntity;

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

        public async Task<NoteEntity> IsPin(long NoteId, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = await context.Notes.FirstOrDefaultAsync(x => x.userId == userId && x.NoteId == NoteId);


                if (noteEntity != null)
                {
                    if (noteEntity.IsPin == false)
                    {
                        noteEntity.IsPin = true;
                    }
                    else
                    {
                        noteEntity.IsPin = false;
                    }

                    context.Notes.Update(noteEntity);

                    await context.SaveChangesAsync();

                    return noteEntity;

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

        public async Task<NoteEntity> IsTrash(long NoteId, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = await context.Notes.FirstOrDefaultAsync(x => x.userId == userId && x.NoteId == NoteId);


                if (noteEntity != null)
                {
                    if (noteEntity.IsTrash == false)
                    {
                        noteEntity.IsTrash = true;
                    }
                    else
                    {
                        noteEntity.IsTrash = false;
                    }

                    context.Notes.Update(noteEntity);

                    context.SaveChanges();

                    return noteEntity;

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

        public async Task<NoteEntity> ChangeColor(string color, long NoteId, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = await context.Notes.FirstOrDefaultAsync(x => x.userId == userId && x.NoteId == NoteId);


                if (noteEntity != null)
                {

                    noteEntity.Color = color;

                    context.Notes.Update(noteEntity);

                    await context.SaveChangesAsync();

                    return noteEntity;

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

        public async Task<NoteEntity> SetReminder(long NoteId, long userId, DateTime date)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = await context.Notes.FirstOrDefaultAsync(x => x.userId == userId && x.NoteId == NoteId);


                if (noteEntity != null)
                {
                    noteEntity.RemindMe = date;

                    context.Notes.Update(noteEntity);

                    await context.SaveChangesAsync();

                    return noteEntity;

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


        public async Task<NoteEntity> UploadImage(long userId, long NoteId, IFormFile image)
        {
            try
            {
                Account cloudinaryAccount = new Account(
                  Iconfiguration["Cloudinary:CloudName"],
                  Iconfiguration["Cloudinary:APIkey"],
                  Iconfiguration["Cloudinary:cloudAPISecret"]
                 );

                NoteEntity noteEntity = new NoteEntity();

                noteEntity = await context.Notes.FirstOrDefaultAsync(x => x.userId == userId && x.NoteId == NoteId);

                if (noteEntity != null)
                {
                    Cloudinary cloudinary = new Cloudinary(cloudinaryAccount);

                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, image.OpenReadStream()),
                        Transformation = new Transformation().Crop("fit").Gravity("face"),
                    };

                    string uploadResult = cloudinary.Upload(uploadParams).SecureUrl.ToString();

                    noteEntity.Image = uploadResult;

                    context.Update(noteEntity);

                    await context.SaveChangesAsync();

                    return noteEntity;
                }
                else
                {
                    return noteEntity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

    
}
