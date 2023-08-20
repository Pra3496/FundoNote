using Common.Model;
using EFCoreCodeFirstSample.Models;
using Microsoft.Extensions.Configuration;
using Repo.Context;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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

                model.CreateTime = DateTime.UtcNow;
                model.UpdateTime = DateTime.UtcNow;

                noteEntity.Tittle = model.Tittle;
                noteEntity.Note = model.Note;
                noteEntity.Color = model.Color;
                noteEntity.RemindMe = model.RemindMe;
                noteEntity.Image = model.Image;
                noteEntity.IsArchive = model.IsArchive;
                noteEntity.IsPin = model.IsPin;
                noteEntity.IsTrash = model.IsTrash;
                noteEntity.CreateTime = model.CreateTime;
                noteEntity.UpdateTime = model.UpdateTime;
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

        public List<NoteEntity> GetAll(long UserId)
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

        public NoteEntity UpdateNote(NoteModel model, long NoteId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();

                noteEntity = context.Notes.FirstOrDefault(x => x.userId == model.userId && x.NoteId == NoteId);


                if(noteEntity != null)
                {
                    noteEntity.Tittle = model.Tittle;
                    noteEntity.Note = model.Note;
                    noteEntity.Color = model.Color;
                    noteEntity.RemindMe = model.RemindMe;
                    noteEntity.Image = model.Image;
                    noteEntity.IsArchive = model.IsArchive;
                    noteEntity.IsPin = model.IsPin;
                    noteEntity.IsTrash = model.IsTrash;
                    noteEntity.UpdateTime = DateTime.Now;
                    noteEntity.userId = model.userId;

                    //context.Notes.Update(noteEntity);

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
                NoteEntity noteEntity = new NoteEntity();

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

    }

    
}
