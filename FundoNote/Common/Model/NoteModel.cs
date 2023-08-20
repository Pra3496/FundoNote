using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class NoteModel
    {
        public string Tittle { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public bool IsArchive { get; set; }
        public bool IsPin { get; set; }
        public bool IsTrash { get; set; }
        public DateTime? RemindMe { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public long userId { get; set; }

    }
}
