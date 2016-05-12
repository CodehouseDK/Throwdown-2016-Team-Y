using TeamY.Domain;

namespace TeamY.Models
{
    public class HomeModel
    {
        public HomeModel(User user)
        {
            Name = user.Name;
        }

        public string Name { get; }

    }
}