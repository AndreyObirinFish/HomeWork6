using MyCity.Core.Domain;
using System.Collections.Generic;
using System;

namespace MyCity.WebHost.Models
{
    public class CustomStopResponse
    {
        public Guid PointOfInterestId { get; set; }
        public string? Description { get; set; }
        public List<MediaFile>? MediaFiles { get; set; }
    }
}
