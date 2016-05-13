using System.Collections.Generic;
using TeamY.Domain;
using TeamY.Models.Octopus;
using TeamY.Models.Rest;

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
        public IEnumerable<LocationDetailsModel> LocationDetails { get; set; }
    }
}