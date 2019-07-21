using System.Diagnostics;
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
			var featuredObjects = await _repo.GetFeaturedObjects();

			var vm = new HomeViewModel
			{
				ShowMasterHeader = true,
				FeaturedObjects = featuredObjects
			};

			return View(vm);
		}

		[HttpGet("objectdetailsmodal/{objectId}", Name = "ObjectDetailsRoute")]
		public async Task<ActionResult> ObjectDetailsPartial(int objectId)
		{
			var objectDetails = await _repo.GetObjectDetails(objectId);

			var vm = objectDetails.ToViewModel();
			return PartialView("_ObjectDetailsModal", vm);
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
