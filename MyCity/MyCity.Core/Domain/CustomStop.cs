using MyCity.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Core.Domain
{
    public class CustomStop : BaseEntity
    {
        public Guid PointOfInterestId { get; set; }
        public string? Description { get; set; }
        public List<MediaFile>? MediaFiles { get; set; }

    }
}
