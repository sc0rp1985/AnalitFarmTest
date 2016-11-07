using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassa.Classes.Impl;
using Microsoft.Practices.Unity;

namespace Cassa.Wcf
{
    class Program
    {
        public static IUnityContainer cfg;
        static void Main(string[] args)
        {
            cfg = new UnityContainer();
            cfg
                .RegisterInstance(cfg)
                .Cassa_Classes();

        }
    }
}
