using AutoMapper;
using Book_Management.Models.ViewModels;
using Book_Management.Resources;

namespace Book_Management.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Book, BookResource>();
        }
    }
}
