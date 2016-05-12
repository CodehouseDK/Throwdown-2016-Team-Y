using TeamY.Domain;

namespace TeamY.Models
{
    public class HomeModel
    {
        public HomeModel(User user)
        {
            if (user != null)
            {
                Name = user.Name;
            }
        }

        public string Name { get; }

    }
}