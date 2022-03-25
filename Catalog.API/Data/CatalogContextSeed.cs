using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetProductSamples());
            }
        }

        private static IEnumerable<Product> GetProductSamples()
        {
            return new List<Product> {
                new()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "iPhone13",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vestibulum, urna in accumsan elementum,
									dolor augue dapibus felis, ut tincidunt elit risus sit amet risus. Etiam erat felis, scelerisque eget
									laoreet quis, luctus at mauris. Donec pulvinar vel lorem sit amet placerat. Pellentesque odio erat, rutrum
									in leo sit amet, consectetur vehicula enim. Suspendisse nec aliquam lectus. In iaculis elit nibh. Suspendisse
									auctor enim in ultricies condimentum. Morbi pulvinar urna diam, ac varius risus commodo efficitur.",
                    Image = "product-1.png",
                    Price = 899.00M,
                    Category = "Smartphone"
                },
                new()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "iPhone13 Pro",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vestibulum, urna in accumsan elementum,
									dolor augue dapibus felis, ut tincidunt elit risus sit amet risus. Etiam erat felis, scelerisque eget
									laoreet quis, luctus at mauris. Donec pulvinar vel lorem sit amet placerat. Pellentesque odio erat, rutrum
									in leo sit amet, consectetur vehicula enim. Suspendisse nec aliquam lectus. In iaculis elit nibh. Suspendisse
									auctor enim in ultricies condimentum. Morbi pulvinar urna diam, ac varius risus commodo efficitur.",
                    Image = "product-2.png",
                    Price = 1299.00M,
                    Category = "Smartphone"
                },
                new()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "LG G7 ThinQ",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vestibulum, urna in accumsan elementum,
									dolor augue dapibus felis, ut tincidunt elit risus sit amet risus. Etiam erat felis, scelerisque eget
									laoreet quis, luctus at mauris. Donec pulvinar vel lorem sit amet placerat. Pellentesque odio erat, rutrum
									in leo sit amet, consectetur vehicula enim. Suspendisse nec aliquam lectus. In iaculis elit nibh. Suspendisse
									auctor enim in ultricies condimentum. Morbi pulvinar urna diam, ac varius risus commodo efficitur.",
                    Image = "product-3.png",
                    Price = 240.00M,
                    Category = "Home Kitchen"
                },
                new()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Huawei Plus",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vestibulum, urna in accumsan elementum,
									dolor augue dapibus felis, ut tincidunt elit risus sit amet risus. Etiam erat felis, scelerisque eget
									laoreet quis, luctus at mauris. Donec pulvinar vel lorem sit amet placerat. Pellentesque odio erat, rutrum
									in leo sit amet, consectetur vehicula enim. Suspendisse nec aliquam lectus. In iaculis elit nibh. Suspendisse
									auctor enim in ultricies condimentum. Morbi pulvinar urna diam, ac varius risus commodo efficitur.",
                    Image = "product-4.png",
                    Price = 399.00M,
                    Category = "White Appliances"
                },
                new()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Xiaomi Mi 9",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vestibulum, urna in accumsan elementum,
									dolor augue dapibus felis, ut tincidunt elit risus sit amet risus. Etiam erat felis, scelerisque eget
									laoreet quis, luctus at mauris. Donec pulvinar vel lorem sit amet placerat. Pellentesque odio erat, rutrum
									in leo sit amet, consectetur vehicula enim. Suspendisse nec aliquam lectus. In iaculis elit nibh. Suspendisse
									auctor enim in ultricies condimentum. Morbi pulvinar urna diam, ac varius risus commodo efficitur.",
                    Image = "product-5.png",
                    Price = 389.99M,
                    Category = "Smartphone"
                },
                new()
                {
                    Id = "602d2149e773f2a3990b47f0",
                    Name = "Samsung S22",
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vestibulum, urna in accumsan elementum,
									dolor augue dapibus felis, ut tincidunt elit risus sit amet risus. Etiam erat felis, scelerisque eget
									laoreet quis, luctus at mauris. Donec pulvinar vel lorem sit amet placerat. Pellentesque odio erat, rutrum
									in leo sit amet, consectetur vehicula enim. Suspendisse nec aliquam lectus. In iaculis elit nibh. Suspendisse
									auctor enim in ultricies condimentum. Morbi pulvinar urna diam, ac varius risus commodo efficitur.",
                    Image = "product-6.png",
                    Price = 1099.00M,
                    Category = "Smartphone"
                }
            };
        }
    }
}