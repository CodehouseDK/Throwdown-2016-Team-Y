using System;
using System.ComponentModel.DataAnnotations;

namespace TeamY.Models
{
    public class LunchModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Menu { get; set; }
        public string ImageSrc { get; set; }
    }
}