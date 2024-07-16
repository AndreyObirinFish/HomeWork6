using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Core.Domain
{
    public class Route : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CustomStop> CustomStops { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
