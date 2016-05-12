using System;

namespace TeamY.Domain
{
    public class User : EntityBase
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Password { get; set; }
    }
}
