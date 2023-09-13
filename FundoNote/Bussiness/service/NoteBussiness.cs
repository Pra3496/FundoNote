using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Http;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bussiness.service
{
    public class NoteBussiness : INoteBussiness
    {
        public readonly INoteRepository noteRepository;

        public NoteBussiness(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public async Task<NoteEntity> CreateNote(NoteModel model, long UserId)
        {
            try
            {
                return await noteRepository.CreateNote(model, UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<NoteEntity>> GetAll(long UserId)
        {
            try
            {
                return await noteRepository.GetAll(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NoteEntity> UpdateNote(NoteUpdateModel model, long NoteId, long UserId)
        {
            try
            {
                return await noteRepository.UpdateNote(model, NoteId, UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveNote(long NoteId, long UserId)
        {
            try
            {
                return await noteRepository.RemoveNote(NoteId, UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<NoteEntity> IsArchive(long NoteId, long userId)
        {
            try
            {
                return await noteRepository.IsArchive(NoteId, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NoteEntity> IsPin(long NoteId, long userId)
        {
            try
            {
                return await noteRepository.IsPin(NoteId, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NoteEntity> IsTrash(long NoteId, long userId)
        {
            try
            {
                return await noteRepository.IsTrash(NoteId, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NoteEntity> ChangeColor(string color, long NoteId, long userId)
        {
            try
            {
                return await noteRepository.ChangeColor(color, NoteId, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NoteEntity> SetReminder(long NoteId, long userId, DateTime date)
        {
            try
            {
                return await noteRepository.SetReminder(NoteId, userId, date);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NoteEntity> UploadImage(long userId, long NoteId, IFormFile image)
        {
            try
            {
                return await noteRepository.UploadImage(userId, NoteId, image);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<NoteEntity>> GetSearchResult(string sample, long UserId)
        {
            try
            {
                return await noteRepository.GetSearchResult(sample, UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
