using RealEstate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Services
{
	public interface IDataRepository
	{
		Task<List<RealEstateObject>> GetFeaturedObjects();
		Task<RealEstateObject> GetObjectDetails(int objectId);
	}
}
