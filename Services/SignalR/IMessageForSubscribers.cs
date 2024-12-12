namespace ConfigurationWebApiService.Services.SignalR
{
    public interface IMessageForSubscribers
    {
        Task SendAsync(string message);
    }
}
