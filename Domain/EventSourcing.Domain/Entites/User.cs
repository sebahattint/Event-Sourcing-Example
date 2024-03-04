using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain.Entites
{
    public record User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User(int id, string firstname, string lastname)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
        }

        public void ChangeFirstName(string newName) => FirstName = newName;
        public void ChangeLastName(string newName) => LastName = newName;
    }

    public class UserSource
    {
        public static List<User> Users { get; } = new()
        {
            new (1,"Sebahattin", "Tonbul"),
            new (2,"Selahattin", "Tonbul"),
            new (3,"Burhan", "Tonbul")
        };
    }
}
