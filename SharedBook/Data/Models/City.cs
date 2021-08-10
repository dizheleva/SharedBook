namespace SharedBook.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public int AreaId { get; set; }

        public Area Area { get; set; }
    }
}
