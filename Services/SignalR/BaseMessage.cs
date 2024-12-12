using ConfigurationWebApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWebApiService.Services.SignalR
{
    public static class BaseMessage
    {
        public static IReadOnlyList<string> GetSubscribersForMessage(string[] actions, string[] objects)
        {
            ConfugurationManagerDbContext context = new();
            return (from us in context.UserSubscriptions
                    join s in context.Subscriptions on us.SubscriptionId equals s.Id
                    join ses in context.SubscriptionEventSubscription on s.Id equals ses.SubscriptionId
                    join es in context.EventSubscription on ses.EventSubscriptionId equals es.Id
                    join utoes in context.UserTrackingObjectEventSubscription on es.Id equals utoes.EventSubscriptionId
                    join uto in context.UserTrackingObject on utoes.UserTrackingObjectId equals uto.Id
                    where us.IsActive == true
                        && actions.Contains(es.Title)
                        && objects.Contains(uto.Title)
                    select us.UserId.ToString()).AsEnumerable().ToList();
        }
    }
}
