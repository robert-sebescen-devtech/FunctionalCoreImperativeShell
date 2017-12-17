using System;

namespace FunctionalCoreImperativeShell
{
    public class User
    {
        public Guid Id { get; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public UserType Type { get; }

        public User(Guid id, string username, string firstName, string lastName, UserType type)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }

        public User ChangeUsername(string newUsername)
        {
            return new User(Id, newUsername, FirstName, LastName, Type);
        }

        public User PromoteToAdministrator()
        {
            User changedUser;
            switch (Type) {
                case UserType.Guest:
                    throw new InvalidOperationException("Guest user cannot be promoted to be an administrator");
                case UserType.Administrator:
                    changedUser = this;
                    break;
                default:
                    changedUser = new User(Id, Username, FirstName, LastName, UserType.Administrator);
                    break;
            }

            return changedUser;
        }
    }
}
