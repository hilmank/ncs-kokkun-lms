using AutoMapper;
using KokkunLMS.Domain.Entities;
using KokkunLMS.Shared.Constants;
using KokkunLMS.Shared.DTOs.User;

namespace KokkunLMS.Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role!.RoleName))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")))
            .ForMember(dest => dest.ProfilePicture,
                opt => opt.MapFrom(src => $"/uploads/{FileUploadFolders.ProfilePictures}/{(string.IsNullOrEmpty(src.ProfilePicture) ? "no-photo.jpg" : src.ProfilePicture)}"));
    }
}
