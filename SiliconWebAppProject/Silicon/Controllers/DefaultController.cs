using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon.Models;
using System.Text;

namespace Silicon.Controllers;

public class DefaultController(HttpClient httpClient) : Controller
{
	private readonly HttpClient _httpClient = httpClient;

    public IActionResult Home()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Newsletter (SubscriberViewModel model)
	{
		if (ModelState.IsValid)
		{
			var subscriberEntity = new SubscriberEntity
			{
				Email = model.Email,
				DailyNewsletter = model.DailyNewsletter,
				AdvertisingUpdates = model.AdvertisingUpdates,
				WeekinReview = model.WeekinReview,
				EventUpdates = model.EventUpdates,
				StartupWeekly = model.StartupWeekly,
				Podcasts = model.Podcasts,
			};
			
			var content = new StringContent(JsonConvert.SerializeObject(subscriberEntity), Encoding.UTF8, "application/json");
			var result = await _httpClient.PostAsync("https://localhost:7062/api/Subscribe", content);
			if (result.IsSuccessStatusCode)
			{
				TempData["SubscriberStatus"] = "successfully subscribed";
                return RedirectToAction("Home", "Default");
            }
		
		}

		return RedirectToAction("Home", "Default");
	}
}
