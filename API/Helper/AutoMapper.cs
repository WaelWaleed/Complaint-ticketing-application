using AutoMapper;
using Entity;

namespace API.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Entity.User, DTO.User>();
            CreateMap<DTO.User, Entity.User>()
                .AfterMap((Source, Destination) =>
                {
                    if(Destination.ID == 0) 
                    {
                        Destination.IsDeleted = false;
                    }
                });

            CreateMap<Entity.UserType, DTO.UserType>();
            CreateMap<DTO.UserType, Entity.UserType>()
                .AfterMap((Source, Destination) =>
                {
                    if (Destination.ID == 0)
                    {
                        Destination.IsDeleted = false;
                    }
                });

            CreateMap<Entity.Complaint, DTO.Complaint>();
            CreateMap<DTO.Complaint, Entity.Complaint>()
                .AfterMap((Source, Destination) =>
                {
                    if (Destination.ID == 0)
                    {
                        Destination.IsDeleted = false;
                    }
                });

            CreateMap<Entity.Demand, DTO.Demand>();
            CreateMap<DTO.Demand, Entity.Demand>()
                .AfterMap((Source, Destination) =>
                {
                    if (Destination.ID == 0)
                    {
                        Destination.IsDeleted = false;
                    }
                });
        }
    }
}
