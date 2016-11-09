using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;


namespace Cassa.DAO
{
    public interface ICassaService
    {
        void AddWare(WareDto ware);
        List<WareDto> GetWareList();
        int CloseCheck(CheckDto check);
    }

    public class CassaService : ICassaService
    {
        private string conStrName = "Cassa";

        public void AddWare(WareDto ware)
        {
            using (var context = new CassaContext(conStrName))
            {
                context.Wares.Add(new Ware
                {
                    Price = ware.Price,
                    WareName = ware.WareName,
                });
                context.SaveChanges();
            }
        }

        public List<WareDto> GetWareList()
        {
            var wares = new List<WareDto>();
            using (var context = new CassaContext(conStrName))
            {
               wares = context.Wares.Select(x=>x).ToList().Select(WareDto.FromDao).ToList();
            }
            return wares;
        }

        public int CloseCheck(CheckDto check)
        {
            using (var context = new CassaContext(conStrName))
            {
                using (var tran = new TransactionScope())
                {

                    //добавляем новый чек
                    var checkDao = new Check
                    {
                        CashboxId = check.CashboxId,
                        CheckId = check.CheckId,
                        DateTM = check.DateTM ?? DateTime.Now,
                        Summ = check.Summ,
                    };
                    checkDao.Details = check.Details.Select(x => new CheckDetail
                    {
                        Check = checkDao,
                        WareId = x.WareId,
                        CheckDetailId = x.CheckDetailId,
                        Price = x.Price,
                        Qty = x.Qty
                    }).ToList();
                    context.Checks.Add(checkDao);
                    context.SaveChanges();
                    //проводим движение товара и обновляем остатки
                    foreach (var det in check.Details)
                    {
                        context.Moves.Add(new Move
                        {
                            Qty = det.Qty,
                            WareId = det.WareId,
                            Kind = CassaConst.MoveKind.mkOun,
                            MoveDate = DateTime.Now,
                            MoveDocId = check.CheckId,
                        });

                        var rem = context.WareRems.FirstOrDefault(x => x.WareId == det.WareId);
                        if (rem.Qty < det.Qty)
                            throw new ApplicationException(
                                $"Не хватате товара {rem.Ware.WareName}: в наличие {rem.Qty} требуется {det.Qty}!");
                        
                        rem.Qty -= det.Qty;
                        
                    }
                    context.SaveChanges();
                    //throw new ApplicationException("test");
                    tran.Complete();
                    return checkDao.CheckId;
                }
            }
        }
    }

    public class WareDto
    {
        public int WareId { get; set; }
        public string WareName { get; set; }
        public decimal Price { get; set; }

        public static WareDto FromDao(Ware dao)
        {
            return new WareDto
            {
                WareId = dao.WareId,
                Price = dao.Price,
                WareName = dao.WareName,
            };
        }
    }

    public class CheckDetailDto
    {
        public int CheckDetailId { get; set; }
        public int CheckId { get; set; }
        public int WareId { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }

        public static CheckDetailDto FromDao(CheckDetail dao)
        {
            return new CheckDetailDto
            {
                WareId = dao.WareId,
                Price = dao.Price,
                CheckId = dao.CheckId,
                Qty = dao.Qty,
                CheckDetailId = dao.CheckDetailId,
            };
        }
    }

    public class CheckDto
    {
        public int CheckId { get; set; }
        public int CashboxId { get; set; }
        public DateTime? DateTM { get; set; }
        public decimal Summ { get; set; }
        public List<CheckDetailDto> Details { get; set; }

        public static CheckDto FromDao(Check dao)
        {
            return new CheckDto
            {
                Details = new List<CheckDetailDto>(dao.Details.Select(CheckDetailDto.FromDao).ToList()),
                CheckId = dao.CheckId,
                Summ = dao.Summ,
                DateTM = dao.DateTM,
                CashboxId = dao.CashboxId,
            };
        }
    }
}
