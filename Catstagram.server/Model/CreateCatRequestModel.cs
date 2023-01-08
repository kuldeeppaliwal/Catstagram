namespace Catstagram.server.Model
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Validation.Cat;

    public class CreateCatRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
