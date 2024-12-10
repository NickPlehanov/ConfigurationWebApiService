namespace ConfigurationWebApiService.Services
{
    public interface IMessageForSubscribers
    {
        Task SendAsync(string message);
    }
}
