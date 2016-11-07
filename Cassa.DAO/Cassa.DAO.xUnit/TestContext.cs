using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cassa.DAO.xUnit
{
    [TestClass]
    public class TestContext
    {
        public readonly IUnityContainer cfg;

        public TestContext()
        {
            cfg = new UnityContainer();
            cfg
                .RegisterInstance(cfg)
                .Cassa_DAO();
        }


        [TestMethod]
        public void TestCreateDb()
        {
            //var context = new CassaContext("Cassa");
           Database.SetInitializer(new CassaInitializer());
            using (var context = new CassaContext("Cassa"))
            {
                var wares = context.Wares.ToList();
                if (wares == null)
                    Console.WriteLine("Бяда, пячаль");
                foreach (var ware in wares)
                {
                    Console.WriteLine($"{ware.WareId}  {ware.WareName}");
                }

                var checks = context.Checks.Include(c=>c.Details).ToList();
                foreach (var d in checks.First().Details)
                {
                    Console.WriteLine($"{d.Ware.WareName} {d.Qty}");
                }
            }
        }


        [TestMethod]
        public void Test1()
        {
            var cassaService = cfg.Resolve<ICassaService>();
            cassaService.CloseCheck(new CheckDto
            {
                CashboxId = 1,
                DateTM = DateTime.Now,
                Summ = 300,
                Details = new List<CheckDetailDto>
                {
                    new CheckDetailDto
                    {
                        WareId = 1,
                        Price = 10,
                        Qty = 2,
                    },
                    new CheckDetailDto
                    {
                        WareId = 2,
                        Price = 20,
                        Qty = 3,
                    },
                    new CheckDetailDto
                    {
                        WareId = 3,
                        Price = 15,
                        Qty = 1,
                    },
                }
            });

            using (var context = new CassaContext("Cassa"))
            {
                var moves = context.Moves.ToList();
                Assert.IsNotNull(moves);
                Assert.IsTrue(moves.Count>0);
            }
        }
    }
}
