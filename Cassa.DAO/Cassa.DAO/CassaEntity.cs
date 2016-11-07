using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassa.DAO
{
    public class Ware
    {
        public int WareId { get; set; }
        [StringLength(500,ErrorMessage = "Слишком длинное название товара")]
        public string WareName { get; set; }
        public decimal Price { get; set; }
    }

    /// <summary>
    /// остатки
    /// </summary>
    public class WareRem
    {
        public int WareRemId { get; set; }
        public int WareId { get; set; }
        public decimal Qty { get; set; }
        [ForeignKey("WareId")]
        public virtual Ware Ware { get; set; }
    }

    /// <summary>
    /// движения
    /// </summary>
    public class Move
    {
        public int MoveId { get; set; }
        public int WareId { get; set; }
        /// <summary>
        /// Дата движения
        /// </summary>
        public DateTime MoveDate { get; set; }
        /// <summary>
        /// кол-во
        /// </summary>
        public decimal Qty { get; set; }
        /// <summary>
        /// Направление движения: 0 - пришло, 1 - ушло
        /// </summary> 
        public int Kind { get; set; }

        /// <summary>
        /// ссылка на документ по которому прошло движение, раходное по чеку
        /// </summary>
        public int MoveDocId { get; set; }
        [ForeignKey("WareId")]
        public virtual Ware Ware { get; set; }
    }

    public class Check
    {
        public int CheckId { get; set; }
        public DateTime DateTM { get; set; }

        /// <summary>
        /// с какой кассы прошла операция
        /// </summary>
        public int CashboxId { get; set; }
        public ICollection<CheckDetail> Details { get; set; }    
        public decimal Summ { get; set; }
    }

    public class CheckDetail
    {
        public int CheckDetailId { get; set; }
        public int CheckId { get; set; }
        public decimal Qty { get; set; } 
        public decimal Price { get; set; } 
        public int WareId { get; set; }

        [ForeignKey("WareId")]
        public virtual Ware Ware { get; set; }

        [ForeignKey("CheckId")]
        public virtual Check Check { get; set; }
    }

    [DbConfigurationType(typeof (MySql.Data.Entity.MySqlEFConfiguration))]
    public class CassaContext : DbContext
    {
        public CassaContext(DbConnection connection)
            : base(connection, false)
        {
        }

        public CassaContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Ware> Wares { get; set; }
        public DbSet<WareRem> WareRems { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Check> Checks{ get; set; }
        public DbSet<CheckDetail> CheckDetails{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var NumericProperties = new[]
                {
                    modelBuilder.Entity<Ware>().Property(s => s.Price),
                    modelBuilder.Entity<WareRem>().Property(s => s.Qty),
                    modelBuilder.Entity<Move>().Property(s => s.Qty),
                    modelBuilder.Entity<Check>().Property(s => s.Summ),
                    modelBuilder.Entity<CheckDetail>().Property(s => s.Qty),
                    modelBuilder.Entity<CheckDetail>().Property(s => s.Price),
                    
                };

            foreach (var numericProperty in NumericProperties)
            {
                numericProperty.HasPrecision(18, 3);
            }

            modelBuilder.Entity<Check>()
                .HasMany(cd => cd.Details)
                .WithRequired(c => c.Check);

        }
    }

    public class CassaInitializer : DropCreateDatabaseAlways<CassaContext>
    {
        protected override void Seed(CassaContext context)
        {
            for (int i = 1; i < 11; i++)
            {
                var ware = new Ware
                {
                    WareId = i,
                    WareName = "test ware " + i,
                    Price = i * 2,
                };
                context.Wares.Add(ware);

                context.WareRems.Add(new WareRem
                {
                    Ware = ware,
                    Qty = 1000,
                });
            }
            context.SaveChanges();

            var check = new Check
            {
                Summ = 100,
                CashboxId = 1,
                DateTM = DateTime.Now,
            };

            

            check.Details = new List<CheckDetail>
            {
                new CheckDetail
                {
                    Check = check,
                    WareId = 1,
                    Price = 30,
                    Qty = 2,
                },
                new CheckDetail
                {
                    Check = check,
                    WareId = 2,
                    Price = 15,
                    Qty = 3,
                }
            };

            context.Checks.Add(check);
            context.SaveChanges();

        }
    }

}
