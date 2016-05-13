namespace TeamY.Domain.Octopus
{
    public class OctopusProject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
    }
}
