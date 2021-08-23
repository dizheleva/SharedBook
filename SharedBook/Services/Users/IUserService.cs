namespace SharedBook.Services.Users
{
    using Data.Models;

    public interface IUserService
    {
        public bool IsRegisteredUser(string userId);

        public bool IsActiveUser(string userId);

        public User GetUserById(string userId);
    }
}
