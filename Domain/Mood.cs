using System;

namespace TeamY.Domain
{
    public class Mood : EntityBase
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
    }
}
