using Bussiness.Interface;
using Common.Model;
using Repo.Entities;
using Repo.Interface;
using Repo.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.service
{
    public class ColabBussiness : IColabBussiness
    {
        public readonly IColabRepository colabRepository;

        public ColabBussiness(IColabRepository IcolabRepository)
        {
            this.colabRepository = IcolabRepository;
        }

        
        public async Task<ColabEntity> CreateColab(long NoteId, long UserId, ColabModel model)
        {
            try
            {
                return await colabRepository.CreateColab(NoteId, UserId, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ColabEntity>> GetAll(long UserId, string colabs)
        {
            try
            {
                return await colabRepository.GetAll(UserId, colabs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteColab(long ColabId, long NoteId, long UserId)
        {
            try
            {
                return await colabRepository.DeleteColab(ColabId, NoteId, UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
