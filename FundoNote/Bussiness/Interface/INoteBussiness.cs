using Common.Model;
using Microsoft.AspNetCore.Http;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface INoteBussiness
    {
        public NoteEntity CreateNote(NoteModel model, long UserId);

        public IEnumerable<NoteEntity> GetAll(long UserId);

        public NoteEntity UpdateNote(NoteUpdateModel model, long NoteId, long UserId);

        public bool RemoveNote(long NoteId, long UserId);

        public NoteEntity IsArchive(long NoteId, long userId);

        public NoteEntity IsPin(long NoteId, long userId);

        public NoteEntity IsTrash(long NoteId, long userId);

        public NoteEntity ChangeColor(string color, long NoteId, long userId);

        public NoteEntity SetReminder(long NoteId, long userId, DateTime date);

        public NoteEntity UploadImage(long userId, long NoteId, IFormFile image);



    }
}
