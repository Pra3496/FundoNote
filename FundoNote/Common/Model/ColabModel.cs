using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Model
{
    public class ColabModel
    {
        public string Email { get; set; }
        public long userId { get; set; }
        public long NoteId { get; set; }
    }
}
