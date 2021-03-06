namespace SharedBook.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using static DataConstants;

    public class Address
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(StreetAddressMaxLength)]
        public string StreetFulAddress { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public Area Area { get; set; }
    }
}
