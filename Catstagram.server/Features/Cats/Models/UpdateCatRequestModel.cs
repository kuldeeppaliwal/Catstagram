namespace Catstagram.server.Features.Cats.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Validation.Cat;
    public class UpdateCatRequestModel
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
