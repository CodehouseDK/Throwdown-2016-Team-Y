using TeamY.Domain;
using TeamY.Models.Octopus;

namespace TeamY.Models
{
    public class HomeModel
    {
        public HomeModel(User user)
        {
            if (user != null)
            {
                Name = user.Name;
                UserImage = $"/images/employees/{user.Initials}.jpg";
            }
        }

        public string Name { get; }
        public string UserImage { get; }
        public LatestDeploymentsModel LatestDeployments { get; set; }
    }
}