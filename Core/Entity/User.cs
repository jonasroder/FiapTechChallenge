using Core.ValueObjects;

namespace Core.Entity
{
    public class User : EntityBase
    {
        public required string Name { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required Email Email { get; set; }
        public required Password Password { get; set; }
    }
}
