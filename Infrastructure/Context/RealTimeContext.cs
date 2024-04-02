using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Context
{
    public class RealTimeContext : IdentityDbContext<User>
    {
        public RealTimeContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Stock>().HasData(
              
               new Stock {  Symbol = "STKA", Name= "AAPL (Apple Inc.)", Price = 160.00m, TimeStamp = DateTime.Now.AddMinutes(20) },
              new Stock { Symbol = "STKB", Name= "GOOGL (Alphabet Inc.)",  Price = 200.00m, TimeStamp = DateTime.Now.AddMinutes(20) },
               new Stock { Symbol = "STKC", Name= "MSFT (Microsoft Corporation)", Price = 200.00m, TimeStamp = DateTime.Now.AddMinutes(20) }
             );

            builder.Entity<HistoricalStock>().HasData(
               new HistoricalStock { Id = 1, Price = 120.00m, TimeStamp = DateTime.Now.AddMinutes(15),StockSymbol = "STKA" },
              new HistoricalStock { Id = 2, Price = 150.00m, TimeStamp = DateTime.Now.AddMinutes(15), StockSymbol = "STKB" },
               new HistoricalStock { Id = 3, Price = 200.00m, TimeStamp = DateTime.Now.AddMinutes(15) , StockSymbol = "STKC" },
                new HistoricalStock { Id = 4,  Price = 110.00m, TimeStamp = DateTime.Now.AddMinutes(5) , StockSymbol = "STKA" },
              new HistoricalStock { Id = 5, Price = 160.00m, TimeStamp = DateTime.Now.AddMinutes(5), StockSymbol = "STKB" },
               new HistoricalStock { Id = 6, Price = 200.00m, TimeStamp = DateTime.Now.AddMinutes(5), StockSymbol = "STKC" },
             new HistoricalStock { Id = 7,  Price = 100.00m, TimeStamp = DateTime.Now, StockSymbol = "STKA" },
             new HistoricalStock { Id = 8, Price = 140.00m, TimeStamp = DateTime.Now, StockSymbol = "STKB" },
              new HistoricalStock { Id = 9, Price= 190.00m ,TimeStamp = DateTime.Now , StockSymbol = "STKC" }
            );
            builder.Entity<OrderStocks>()
                .HasKey(os => new { os.OrderID, os.StockSymbol });

            base.OnModelCreating(builder);
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<HistoricalStock> HistoricalStockDatas { get; set; }
        public DbSet<OrderStocks> OrderStocks { get; set; }


    }
}
