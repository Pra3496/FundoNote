using Common.Model;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repo.Interface
{
    public interface IColabRepository
    {
        public ColabEntity CreateColab(long NoteId, long UserId, ColabModel model);

        public IEnumerable<ColabEntity> GetAll(long NoteId, long UserId);

        public bool DeleteColab(long ColabId, long NoteId, long UserId);


    }
}
