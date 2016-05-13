using TeamY.Models.Octopus;

namespace TeamY.Services
{
    public interface IOctopusService
    {
        LatestDeploymentsModel GetDeployments(int take);
        Project GetProject(string projectId);
    }
}