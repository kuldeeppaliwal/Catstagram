using System.ComponentModel.DataAnnotations;

namespace Catstagram.server.Data
{
    public class Cat
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
