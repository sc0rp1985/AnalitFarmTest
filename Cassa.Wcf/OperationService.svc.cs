using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Cassa.Classes;
using Cassa.Classes.Impl;
using Cassa.DAO;
using Microsoft.Practices.Unity;

namespace Cassa.Wcf
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class OperationService : IOperationService
	{
        private IUnityContainer cfg;
        protected IUnityContainer Cfg { get { return cfg; } }

	    protected OperationService()
	    {
	        cfg = new UnityContainer();
	        cfg
	            .RegisterInstance(cfg)
	            .Cassa_DAO()
	            .Cassa_Classes();
	    }


	    public List<WareWcfDto> GetWareList(WareLoadParams param)
	    {
	        return cfg.Resolve<IOperationService>().GetWareList(param);
	    }

	    public int CloseCheck(CheckWcfDto Check)
	    {
	        return cfg.Resolve<IOperationService>().CloseCheck(Check);
	    }
	}
}
