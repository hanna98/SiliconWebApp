using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSubscribe.Contexts;
using WebApiSubscribe.Models;

namespace WebApiSubscribe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController(ApiContext apiContext) : ControllerBase
    {
        private readonly ApiContext _apiContext = apiContext;

        [HttpPost]
        public async Task<IActionResult> Create(SubscribeForm form)
        {
            if (ModelState.IsValid)
            {
                if (!await _apiContext.Subscribers.AnyAsync(x => x.Email == form.Email))
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
                    
                    _apiContext.Subscribers.Add(entity);
                    await _apiContext.SaveChangesAsync();
                    
                    return Created("", null);
                }

                return Conflict();
            }

            return BadRequest();
        }
    }
}
