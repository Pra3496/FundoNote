using Bussiness.Interface;
using Common.Model;
using Repo.Entities;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.service
{
    public class NoteBussiness : INoteBussiness
    {
        public readonly INoteRepository noteRepository;

        public NoteBussiness(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public NoteEntity CreateNote(NoteModel model, long UserId)
        {
            try
            {
                return noteRepository.CreateNote(model, UserId);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
