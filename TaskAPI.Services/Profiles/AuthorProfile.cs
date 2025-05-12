using AutoMapper;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        // Add sourse and destination to map
        // Add destination and option to mapFrom
        CreateMap<Author, AuthorDto>().ForMember(dest => dest.Address,
            opt => opt.MapFrom(src => $"{src.AddressNo}, {src.Street}, {src.City}"));

        CreateMap<CreateAuthorDto, Author>();
    }
}