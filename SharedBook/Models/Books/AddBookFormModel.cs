namespace SharedBook.Models.Books
{
    using System.ComponentModel.DataAnnotations;
    using SharedBook.Data.Models.Enums;
    using static Data.DataConstants;

    public class AddBookFormModel
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; init; }

        [Required]
        [MinLength(AuthorMinLength)]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; init; }

        [Required]
        public Genre Genre { get; init; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; init; }

        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string ImageUrl { get; init; }
    }
}
