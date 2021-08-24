namespace SharedBook.Infrastructure
{
    using AutoMapper;
    using Data.Models;
    using Models.Books;
    using Services.Books;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //this.CreateMap<Book, BookViewModel>();
            this.CreateMap<Book, BookFormModel>()
                .ReverseMap();

            this.CreateMap<Book, BookServiceModel>();

            this.CreateMap<BookDetailsServiceModel, BookViewModel>();

            this.CreateMap<Book, BookServiceModel>().ReverseMap();

            this.CreateMap<Book, BookDetailsServiceModel>()
                .ForMember(b => b.Owner, cfg => cfg.MapFrom(b => b.User.Email))
                .ForMember(b => b.Shares, cfg => cfg.MapFrom(b => b.Shares.Count));
        }
    }
}
