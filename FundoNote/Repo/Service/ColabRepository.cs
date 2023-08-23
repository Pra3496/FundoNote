using Common.Model;
using Microsoft.Extensions.Configuration;
using Repo.Context;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public ColabEntity CreateColab(long NoteId, long UserId,ColabModel model)
        {
            try
            {
                ColabEntity colabEntity = new ColabEntity();

                colabEntity.NoteId = NoteId;
                colabEntity.userId = UserId;

                colabEntity.Email = model.Email;


               
                if (colabEntity != null)
                {
                    context.Colab.Add(colabEntity);

                    context.SaveChanges();

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
       

        public IEnumerable<ColabEntity> GetAll(long NoteId, long UserId)
        {
            try
            {
                var result = context.Colab.Where(x=> x.userId == UserId && x.NoteId == NoteId).ToList();

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

        public bool DeleteColab(long ColabId, long NoteId, long UserId)
        {
            try
            {
                var result = context.Colab.FirstOrDefault(x => x.userId == UserId && x.NoteId == NoteId && x.ColabId == ColabId);

                if (result != null)
                {
                    context.Colab.Remove(result);

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




    }
}
