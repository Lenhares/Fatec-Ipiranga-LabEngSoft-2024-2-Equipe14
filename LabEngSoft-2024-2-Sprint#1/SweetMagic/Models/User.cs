namespace SweetMagic.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
