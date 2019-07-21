using RealEstate.Entities;
using RealEstate.Models;
using System;
using System.Collections.Generic;

namespace RealEstate
{
	public static class RealEstateHelpers
	{
		public static RealEstateObjectViewModel ToViewModel(this RealEstateObject obj) => new RealEstateObjectViewModel {
			Object = obj,
			ImageUrl = $"/assets/objectimages/object-{obj.Id}.jpg"
		};

		internal static List<RealEstateObject> CreateRealEstateObjects()
		{
			var data = new List<RealEstateObject>();

			for (int i = 1; i < 100; i++)
			{
				data.Add(new RealEstateObject
				{
					Name = "Object " + i,
					NumberOfBathrooms = i,
					NumberOfBedrooms = i + 1,
					Id = i,
					Price = i * 10000,
					Description = "This is a beautiful object. Look at its ID of " + i,
					LastUpdatedUtc = DateTimeOffset.UtcNow.AddDays(-i)
				});
			}

			return data;
		}
	}
}