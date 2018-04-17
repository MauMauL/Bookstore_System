using AutoMapper;

namespace Bookstore_System.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DomainToDataTransferObjectMappingProfile>();
                cfg.AddProfile<DataTransferObjectToDomainMappingProfile>();
            });
        }
    }
}