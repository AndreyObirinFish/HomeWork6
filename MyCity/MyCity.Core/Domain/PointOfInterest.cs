using MyCity.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Core.Domain
{
    public class PointOfInterest : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public StatusPointOfInterest Status { get; set; }
        public string Version { get; set; }
        public List<MediaFile>? MediaFiles { get;set;}
        public List<Review>? Reviews { get; set; }
    }
}
