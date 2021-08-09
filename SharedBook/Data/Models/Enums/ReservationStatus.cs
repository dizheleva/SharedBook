namespace SharedBook.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ReservationStatus
    {
        [Display(Name = "Approved and waiting")]
        ApprovedAndWaiting = 1,
        Pending = 2,
        Completed = 3,
        Canceled = 4,
        None = 5
    }
}
