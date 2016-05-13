using System.Collections.Generic;
using TeamY.Models.Rest;

namespace TeamY.Services
{
    public interface ILocationDetailsService
    {
        IEnumerable<LocationDetailsModel> GetLocationDetails();
    }
}