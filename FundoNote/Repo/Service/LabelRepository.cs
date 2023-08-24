using Common.Model;
using Repo.Context;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repo.Service
{
    public class LabelRepository : ILabelRepository
    {
        public readonly FundoContext context;
        public LabelRepository(FundoContext fundoContext) 
        {
            this.context = fundoContext;
        }

        public LabelEntity AddLabel(LabelModel model)
        {
            try
            {
                LabelEntity labelEntity = new LabelEntity();

                labelEntity.LabelName = model.LabelName;
                labelEntity.userId = model.userId;
                labelEntity.NoteId = model.NoteId;

                if (labelEntity != null)
                {
                    context.Labels.Add(labelEntity);

                    context.SaveChanges();

                    return labelEntity;
                }
                else
                {
                    return null;
                }  
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<LabelEntity> GetLabels(long UserId, long NoteId)
        {

            try
            {
                var result = context.Labels.Where(x => x.userId == UserId && x.NoteId == NoteId);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }

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
                var result = context.Labels.FirstOrDefault(x => x.userId == UserId && x.NoteId == NoteId && x.LabelId == LabelId);

                if (result != null)
                {
                    context.Remove(result);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

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
                LabelEntity labelEntity = new LabelEntity();

                labelEntity = context.Labels.FirstOrDefault(x => x.userId == UserId && x.LabelId == LabelId);



                if (labelEntity != null)
                {
                    labelEntity.LabelName = LabelName;

                    context.Update(labelEntity);
                    context.SaveChanges();
                    return labelEntity;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



       

    }
}
