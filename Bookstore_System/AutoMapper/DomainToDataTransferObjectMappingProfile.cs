using AutoMapper;
using Bookstore_System.Domain.Entities;
using Bookstore_System.MVC.DataTransferObject;

namespace Bookstore_System.MVC.AutoMapper
{
    public class DomainToDataTransferObjectMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToDataTransferObjectMappings"; }
        }

        public DomainToDataTransferObjectMappingProfile()
        {
            CreateMap<LIVRO, LivroDataTransferObject>();
        }
    }
}