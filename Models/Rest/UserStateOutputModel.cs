using TeamY.Domain;

namespace TeamY.Models.Rest
{
    public class UserStateOutputModel 
    {
        public UserModel User { get; set; }
        public StateModel State { get; set; }
    }
}
