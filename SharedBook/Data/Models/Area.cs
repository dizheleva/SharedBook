namespace SharedBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using static DataConstants;

    public class Area
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(AreaMaxLength)]
        public AreaName AreaName { get; set; }

        public int AdminCode { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
