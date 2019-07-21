using RealEstate.Entities;
using System;
using System.Collections.Generic;

namespace RealEstate
{
	internal class RealEstateHelpers
	{
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