using AutoMapper;

namespace GraphQLvsRest.Impl.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Data.Dto.Author, Abstractions.Types.Author>()
                .ForCtorParam("id", opts => opts.MapFrom(src => src.Id))
                .ForCtorParam("name", opts => opts.MapFrom(src => src.Name))
                .ForCtorParam("birthDate", opts => opts.MapFrom(src => src.BirthDate));

            CreateMap<Data.Dto.Book, Abstractions.Types.Book>()
                .ForCtorParam("id", opts => opts.MapFrom(src => src.Id))
                .ForCtorParam("name", opts => opts.MapFrom(src => src.Name))
                .ForCtorParam("author", opts => opts.MapFrom(src => src.Author))
                .ForCtorParam("year", opts => opts.MapFrom(src => src.Year));

            CreateMap<Abstractions.Types.AddAuthorRequest, Data.Dto.Author>()
                .ForMember(dst => dst.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dst => dst.BirthDate, opts => opts.MapFrom(src => src.BirthDate))
                .ForMember(dst => dst.Id, opts => opts.Ignore())
                .ForMember(dst => dst.Books, opts => opts.Ignore());

            CreateMap<Abstractions.Types.AddBookRequest, Data.Dto.Book>()
                .ForMember(dst => dst.AuthorId, opts => opts.MapFrom(src => src.AuthorId))
                .ForMember(dst => dst.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dst => dst.Year, opts => opts.MapFrom(src => src.Year))
                .ForMember(dst => dst.Author, opts => opts.Ignore())
                .ForMember(dst => dst.Id, opts => opts.Ignore());

            CreateMap<Abstractions.Types.Author, Data.Dto.Author>()
                .ForMember(dst => dst.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dst => dst.BirthDate, opts => opts.MapFrom(src => src.BirthDate))
                .ForMember(dst => dst.Books, opts => opts.Ignore());

            CreateMap<Abstractions.Types.Book, Data.Dto.Book>()
                .ForMember(dst => dst.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dst => dst.Year, opts => opts.MapFrom(src => src.Year))
                .ForMember(dst => dst.Author, opts => opts.MapFrom(src => src.Author))
                .ForMember(dst => dst.AuthorId, opts => opts.MapFrom(src => src.Author.Id));
        }
    }
}
