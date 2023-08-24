using Common.Model;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface ILabelBussiness
    {
        public LabelEntity AddLabel(LabelModel model);
        public IEnumerable<LabelEntity> GetLabels(long UserId, long NoteId);
        public bool RemoveLabel(long UserId, long NoteId, long LabelId);
        public LabelEntity UpdateLabel(string LabelName, long UserId, long LabelId);
    }
}
