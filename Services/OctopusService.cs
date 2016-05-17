using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using TeamY.Domain.Octopus;
using TeamY.Models.Octopus;
using Environment = TeamY.Models.Octopus.Environment;

namespace TeamY.Services
{
    public class OctopusService : IOctopusService
    {
        private const string Apikey = "#{OctopusKey}";
        private const string DeploymentUrl = "http://octopus/api/deployments";
        private const string EnvironmentUrl = "http://octopus/api/environments/";
        private const string ProjectUrl = "http://octopus/api/projects/";
        private const string ReleaseUrl = "http://octopus/api/releases/";
        public LatestDeploymentsModel GetDeployments(int take)
        {
            var result = OctopusHttpClient<OctopusDeployment>(DeploymentUrl);
            var deployments = new LatestDeploymentsModel();
            deployments.TotalNumber = result.TotalResults;
            foreach (var item in result.Items.Take(take))
            {
                var project = GetProject(item.ProjectId);
                var environment = GetEnvironment(item.EnvironmentId);
                var version = GetReleaseVersion(item.ReleaseId);
                var deployment = new Deployment
                {
                    Created = DateTime.Parse(item.Created),
                    Enviroment = environment,
                    Project = project,
                    Version = version
                    
                };
                deployments.Deployments.Add(deployment);
            }
            return deployments;
        }

        public Environment GetEnvironment(string environmentId)
        {
            var result = OctopusHttpClient<OctopusEnvironment>($"{EnvironmentUrl}{environmentId}");
            var environment = new Environment
            {
                Name = result.Name,
                Description = result.Description
            };
            return environment;
        }

        public Project GetProject(string projectId)
        {
            var result = OctopusHttpClient<OctopusProject>($"{ProjectUrl}{projectId}");
            var project = new Project
            {
                Name = result.Name,
                Slug = result.Slug,
                Description = result.Description
            };
            return project;
        }
        public string GetReleaseVersion(string releaseId)
        {
            var result = OctopusHttpClient<OctopusRelease>($"{ReleaseUrl}{releaseId}");
            return result.Version;
        }

        private T OctopusHttpClient<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Octopus-ApiKey", Apikey);
                var result = client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<T>(result.Result);
            }
        }
    }
}
