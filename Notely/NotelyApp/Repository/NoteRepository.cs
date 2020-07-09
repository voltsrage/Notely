using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotelyApp.Models;

namespace NotelyApp.Repository
{
    public class NoteRepository : INoteRepository
    {
       private List<Note> _notes;

        public NoteRepository()
        {
            _notes = new List<Note>();
        }

        public Note FindNoteById(Guid id)
        {
            Note existingNote = _notes.Find(n => n.NoteID == id);
            return existingNote;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _notes;
        }

        public void SaveNote(Note note)
        {
            _notes.Add(note);
        }

        public void RemoveNote(Note note)
        {
            _notes.Remove(note);
        }
    }
}
