using Models.Modelos.Shared;
using Models.Requests;

namespace Models.Modelos.Users
{

    public class User : Address
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime DateBirth { get; set; }
        public string Document { get; set; }
        public bool Able { get; set; }
        public bool FirstAccess { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }

}
    