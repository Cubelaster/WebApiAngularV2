using Microsoft.Extensions.Configuration;

namespace BL.Helpers.HelperContracts
{
    public interface IDbInitializer
    {
        void Initialize(IConfigurationRoot Configuration);
    }
}
