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
        public string StreetAddress { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public int AreaId { get; set; }

        public Area Area { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int PostCode { get; init; }
    }
}
