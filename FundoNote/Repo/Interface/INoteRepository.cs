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
    }
}
