using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TeamY.Models.Rest
{
    public class TeamModel
    {
        private ICollection<UserModel> _users; 

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserModel> Users
        {
            get { return _users ?? (_users = new Collection<UserModel>()); }
            set { _users = value; }
        }
    }
}
