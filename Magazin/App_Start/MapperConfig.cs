using AutoMapper;
namespace Magazin.App_Start
{
    public class MapperConfig
    {
        public static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(_ =>
            {
                _.AddProfile(new MapperProfile());
            });
        }
    }
}