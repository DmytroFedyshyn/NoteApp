using System.ComponentModel.DataAnnotations;

namespace NoteApp.ViewModels
{
    public class NoteViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название заметки")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Не указано описание заметки")]
        public string? Description { get; set; }
    }
}
