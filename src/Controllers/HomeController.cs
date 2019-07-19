using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Entities;
using RealEstate.Models;
using RealEstate.Services;
using RealEstate.ViewModels;

namespace RealEstate.Controllers
{
	public class HomeController : Controller
	{
		public HomeController(IDataRepository queryService)
		{
			_queryService = queryService;
		}

		readonly IDataRepository _queryService;

		public async Task<IActionResult> Index()
		{
			var featuredObjects = await _queryService.GetFeaturedObjects();

			var vm = new HomeViewModel
			{
				FeaturedObjects = featuredObjects
			};

			return View(vm);
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
