using Microsoft.Practices.Unity;
namespace Cassa.DAO
{
    public static class ContainerConfig_Ext
    {
        public static IUnityContainer Cassa_DAO(this IUnityContainer Cfg)
        {
            return Cfg
                .RegisterType<ICassaService, CassaService>();
        }
    }
}
