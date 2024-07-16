using AutoMapper;
using Dtos.RoleDtos;
using Dtos.UserDtos;
using MyCity.Core.Domain;
using MyCity.Dtos.CustomStopDtos;
using MyCity.Dtos.MediaFileDtos;
using MyCity.Dtos.PointOfInterestDtos;
using MyCity.Dtos.ReviewDto;
using MyCity.Dtos.RouteDtos;
using MyCity.WebHost.Models;

namespace MyCity.WebHost.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateOrUpdateRoleRequest, CreateOrUpdateRoleDto>();
            CreateMap<Role, RoleResponse>();
            CreateMap<CreateOrUpdateRoleDto, Role>();

            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Fio, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName} {src.MiddleName}"));
            CreateMap<CreateOrUpdateUserRequest, CreateOrUpdateUserDto>();
            CreateMap<CreateOrUpdateUserDto, User>();

            CreateMap<CreateOrUpdateMediaFileDto, MediaFile>();
            CreateMap<MediaFile, MediaFileResponse>();
            CreateMap<CreateOrUpdateMediaFileRequest, CreateOrUpdateMediaFileDto>();

            CreateMap<CreateOrUpdateReviewDto, Review>();
            CreateMap<Review, ReviewResponse>();
            CreateMap<CreateOrUpdateReviewRequest, CreateOrUpdateReviewDto>();

            CreateMap<CreateOrUpdatePointOfInterestDto, PointOfInterest>();
            CreateMap<PointOfInterest, PointOfInteresetResponse>();
            CreateMap<CreateOrUpdatePointOfInterestRequest, CreateOrUpdatePointOfInterestDto>();

            CreateMap<CreateOrUpdateCustomStopDto, CustomStop>();
            CreateMap<CustomStop, CustomStopResponse>();
            CreateMap<CreateOrUpdateCustomStopRequest, CreateOrUpdateCustomStopDto>();

            CreateMap<CreateOrUpdateRouteDto, Route>();
            CreateMap<Route, RouteResponse>();
            CreateMap<CreateOrUpdateRouteRequest, CreateOrUpdateRouteDto>();

        }
    }
}
