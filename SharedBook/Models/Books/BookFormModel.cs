namespace SharedBook.Models.Books
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using SharedBook.Data.Models.Enums;

    using static Data.DataConstants;

    public class BookFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; init; }

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; init; }

        [Required]
        [BindRequired]
        public Genre Genre { get; init; }

        [StringLength(DescriptionMaxLength)]
        public string Description { get; init; }

        [Display(Name = "Image URL")]
        [Required]
        [Url]
        public string ImageUrl { get; init; }

        [Required]
        [BindRequired]
        public City Location { get; set; }

        [Required]
        [BindRequired]
        public BookStatus Status { get; set; }
    }
}
