namespace SharedBook.Services.Users
{
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Models.Enums;

    public class UserService : IUserService
    {
        private readonly SharedBookDbContext data;

        public UserService(SharedBookDbContext data) => this.data = data;

        public bool IsRegisteredUser(string userId) => this.data.Users.Any(u => u.Id == userId);

        public bool IsActiveUser(string userId) => this.data.Users.Any(u => u.Id == userId && u.UserStatus == UserStatus.Active);

        public User GetUserById(string userId) => this.data.Users.FirstOrDefault(u => u.Id == userId);
    }
}
