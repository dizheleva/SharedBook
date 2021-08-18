namespace SharedBook.Models.Borrower
{
    using System.ComponentModel.DataAnnotations;

    public class BecomeBorrowerFormModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public decimal Deposit { get; set; }
    }
}
