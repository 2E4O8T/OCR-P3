using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Configuration;
using P3AddNewFunctionalityDotNetCore.Data;
using P3AddNewFunctionalityDotNetCore.Controllers;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using Xunit;
using Microsoft.AspNetCore.Mvc;


namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class IntegrationTests
    {
        private readonly IStringLocalizer<ProductService> _localizer;
        private readonly IConfiguration _configuration;

        [Fact]
        public void SaveNewProductToDbTest()
        {
            var options = new DbContextOptionsBuilder<P3Referential>()
                .UseSqlServer("Server=.;Database=P3Referential-2f561d3b-493f-46fd-83c9-6e2643e7bd0a;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            var ctx = new P3Referential(options, _configuration);

            var cart = new Cart();
            var productRepository = new ProductRepository(ctx);
            var orderRepository = new OrderRepository(ctx);
            var languageService = new LanguageService();

            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, _localizer), languageService);

            var newProduct = new ProductViewModel()
            {
                Id = 1000,
                Name = "UnDroleDeNom",
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"

            };
            
            var expected = productController.Create(newProduct) as ViewResult;

            // Assert
            Assert.Null(expected);
        }

        [Fact]
        public void DeleteNewProductTest()
        {
            var options = new DbContextOptionsBuilder<P3Referential>()
                .UseSqlServer("Server=.;Database=P3Referential-2f561d3b-493f-46fd-83c9-6e2643e7bd0a;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            var ctx = new P3Referential(options, _configuration);

            var cart = new Cart();
            var productRepository = new ProductRepository(ctx);
            var orderRepository = new OrderRepository(ctx);
            var languageService = new LanguageService();

            ProductController productController = new ProductController(new ProductService(cart, productRepository, orderRepository, _localizer), languageService);
            ProductService productService = new ProductService(cart, productRepository, orderRepository, _localizer);

            var totalProduct = productService.GetAllProducts();
            var lastId = totalProduct.Max(p => p.Id);
            productController.DeleteProduct(lastId);

            // Assert
            Assert.DoesNotContain(productRepository.GetAllProducts(), p => p.Id == lastId);
        }
    }
}
