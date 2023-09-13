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
    public class LabelBussiness : ILabelBussiness
    {
        public readonly ILabelRepository labelRepository;


        public LabelBussiness(ILabelRepository IlabelRepository)
        {
            this.labelRepository = IlabelRepository;
        }

        
        

        public async Task<LabelEntity> AddLabel(LabelModel model)
        {
            try
            {
                return await labelRepository.AddLabel(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    

        public async Task<IEnumerable<LabelEntity>> GetLabels(long UserId, long NoteId)
        {
            try
            {
                return await labelRepository.GetLabels(UserId, NoteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> RemoveLabel(long UserId, long NoteId, long LabelId)
        {
            try
            {
                return await labelRepository.RemoveLabel(UserId, NoteId, LabelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<LabelEntity> UpdateLabel(string LabelName, long UserId, long LabelId)
        {
            try
            {
                return await labelRepository.UpdateLabel(LabelName, UserId, LabelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
  
    

