using MyCity.Dtos.Enums;
using MyCity.Dtos.MediaFileDtos;
using MyCity.Dtos.ReviewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Dtos.PointOfInterestDtos
{
    public class CreateOrUpdatePointOfInterestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public StatusPointOfInterest Status { get; set; }
        public string Version { get; set; }
        public List<CreateOrUpdateMediaFileDto> MediaFiles { get; set; }
        public List<CreateOrUpdateReviewDto> Reviews { get; set; }
    }
}
