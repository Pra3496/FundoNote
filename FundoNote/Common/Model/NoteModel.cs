using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class NoteModel
    {
        public long NoteId { get; set; }

        public string Tittle { get; set; }

        public string Note { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        public DateTime? RemindMe { get; set; }

    }
}
