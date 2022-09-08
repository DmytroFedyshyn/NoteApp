using NoteApp.Models;

namespace NoteApp
{
    public interface INote
    {
        Task<IEnumerable<Note>> GetAllNotesForUserAsync(string? userId);
        Task<Note> GetNoteForUserAsync(string? userId, int noteId);

        Task AddNote(Note note);
        Task DeleteNote(Note note);
        Task UpdateNote(Note note);
    }
}
