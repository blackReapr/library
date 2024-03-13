using Practice.Interfaces;
using Practice.Utils.Enums;

namespace Practice.Utils.Models
{
    public class User : IEntity
    {
        public User(string username, string email, Roles role)
        {
            StaticId++;
            Id = StaticId;
            Username = username;
            Email = email;
            Role = role;
        }
        private static int StaticId { get; set; }
        public int Id { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public void ShowInfo()
        {
            Console.WriteLine(Id + " " + Username);
        }
    }
}
