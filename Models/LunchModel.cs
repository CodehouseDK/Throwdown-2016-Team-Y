using System;
using System.ComponentModel.DataAnnotations;

namespace TeamY.Models
{
    public class LunchModel
    {
        
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Menu { get; set; }
        public string ImageSrc { get; set; }
    }
}