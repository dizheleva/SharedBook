namespace SharedBook.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Genre
    {
        History = 1,
        Action = 2,
        Comedy = 3,
        Crime = 4,
        Mystery = 5,
        Fantasy = 6,
        Horror = 7,
        [Display(Name = "Science Fiction")]
        ScienceFiction = 89,
        Romance = 9,
        Education = 10,
        Biography = 11,
        Journalistic = 12,
        Law = 13,
        Philosophy = 14,
        Religious = 15,
        Poetry = 16,
        Adventure = 17,
        Thriller = 18,
        Children = 19,
        Cooking = 20,
        Art = 21,
        Motivational = 22,
        [Display(Name = "Health and Fitness")]
        HealthFitness = 23,
        [Display(Name = "Craft, Hobbies and Home")]
        CraftHobbiesHome = 24,
        Politics = 25
    }
}
