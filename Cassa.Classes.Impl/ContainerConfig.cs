using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Cassa.Classes.Impl
{
    public static class ContainerConfig_Ext
    {
        public static IUnityContainer Cassa_Classes(this IUnityContainer Cfg)
        {
            return Cfg
                .RegisterType<IOperationService, OperationService>();
        }
    }
}
