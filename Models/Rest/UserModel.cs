using System;

namespace TeamY.Models.Rest
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Password { get; set; }
        public StateModel State { get; set; }
    }
}
