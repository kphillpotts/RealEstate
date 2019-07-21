using RealEstate.Entities;
using System.Collections.Generic;

namespace RealEstate.Models
{
	public class HomeViewModel : BaseViewModel
	{
		public List<RealEstateObject> FeaturedObjects { get; set; }
	}
}
