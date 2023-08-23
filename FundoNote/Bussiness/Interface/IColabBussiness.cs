using Common.Model;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface IColabBussiness
    {
        public ColabEntity CreateColab(long NoteId, long UserId, ColabModel model);

        public IEnumerable<ColabEntity> GetAll(long NoteId, long UserId);

        public bool DeleteColab(long ColabId, long NoteId, long UserId);
    }
}
