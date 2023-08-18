using Common.Model;
using EFCoreCodeFirstSample.Models;
using Microsoft.Extensions.Configuration;
using Repo.Context;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
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
    }
}
