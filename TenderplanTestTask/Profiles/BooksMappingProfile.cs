using AutoMapper;
using TenderplanTestTask.Dtos;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Profiles
{
    public class BooksMappingProfile : Profile
    {
        public BooksMappingProfile()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookReadDto>();
        }
    }
}