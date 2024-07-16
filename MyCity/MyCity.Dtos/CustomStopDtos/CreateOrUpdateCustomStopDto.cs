using MyCity.Dtos.MediaFileDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Dtos.CustomStopDtos
{
    public class CreateOrUpdateCustomStopDto
    {
        public Guid PointOfInterestId { get; set; }
        public string? Description { get; set; }
        public List<CreateOrUpdateMediaFileDto>? MediaFiles { get; set; }
    }
}
