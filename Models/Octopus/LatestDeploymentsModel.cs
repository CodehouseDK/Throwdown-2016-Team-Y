using System.Collections.Generic;

namespace TeamY.Models.Octopus
{
    public class LatestDeploymentsModel
    {
        public LatestDeploymentsModel()
        {
            Deployments = new List<Deployment>();
        }
        public int TotalNumber { get; set; }
        public List<Deployment> Deployments { get; set; }
    }
}
