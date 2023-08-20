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

        public List<NoteEntity> GetAll(long UserId)
        {
            try
            {
                return noteRepository.GetAll(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NoteEntity UpdateNote(NoteModel model, long NoteId)
        {
            try
            {
                return noteRepository.UpdateNote(model, NoteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveNote(long NoteId, long UserId)
        {
            try
            {
                return noteRepository.RemoveNote(NoteId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
