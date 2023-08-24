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
    public class LabelBussiness : ILabelBussiness
    {
        public readonly ILabelRepository labelRepository;


        public LabelBussiness(ILabelRepository IlabelRepository)
        {
            this.labelRepository = IlabelRepository;
        }

        public LabelEntity AddLabel(LabelModel model)
        {
            try
            {
                return labelRepository.AddLabel(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    

        public IEnumerable<LabelEntity> GetLabels(long UserId, long NoteId)
        {
            try
            {
                return labelRepository.GetLabels(UserId, NoteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool RemoveLabel(long UserId, long NoteId, long LabelId)
        {
            try
            {
                return labelRepository.RemoveLabel(UserId, NoteId, LabelId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public LabelEntity UpdateLabel(string LabelName, long UserId, long LabelId)
        {
            try
            {
                return labelRepository.UpdateLabel(LabelName, UserId, LabelId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
  
    

