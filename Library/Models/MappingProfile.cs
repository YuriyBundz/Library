using AutoMapper;
using Library.DTO;

namespace Library.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>()
            .ForMember(dest => dest.ReviewsNumber, opt => opt.MapFrom(src => src.Reviews.Count))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings.Any()
            ? src.Ratings.Average(r => r.Score) : 0.0));

            CreateMap<Book, BookDetailsDTO>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.Score) : 0))
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews
            .Select(r => new ReviewDTO { Id = r.Id, Message = r.Message, Reviewer = r.Reviewer })));

            CreateMap<Book, RecommendedBookDTO>().ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings.Average(r => r.Score)))
            .ForMember(dest => dest.ReviewsNumber, opt => opt.MapFrom(src => src.Reviews.Count));

            CreateMap<NewBookDTO, Book>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.HasValue ? src.Id.Value : 0))
            .ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Cover))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author));

            CreateMap<Review, ReviewDTO>();

            CreateMap<NewReviewDTO, Review>();
        }
    }
}
