namespace TeamY.Domain.Octopus
{
    public class OctopusDeployment : OctopusBaseItem<OctopusDeploymentItem>
    {

    }

    public class OctopusDeploymentItem
    {
        public string Id { get; set; }
        public string ReleaseId { get; set; }
        public string EnvironmentId { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string Created { get; set; }
        
    }
}
