using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamY.Domain
{
    public class MoodRegistration
    {
        public Guid Id { get; set; }
        public DateTime Registered { get; set; }
        public Guid MoodId { get; set; }
        public Guid UserId { get; set; }
    }
}
