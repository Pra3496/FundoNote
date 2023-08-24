using EFCoreCodeFirstSample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repo.Entities
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }

        public string LabelName { get; set; }

        [ForeignKey("Users")]
        public long userId { get; set; }

        [JsonIgnore]
        public virtual UserEntity User { get; set; }

        [ForeignKey("Notes")]
        public long NoteId { get; set; }

        [JsonIgnore]
        public virtual NoteEntity Note { get; set; }
    }
}
