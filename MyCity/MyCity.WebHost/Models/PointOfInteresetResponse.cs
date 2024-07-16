using MyCity.Core.Domain;
using MyCity.Dtos.Enums;
using System.Collections.Generic;

namespace MyCity.WebHost.Models
{
    public class PointOfInteresetResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public StatusPointOfInterest Status { get; set; }
        public string Version { get; set; }
        public List<MediaFile>? MediaFiles { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
