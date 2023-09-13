using Common.Model;
using Microsoft.EntityFrameworkCore;
using Repo.Context;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Service
{
    public class LabelRepository : ILabelRepository
    {
        public readonly FundoContext context;
        public LabelRepository(FundoContext fundoContext) 
        {
            this.context = fundoContext;
        }

        public async Task<LabelEntity> AddLabel(LabelModel model)
        {
            try
            {
                LabelEntity labelEntity = new LabelEntity();

                labelEntity.LabelName = model.LabelName;
                labelEntity.userId = model.userId;
                labelEntity.NoteId = model.NoteId;

                if (labelEntity != null)
                {
                    await context.Labels.AddAsync(labelEntity);

                    await context.SaveChangesAsync();

                    return labelEntity;
                }
                else
                {
                    return null;
                }  
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<LabelEntity>> GetLabels(long UserId, long NoteId)
        {

            try
            {
                var result = await context.Labels.Where(x => x.userId == UserId && x.NoteId == NoteId).ToListAsync();

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
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> RemoveLabel(long UserId, long NoteId, long LabelId)
        {
            try
            {
                var result = await context.Labels.FirstOrDefaultAsync(x => x.userId == UserId && x.NoteId == NoteId && x.LabelId == LabelId);

                if (result != null)
                {
                    context.Remove(result);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

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
                LabelEntity labelEntity = new LabelEntity();

                labelEntity = await context.Labels.FirstOrDefaultAsync(x => x.userId == UserId && x.LabelId == LabelId);



                if (labelEntity != null)
                {
                    labelEntity.LabelName = LabelName;

                    context.Update(labelEntity);
                    await context.SaveChangesAsync();
                    return labelEntity;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



       

    }
}
