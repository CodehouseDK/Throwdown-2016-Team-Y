using System;

namespace TeamY.Models.Octopus
{
    public class Deployment
    {
        public Project Project { get; set; }
        public DateTime Created { get; set; }
    }
}
