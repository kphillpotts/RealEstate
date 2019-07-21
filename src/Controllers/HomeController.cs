using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Controllers
{
	public class HomeController : Controller
	{
		public HomeController(IDataRepository repo)
		{
			_repo = repo;
		}

		readonly IDataRepository _repo;

		public async Task<IActionResult> Index()
		{
			var featuredObjects = await _repo.GetFeaturedObjects();

			var vm = new HomeViewModel
			{
				FeaturedObjects = featuredObjects
			};

			return View(vm);
		}

		public async Task<ActionResult> ObjectDetails(int objectId)
		{
			var objectDetails = await _repo.GetObjectDetails(objectId);
			return PartialView("_ObjectDetailsModal", objectDetails);
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
