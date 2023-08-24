using Common.Model;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repo.Interface
{
    public interface ILabelRepository
    {
        public LabelEntity AddLabel(LabelModel model);
        public IEnumerable<LabelEntity> GetLabels(long UserId, long NoteId);
        public bool RemoveLabel(long UserId, long NoteId, long LabelId);
        public LabelEntity UpdateLabel(string LabelName, long UserId, long LabelId);
    }
}
