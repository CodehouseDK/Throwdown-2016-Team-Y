using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using TeamY.Domain.Octopus;
using TeamY.Models.Octopus;

namespace TeamY.Services
{
    public class OctopusService : IOctopusService
    {
        private const string Apikey = "API-7FJGWAYAVPOLFLBTWV26YZE88O";
        private const string DeploymentUrl = "http://octopus/api/deployments";
        private const string ProjectUrl = "http://octopus/api/projects/";
        public LatestDeploymentsModel GetDeployments(int take)
        {
            var result = OctopusHttpClient<OctopusDeployment>(DeploymentUrl);
            var deployments = new LatestDeploymentsModel();
            deployments.TotalNumber = result.TotalResults;
            foreach (var item in result.Items.Take(take))
            {
                var project = GetProject(item.ProjectId);
                var deployment = new Deployment
                {
                    Project = project,
                    Created = DateTime.Parse(item.Created)
                };
                deployments.Deployments.Add(deployment);
            }
            return deployments;
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
