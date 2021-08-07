namespace SharedBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Location
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(PlaceMaxLength)]
        public string Place { get; set; }

        public virtual ICollection<Book> Books { get; init; } = new List<Book>();

        public virtual ICollection<User> Users { get; init; } = new List<User>();
    }
}
