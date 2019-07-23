﻿using System;

namespace RealEstate.Entities
{
	public class Property
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		public int NumberOfBathrooms { get; set; }
		public int NumberOfBedrooms { get; set; }
		public DateTimeOffset LastUpdatedUtc { get; set; }
	}
}
