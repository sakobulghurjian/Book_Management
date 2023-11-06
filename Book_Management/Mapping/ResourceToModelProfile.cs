using AutoMapper;
using Book_Management.Models.ViewModels;
using Book_Management.Resources;

namespace Book_Management.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveBookResource, Book>();
        }
    }
}
