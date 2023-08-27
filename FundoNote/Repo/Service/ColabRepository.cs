using Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class ColabRepository : IColabRepository
    {
        public readonly IConfiguration Iconfiguration;

        public readonly FundoContext context;

        public ColabRepository(IConfiguration Iconfiguration, FundoContext context)
        {
            this.Iconfiguration = Iconfiguration;
            this.context = context;
        }

        public async Task<ColabEntity> CreateColab(long NoteId, long UserId,ColabModel model)
        {
            try
            {
                ColabEntity colabEntity = new ColabEntity();

                colabEntity.NoteId = NoteId;
                colabEntity.userId = UserId;

                colabEntity.Email = model.Email;


               
                if (colabEntity != null)
                {
                    await context.Colab.AddAsync(colabEntity);

                    await context.SaveChangesAsync();

                    return colabEntity;
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
       

        public async Task<IEnumerable<ColabEntity>> GetAll(long NoteId, long UserId)
        {
            try
            {
                var result = await context.Colab.Where(x=> x.userId == UserId && x.NoteId == NoteId).ToListAsync();

                if(result != null)
                {
                    return result;
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

        public async Task<bool> DeleteColab(long ColabId, long NoteId, long UserId)
        {
            try
            {
                var result = await context.Colab.FirstOrDefaultAsync(x => x.userId == UserId && x.NoteId == NoteId && x.ColabId == ColabId);

                if (result != null)
                {
                    context.Colab.Remove(result);

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
                throw ex;
            }
        }




    }
}
