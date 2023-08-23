using EFCoreCodeFirstSample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repo.Entities
{
    public class ColabEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ColabId { get; set; }

        public string Email { get; set; }



        [ForeignKey("Users")]
        public long userId { get; set; }
        public virtual UserEntity User { get; set; }

        [ForeignKey("Notes")]
        public long NoteId { get; set; }
        public virtual NoteEntity Note { get; set; }
    }

}
