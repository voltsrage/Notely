using System;
using System.Collections.Generic;
using NotelyApp.Models;

namespace NotelyApp.Repository
{
    public interface INoteRepository
    {
        Note FindNoteById(Guid id);
        IEnumerable<Note> GetAllNotes();
        void RemoveNote(Note note);
        void SaveNote(Note note);
    }
}