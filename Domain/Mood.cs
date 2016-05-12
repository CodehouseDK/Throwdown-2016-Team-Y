using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamY.Domain
{
    public class Mood
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
    }
}
