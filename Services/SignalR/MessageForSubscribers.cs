using Microsoft.AspNetCore.SignalR;

namespace ConfigurationWebApiService.Services.SignalR
{
    public class MessageForSubscribers : Hub<IMessageForSubscribers>
    {
        public async Task Send(string message, string additionMessage, IReadOnlyList<string> clientIds)
        {
            if (clientIds != null && clientIds.Any())
                await Clients.Clients(clientIds).SendAsync(message);
        }
        public async Task Send(string message)
        {
            await Clients.All.SendAsync(message);
        }
    }
}
