using Microsoft.AspNetCore.SignalR;

namespace Real_Time_Stock_Exchange.SignalR
{
    public class StockHub : Hub
    {
        public async Task SendStockUpdate(string symbol, decimal price)
        {
           await  Clients.All.SendAsync(symbol, price);
        }
    }
}
