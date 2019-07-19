﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Entities;

namespace RealEstate.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Using fluent API to configure entities: https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
			builder.Entity<RealEstateObject>()
				.ToTable("RealEstateObjects")
				.HasKey(x => x.Id);

			// Seed some data: https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
			var testData = RealEstateHelpers.CreateRealEstateObjects();
			builder.Entity<RealEstateObject>().HasData(testData);
		}

		public DbSet<RealEstateObject> RealEstateObjects { get; set; }
	}
}
