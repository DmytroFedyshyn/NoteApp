using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NoteApp.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INote _notes;
        public NoteController(INote notes)
        {
            _notes = notes;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }
            var allNotes =  await _notes.GetAllNotesForUserAsync(userId);
            return View(allNotes);
        }
    }
}
