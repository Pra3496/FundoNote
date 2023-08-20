using Common.Model;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface INoteBussiness
    {
        public NoteEntity CreateNote(NoteModel model, long UserId);

        public List<NoteEntity> GetAll(long UserId);
        public NoteEntity UpdateNote(NoteModel model, long NoteId);

        public bool RemoveNote(long NoteId, long UserId);
    }
}
