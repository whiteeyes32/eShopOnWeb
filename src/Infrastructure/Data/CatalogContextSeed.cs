﻿using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();
                if (!await catalogContext.CatalogBrands.AnyAsync())
                {
                    await catalogContext.CatalogBrands.AddRangeAsync(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogTypes.AnyAsync())
                {
                    await catalogContext.CatalogTypes.AddRangeAsync(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }
                if (!await catalogContext.CatalogMaterials.AnyAsync())
                {
                    await catalogContext.CatalogMaterials.AddRangeAsync(
                        GetPreconfiguredCatalogMaterials());

                    await catalogContext.SaveChangesAsync();
                }
                if (!await catalogContext.CatalogItems.AnyAsync())
                {
                    await catalogContext.CatalogItems.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand("Azure"),
                new CatalogBrand(".NET"),
                new CatalogBrand("Visual Studio"),
                new CatalogBrand("SQL Server"),
                new CatalogBrand("Other")
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType("Mug"),
                new CatalogType("T-Shirt"),
                new CatalogType("Sheet"),
                new CatalogType("USB Memory Stick")
            };
        }
        static IEnumerable<CatalogMaterial> GetPreconfiguredCatalogMaterials()
        {
            return new List<CatalogMaterial>()
            {
                new CatalogMaterial("Cotton"),
                new CatalogMaterial("Ceramic"),
                new CatalogMaterial("Human hair"),
                new CatalogMaterial("Tungsen"),
                new CatalogMaterial("Instant-Death Redshirt Material from Star Trek"),
                new CatalogMaterial("Purple"),
                new CatalogMaterial("Porcelain"),
                new CatalogMaterial("Plutonium"),
                new CatalogMaterial("Unknown"),
                new CatalogMaterial("Uranium-Cotton Blend")
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem(2,2,1, ".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5M,  "http://catalogbaseurltobereplaced/images/products/1.png", "Cotton"),
                new CatalogItem(1,2,2, ".NET Black & White Mug", ".NET Black & White Mug", 8.50M, "http://catalogbaseurltobereplaced/images/products/2.png", "Ceramic"),
                new CatalogItem(2,5,3, "Prism White T-Shirt", "Prism White T-Shirt", 12,  "http://catalogbaseurltobereplaced/images/products/3.png", "Human hair"),
                new CatalogItem(2,2,1, ".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12, "http://catalogbaseurltobereplaced/images/products/4.png", "Cotton"),
                new CatalogItem(3,5,4, "Roslyn Red Sheet", "Roslyn Red Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/5.png", "Tungsten"),
                new CatalogItem(2,2,1, ".NET Blue Sweatshirt", ".NET Blue Sweatshirt", 12, "http://catalogbaseurltobereplaced/images/products/6.png", "Cotton"),
                new CatalogItem(2,5,5, "Roslyn Red T-Shirt", "Roslyn Red T-Shirt",  12, "http://catalogbaseurltobereplaced/images/products/7.png", "Instant-Death Redshirt Material from Star Trek"),
                new CatalogItem(2,5,6, "Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt", 8.5M, "http://catalogbaseurltobereplaced/images/products/8.png", "Purple"),
                new CatalogItem(1,5,7, "Cup<T> White Mug", "Cup<T> White Mug", 12, "http://catalogbaseurltobereplaced/images/products/9.png", "Porcelain"),
                new CatalogItem(3,2,8, ".NET Foundation Sheet", ".NET Foundation Sheet", 12, "http://catalogbaseurltobereplaced/images/products/10.png", "Plutonium"),
                new CatalogItem(3,2,9, "Cup<T> Sheet", "Cup<T> Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/11.png", "Unknown"),
                new CatalogItem(2,5,10, "Prism White TShirt", "Prism White TShirt", 12, "http://catalogbaseurltobereplaced/images/products/12.png", "Uranium-Cotton Blend")
            };
        }
    }
}
