using DataAccess.Models;

namespace GhiseuBon.Dtos
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Password { get; set; }

        public UserModel ToModel()
        {
            var model = new UserModel();
            model.UserName = UserName;
            model.Email = Email;
            model.FirstName = FirstName;
            model.LastName = LastName;
            model.CreatedAt = CreatedAt;
            model.PasswordHash = PasswordHasher.HashPassword(Password);
            model.RoleUser = RoleUser;
            return model;
        }
    }
}
