using Common.Model;
using Microsoft.Extensions.Configuration;
using Repo.Context;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repo.Interface
{
    public interface INoteRepository 
    {
        public NoteEntity CreateNote(NoteModel model, long UserId);

        public List<NoteEntity> GetAll(long UserId);

        public NoteEntity UpdateNote(NoteModel model, long NoteId);

        public bool RemoveNote(long NoteId, long UserId);
    }
}
