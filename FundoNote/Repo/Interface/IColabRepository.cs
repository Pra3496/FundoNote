﻿using Common.Model;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IColabRepository
    {
        Task<ColabEntity> CreateColab(long NoteId, long UserId, ColabModel model);

        Task<IEnumerable<ColabEntity>> GetAll(long UserId, string colabs);

        Task<bool> DeleteColab(long ColabId, long NoteId, long UserId);


    }
}
