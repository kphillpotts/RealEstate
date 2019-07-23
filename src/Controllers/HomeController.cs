﻿using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Controllers
{
	[Route("")]
	public class HomeController : Controller
	{
		public HomeController(IDataRepository repo)
		{
			_repo = repo;
		}

		readonly IDataRepository _repo;

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var featuredProperties = await _repo.GetFeaturedProperties();

            var vm = new HomeViewModel
			{
				ShowMasterHeader = true,
				FeaturedProperties = featuredProperties.Select(r => r.ToViewModel()).ToList()
            };

			return View(vm);
		}

		[HttpGet("propertydetailsmodal/{propertyId}", Name = "PropertyDetailsRoute")]
		public async Task<ActionResult> PropertyDetailsPartial(int propertyId)
		{
			var propertyDetails = await _repo.GetPropertyDetails(propertyId);

			var vm = propertyDetails.ToViewModel();
			return PartialView("_PropertyDetailsModal", vm);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
