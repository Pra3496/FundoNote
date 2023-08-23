using Bussiness.Interface;
using Common.Model;
using Repo.Entities;
using Repo.Interface;
using Repo.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.service
{
    public class ColabBussiness : IColabBussiness
    {
        public readonly IColabRepository colabRepository;

        public ColabBussiness(IColabRepository IcolabRepository)
        {
            this.colabRepository = IcolabRepository;
        }

        public ColabEntity CreateColab(long NoteId, long UserId, ColabModel model)
        {
            try
            {
                return colabRepository.CreateColab(NoteId, UserId, model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ColabEntity> GetAll(long NoteId, long UserId)
        {
            try
            {
                return colabRepository.GetAll(NoteId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteColab(long ColabId, long NoteId, long UserId)
        {
            try
            {
                return colabRepository.DeleteColab(ColabId, NoteId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
