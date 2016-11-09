using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassa.Wpf.OperationService;

namespace Cassa.Wpf
{
    public class WcfClient 
    {
        OperationServiceClient client = new OperationServiceClient();

        public List<WareWcfDto> GetWareList(WareLoadParams param)
        {
            return client.GetWareList(param).ToList();
        }

        public int CloseCheck(CheckWcfDto Check)
        {
            return client.CloseCheck(Check);
        }
    }
}
