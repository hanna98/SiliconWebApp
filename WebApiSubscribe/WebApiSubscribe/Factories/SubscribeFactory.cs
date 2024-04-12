using Infrastructure.Entities;
using WebApiSubscribe.Models;

namespace WebApiSubscribe.Factories;

public class SubscribeFactory
{
    public static SubscribeEntity Create(SubscribeForm form)
    {
        try
        {
            var entity = new SubscribeEntity
            {
                Email = form.Email,
                DailyNewsletter = form.DailyNewsletter,
                AdvertisingUpdates = form.AdvertisingUpdates,
                WeekinReview = form.WeekinReview,
                EventUpdates = form.EventUpdates,
                StartupWeekly = form.StartupWeekly,
                Podcasts = form.Podcasts,
            };
        }
        catch { }
        return null!;
    }
}
