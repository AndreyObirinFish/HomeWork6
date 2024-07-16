using MyCity.Core.Domain;
using System.Collections.Generic;

namespace MyCity.WebHost.Models
{
    public class CreateOrUpdateRouteRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CustomStop> CustomStops { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
