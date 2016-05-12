namespace TeamY.Domain
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Password { get; set; }
    }
}
