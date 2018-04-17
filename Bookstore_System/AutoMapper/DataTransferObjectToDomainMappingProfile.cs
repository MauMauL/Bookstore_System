using AutoMapper;
using Bookstore_System.Domain.Entities;
using Bookstore_System.MVC.DataTransferObject;

namespace Bookstore_System.MVC.AutoMapper
{
    public class DataTransferObjectToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DataTransferObjectToDomainMappings"; }
        }

        public DataTransferObjectToDomainMappingProfile()
        {
            CreateMap<LivroDataTransferObject, LIVRO>();
        }
    }
}