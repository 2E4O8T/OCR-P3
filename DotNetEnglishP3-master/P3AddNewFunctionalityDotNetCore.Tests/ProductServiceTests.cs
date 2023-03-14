using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using P3AddNewFunctionalityDotNetCore.Controllers;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Moq;
using Xunit;


namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTests
    {
        /// <summary>
        /// Take this test method as a template to write your test method.
        /// A test method must check if a definite method does its job:
        /// returns an expected value from a particular set of parameters
        /// </summary>
        [Fact]
        public void CreateEmptyProductTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = string.Empty,
                Price = string.Empty,
                Description = string.Empty,
                Stock = string.Empty,
                Details = string.Empty

            };

            // Act
            var result = productController.Create(product) as ViewResult;

            // Assert
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void CreateFullProductTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "NomRigolo",
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"
            };

            // Act
            var result = productController.Create(product) as ViewResult;

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void CreateEmptyNameProductTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = string.Empty,
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"
            };
            CultureInfo.CurrentUICulture = new CultureInfo("en-GB");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Single(errors);
            Assert.Equal("Please enter a name", errors.First());
            Assert.True(errors.Count == 1 && errors.First() == "Please enter a name");
        }

        [Fact]
        public void CreerProduitNomVideTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = string.Empty,
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"
            };
            CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Single(errors);
            Assert.Equal("Veuillez saisir un nom", errors.First());
        }

        [Fact]
        public void CreateEmptyPriceProductTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "NomRigolo",
                Price = string.Empty,
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("en-GB");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Single(errors);
            Assert.Equal("Please enter a price", errors.First());
        }

        [Fact]
        public void CreerProduitPrixVideTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "NomRigolo",
                Price = string.Empty,
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Single(errors);
            Assert.Equal("Veuillez saisir un prix", errors.First());
        }

        [Fact]
        public void CreateNegativePriceProductTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "UnDroleDeNom",
                Price = "-1",
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("en-GB");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Equal("The price must be greater than zero", errors[0]);
            Assert.Contains("The price must be greater than zero", errors);
        }

        [Fact]
        public void CreerPrixProduitNegatifTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "UnDroleDeNom",
                Price = "-1",
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Equal("La prix doit être supérieur à zéro", errors[0]);
            Assert.Contains("La prix doit être supérieur à zéro", errors);
        }

        [Fact]
        public void CreateNounPriceProductTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "UnDroleDeNom",
                Price = "Price",
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("en-GB");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Equal("The value entered for the price must be a number", errors[1]);
            Assert.Contains("The value entered for the price must be a number", errors);
        }

        [Fact]
        public void CreerPrixProduitNomTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "UnDroleDeNom",
                Price = "Prix",
                Description = "UneDroleDeChose",
                Stock = "1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Equal("La valeur saisie pour le prix doit être un nombre", errors[1]);
            Assert.Contains("La valeur saisie pour le prix doit être un nombre", errors);
        }

        [Fact]
        public void CreateEmptyStockProductTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "NomRigolo",
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = string.Empty,
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("en-GB");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Single(errors);
            Assert.Equal("Please enter a stock value", errors.First());

        }


        [Fact]
        public void CreerProduitStockVideTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "NomRigolo",
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = string.Empty,
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Single(errors);
            Assert.Equal("Veuillez saisir un stock", errors.First());

        }

        [Fact]
        public void CreateCommaStockProductTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "UnDroleDeNom",
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = "1.1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("en-GB");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Equal("The value entered for the stock must be a integer", errors[1]);
            Assert.Contains("The value entered for the stock must be a integer", errors);
        }

        [Fact]
        public void CreerStockProduitVirguleTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "UnDroleDeNom",
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = "1.1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Equal("La valeur saisie pour le stock doit être un entier", errors[1]);
            Assert.Contains("La valeur saisie pour le stock doit être un entier", errors);
        }

        [Fact]
        public void CreateNegativeStockProductTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "UnDroleDeNom",
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = "-1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("en-GB");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Equal("The stock must greater than zero", errors.First());
        }

        [Fact]
        public void CreerStockProduitNegatifTest()
        {
            // Arrange
            var languageService = Mock.Of<ILanguageService>();
            var cart = Mock.Of<ICart>();
            var productRepository = Mock.Of<IProductRepository>();
            var orderRepository = Mock.Of<IOrderRepository>();
            var localizer = Mock.Of<IStringLocalizer<ProductService>>();
            var productController = new ProductController(new ProductService(cart, productRepository, orderRepository, localizer), languageService);
            var product = new ProductViewModel()
            {
                Name = "UnDroleDeNom",
                Price = "1000",
                Description = "UneDroleDeChose",
                Stock = "-1",
                Details = "VraimentDrole"

            };
            CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");

            // Act
            var result = productController.Create(product) as ViewResult;
            var modelStateValues = result.ViewData.ModelState.Values;
            List<string> errors = new List<string>();
            foreach (var res in modelStateValues)
            {
                foreach (var err in res.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }

            //Assert
            Assert.False(result.ViewData.ModelState.IsValid);
            Assert.Equal("La stock doit être supérieure à zéro", errors.First());
        }
        // TODO write test methods to ensure a correct coverage of all possibilities
    }
}