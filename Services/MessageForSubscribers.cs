using Microsoft.AspNetCore.SignalR;

namespace ConfigurationWebApiService.Services
{
    public class MessageForSubscribers : Hub<IMessageForSubscribers>
    {
        public async Task Send(string message, string additionMessage, IReadOnlyList<string> clientIds)
        {
            await this.Clients.Clients(clientIds).SendAsync(message);
        }
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(message);
        }
    }
}
