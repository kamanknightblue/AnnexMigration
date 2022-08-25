using AnnexMigration.Annexes;
using AutoMapper;

namespace AnnexMigration;

public class AnnexMigrationApplicationAutoMapperProfile : Profile
{
    public AnnexMigrationApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        //CreateMap<Annex, AnnexDto>().IgnoreNoMap().ReverseMap();
    }
}
