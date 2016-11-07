using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassa.DAO;
using Microsoft.Practices.Unity;

namespace Cassa.Classes.Impl
{
    public class OperationService : IOperationService
    {
        [Dependency]
        public ICassaService CassaService { get; set; }

        public List<WareWcfDto> GetWareList(WareLoadParams param)
        {
            var wares = CassaService.GetWareList().Select(x=>new WareWcfDto
            {
                WareId = x.WareId,
                Price = x.Price,
                WareName = x.WareName,
            }).ToList();
            return wares;
        }

        public void CloseCheck(CheckWcfDto Check)
        {
            CassaService.CloseCheck(new CheckDto
            {
                CheckId = Check.CheckId,
                CashboxId = Check.CashboxId,
                DateTM = Check.DateTM,
                Summ = Check.Summ,
                Details = Check.DetailList.Select(x=>new CheckDetailDto
                {
                    CheckId = x.CheckId,
                    WareId = x.WareId,
                    Price = x.Price,
                    Qty = x.Qty,
                    CheckDetailId = x.CheckDetailId,
                }).ToList(),
            });
        }
    }
}
