using EFCoreCodeFirstSample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repo.Entities
{
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NoteId { get; set; }

        public string Tittle { get; set; }

        public string Note { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        public bool IsArchive { get; set; }

        public bool IsPin { get; set; }

        public bool IsTrash { get; set; }

        public DateTime? RemindMe { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set;}


        [ForeignKey("Users")]

        public long userId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
