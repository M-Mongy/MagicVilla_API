using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> VillList= new List<VillaDto>{
                new VillaDto {Id=1,Name="Pool View",Sqft=100,Occupancy=5},
                new VillaDto {Id=2,Name="Sea View",Sqft=300,Occupancy=9 }
        };
    }
}
