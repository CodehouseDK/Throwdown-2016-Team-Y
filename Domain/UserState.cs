using System;

namespace TeamY.Domain
{
    public class UserState : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid StateId { get; set; }
        public DateTime Set { get;set;}
    }
}
