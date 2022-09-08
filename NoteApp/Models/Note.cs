namespace NoteApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastChangeDate { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
