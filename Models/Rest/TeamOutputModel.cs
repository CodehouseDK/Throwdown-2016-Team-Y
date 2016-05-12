using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TeamY.Models.Rest
{
    public class TeamOutputModel
    {
        private ICollection<TeamModel> _teams;

        public ICollection<TeamModel> Teams
        {
            get { return _teams ?? (_teams = new Collection<TeamModel>());}
            set { _teams = value; }
        }
    }
}
