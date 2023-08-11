using Models.Modelos.Modules;
using Models.Modelos.Users;
using System.Text.Json.Serialization;

namespace Models.Modelos.UserModules
{
    public class UserModules
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        public Guid IdModule { get; set; }
        [JsonIgnore]
        public virtual Module? Module { get; set; }

        public UserModules()
        {
            Id = Guid.NewGuid();
        }
    }
}
