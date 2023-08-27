using Common.Model;
using Microsoft.AspNetCore.Http;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interface
{
    public interface INoteBussiness
    {
        Task<NoteEntity> CreateNote(NoteModel model, long UserId);
        Task<IEnumerable<NoteEntity>> GetAll(long UserId);
        Task<NoteEntity> UpdateNote(NoteUpdateModel model, long NoteId, long UserId);
        Task<bool> RemoveNote(long NoteId, long UserId);
        Task<NoteEntity> IsArchive(long NoteId, long userId);
        Task<NoteEntity> IsPin(long NoteId, long userId);
        Task<NoteEntity> IsTrash(long NoteId, long userId);
        Task<NoteEntity> ChangeColor(string color, long NoteId, long userId);
        Task<NoteEntity> SetReminder(long NoteId, long userId, DateTime date);
        Task<NoteEntity> UploadImage(long userId, long NoteId, IFormFile image);

    }
}
