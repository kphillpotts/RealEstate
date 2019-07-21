using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Controllers
{
	[Route("objectdetails")]
	public class ObjectDetailsController : Controller
    {
        public ObjectDetailsController(IDataRepository repo)
		{
			_repo = repo;
		}

		readonly IDataRepository _repo;


		[Route("{objectId}")]
        public async Task<IActionResult> Details(int objectId)
        {
			var objectDetails = await _repo.GetObjectDetails(objectId);

			var vm = new RealEstateObjectViewModel
			{
				Object = objectDetails,
				ImageUrl = $"/assets/objectimages/object-{objectDetails.Id}.jpg"
			};

			return View(vm);
        }
    }
}
