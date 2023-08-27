using Common.Model;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface ILabelRepository
    {
        Task<LabelEntity> AddLabel(LabelModel model);
        Task<IEnumerable<LabelEntity>> GetLabels(long UserId, long NoteId);
        Task<bool> RemoveLabel(long UserId, long NoteId, long LabelId);
        Task<LabelEntity> UpdateLabel(string LabelName, long UserId, long LabelId);
    }
}
