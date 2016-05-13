using System;

namespace TeamY.Models.Octopus
{
    public class Deployment
    {
        public Project Project { get; set; }
        public DateTime Created { get; set; }
        public Environment Enviroment { get; set; }
        public string Version { get; set; }
    }
}
