using Microsoft.EntityFrameworkCore;
using NoteApp.Models;

namespace NoteApp.Data.Repository
{
    public class NoteRepository : INote
    {
        private readonly ApplicationContext _context;
        public NoteRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Note>> GetAllNotesForUserAsync(string? userId)
        {
            return await _context.Notes.Where(e => e.UserId == userId).ToListAsync();
        }

        public async Task<Note> GetNoteForUserAsync(string? userId, int noteId)
        {
            return await _context.Notes.FirstOrDefaultAsync(e => e.Id == noteId && e.UserId == userId);
        }

        public async Task AddNote(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNote(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNote(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }
    }
}
