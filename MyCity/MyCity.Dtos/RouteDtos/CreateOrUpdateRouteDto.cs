using MyCity.Dtos.CustomStopDtos;
using MyCity.Dtos.ReviewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCity.Dtos.RouteDtos
{
    public class CreateOrUpdateRouteDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CreateOrUpdateCustomStopDto> CustomStop { get; set; }
        public List<CreateOrUpdateReviewDto> Reviews { get; set; }
    }
}
