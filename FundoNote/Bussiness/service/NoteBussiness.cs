using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Http;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.service
{
    public class NoteBussiness : INoteBussiness
    {
        public readonly INoteRepository noteRepository;

        public NoteBussiness(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public NoteEntity CreateNote(NoteModel model, long UserId)
        {
            try
            {
                return noteRepository.CreateNote(model, UserId);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public IEnumerable<NoteEntity> GetAll(long UserId)
        {
            try
            {
                return noteRepository.GetAll(UserId);
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
                return noteRepository.UpdateNote(model, NoteId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveNote(long NoteId, long UserId)
        {
            try
            {
                return noteRepository.RemoveNote(NoteId, UserId);
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
                return noteRepository.IsArchive(NoteId, userId);
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
                return noteRepository.IsPin(NoteId, userId);
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
                return noteRepository.IsTrash(NoteId, userId);
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
                return noteRepository.ChangeColor(color, NoteId, userId);
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
                return noteRepository.SetReminder(NoteId, userId, date);    
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
                return noteRepository.UploadImage(userId, NoteId, image);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
