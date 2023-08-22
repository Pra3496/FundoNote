using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common.Model;
using EFCoreCodeFirstSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Repo.Context;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

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

        public NoteEntity CreateNote(NoteModel model, long UserId)
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

                if(noteEntity != null)
                {
                    context.Notes.Add(noteEntity);
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

        public IEnumerable<NoteEntity> GetAll(long UserId)
        {
            try
            {
                var users = context.Notes.ToList();

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

        public NoteEntity UpdateNote(NoteUpdateModel model, long NoteId, long UserId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = context.Notes.FirstOrDefault(x => x.userId == UserId && x.NoteId == NoteId);


                if(noteEntity != null)
                {
                    noteEntity.Tittle = model.Tittle;
                    noteEntity.Note = model.Note;
                    noteEntity.UpdateTime = DateTime.Now;

                    context.SaveChanges();

                    return noteEntity;

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


        public bool RemoveNote(long NoteId, long UserId)
        {
            try
            {

                var user = context.Notes.FirstOrDefault(x => x.NoteId == NoteId && x.userId == UserId);


                if (user != null)
                {
                    context.Notes.Remove(user);
                    context.SaveChanges();

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

        public NoteEntity IsArchive(long NoteId, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = context.Notes.FirstOrDefault(x => x.userId == userId && x.NoteId == NoteId);


                if (noteEntity != null)
                {
                    if(noteEntity.IsArchive == false)
                    {
                        noteEntity.IsArchive = true;
                    }
                    else
                    {
                        noteEntity.IsArchive = false;
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

        public NoteEntity IsPin(long NoteId, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = context.Notes.FirstOrDefault(x => x.userId == userId && x.NoteId == NoteId);


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

        public NoteEntity IsTrash(long NoteId, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = context.Notes.FirstOrDefault(x => x.userId == userId && x.NoteId == NoteId);


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

        public NoteEntity ChangeColor(string color, long NoteId, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = context.Notes.FirstOrDefault(x => x.userId == userId && x.NoteId == NoteId);


                if (noteEntity != null)
                {
                   
                    noteEntity.Color = color;
               
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

        public NoteEntity SetReminder(long NoteId, long userId, DateTime date)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = context.Notes.FirstOrDefault(x => x.userId == userId && x.NoteId == NoteId);


                if (noteEntity != null)
                {
                    noteEntity.RemindMe = date;

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


        public NoteEntity UploadImage(long userId, long NoteId, IFormFile image)
        {
            try
            {
                Account cloudinaryAccount = new Account(
                  Iconfiguration["Cloudinary:CloudName"],
                  Iconfiguration["Cloudinary:APIkey"],
                  Iconfiguration["Cloudinary:cloudAPISecret"]
                 );

                NoteEntity noteEntity = new NoteEntity();

                noteEntity = context.Notes.FirstOrDefault(x => x.userId == userId && x.NoteId == NoteId);

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

                    context.SaveChanges();

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
