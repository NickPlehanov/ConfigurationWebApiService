using ConfigurationWebApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWebApiService.Services
{
    public static class BaseMessage
    {
        public static IEnumerable<string> GetSubscribersForMessage(string[] actions)
        {
            ConfugurationManagerDbContext context = new();
            return (from us in context.UserSubscriptions
                    join s in context.Subscriptions on us.SubscriptionId equals s.Id
                    join ses in context.SubscriptionEventSubscription on s.Id equals ses.SubscriptionId
                    join es in context.EventSubscription on ses.EventSubscriptionId equals es.Id
                    where us.IsActive == true
                        && actions.Contains(es.Title)
                    select us.UserId.ToString()).AsEnumerable();
        }
    }
}
