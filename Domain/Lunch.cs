﻿using System;

namespace TeamY.Domain
{
    public class Lunch : EntityBase
    {
        public DateTime Date { get; set; }
        public string Menu { get; set; }
        public string ImageSrc { get; set; }
    }
}
