using NUnit.Framework;
using System;
using Tests.UI.Automated.Domain;
using Tests.UI.Automated.Pages;
using Tests.UI.Automated.Tests.Bases;

namespace Tests.UI.Automated.Tests
{
    public class ShopItemsTests: TestBase
    {
        private readonly CultureInformation _userCulture = new CultureInformation(CultureType.English, "en");

        /// <summary>
        /// Test case 3
        /// </summary>
        [Test]
        public void VerifyItemsQuantitiesInCart()
        {
            var quantityOfFunnyCowItemsToBuy = 2;
            var quantityOfFluffyBunnyItemsToBuy = 1;

            // From the home page go to shop page
            Console.WriteLine("From the home page go to shop page");
            var homePage = HomePage.NavigateHome(WebDriver, PlatformType, _userCulture, Wait, ConfigurationFile);
            var shopPage = homePage.NavigateShopPage();

            // Click buy button 2 times on “Funny Cow”
            Console.WriteLine($"Click buy button {quantityOfFunnyCowItemsToBuy} times on 'Funny Cow'");
            shopPage.ClickBuyButtonOfFunnyCow(quantityOfFunnyCowItemsToBuy);

            // Click buy button 1 time on “Fluffy Bunny”
            Console.WriteLine($"Click buy button {quantityOfFluffyBunnyItemsToBuy} time on 'Fluffy Bunny'");
            shopPage.ClickBuyButtonOfFluffyBunny(quantityOfFluffyBunnyItemsToBuy);

            // Click the cart menu
            Console.WriteLine("Click the cart menu");
            var cartPage = shopPage.NavigateCartPage();

            // Verify the items are in the cart
            Console.WriteLine("Verify the items are in the cart");
            var actualFunnyCowQuantityInCart = cartPage.GetFunnyCowQuantity();
            var actualFluffyBunnyQuantityInCart = cartPage.GetFluffyBunnyQuantity();

            Assert.AreEqual(quantityOfFunnyCowItemsToBuy, actualFunnyCowQuantityInCart,
                $"Number of 'Funny Cow' items in Cart is incorrect. Expected: '{quantityOfFunnyCowItemsToBuy}', Actual: '{actualFunnyCowQuantityInCart}'");
            Assert.AreEqual(quantityOfFluffyBunnyItemsToBuy, actualFluffyBunnyQuantityInCart,
                $"Number of 'Fluffy Bunny' items in Cart is incorrect. Expected: '{quantityOfFluffyBunnyItemsToBuy}', Actual: '{actualFluffyBunnyQuantityInCart}'");
        }

        /// <summary>
        /// Test case 4
        /// </summary>
        [Test]
        public void VerifyItemsPricesInCart()
        {
            var quantityOfStuffedFrogItemsToBuy = 2;
            var quantityOfFluffyBunnyItemsToBuy = 5;
            var quantityOfValentineBearItemsToBuy = 3;

            // From the home page go to shop page
            Console.WriteLine("From the home page go to shop page");
            var homePage = HomePage.NavigateHome(WebDriver, PlatformType, _userCulture, Wait, ConfigurationFile);
            var shopPage = homePage.NavigateShopPage();

            // Buy 2 Stuffed Frog
            Console.WriteLine($"Click buy button {quantityOfStuffedFrogItemsToBuy} times on 'Stuffed Frog'");
            shopPage.ClickBuyButtonOfStuffedFrog(quantityOfStuffedFrogItemsToBuy);

            // Buy 5 Fluffy Bunny
            Console.WriteLine($"Click buy button {quantityOfFluffyBunnyItemsToBuy} times on 'Fluffy Bunny'");
            shopPage.ClickBuyButtonOfFluffyBunny(quantityOfFluffyBunnyItemsToBuy);

            // Buy 3 Valentine Bear
            Console.WriteLine($"Click buy button {quantityOfValentineBearItemsToBuy} times on 'Valentine Bear'");
            shopPage.ClickBuyButtonOfValentineBear(quantityOfValentineBearItemsToBuy);

            // Get unit prices for Stuffed Frog, Fluffy Bunny, Valentine Bear in Shop page  
            Console.WriteLine($"Get unit prices for Stuffed Frog, Fluffy Bunny, Valentine Bear in Shop page");
            var stuffedFrogPriceInShopPage = shopPage.GetStuffedFrogPrice();
            var fluffyBunnyPriceInShopPage = shopPage.GetFluffyBunnyPrice();
            var valentineBearPriceInShopPage = shopPage.GetValentineBearPrice();

            // Click the cart menu
            Console.WriteLine("Click the cart menu");
            var cartPage = shopPage.NavigateCartPage();

            // Get unit prices for Stuffed Frog, Fluffy Bunny, Valentine Bear in Cart page 
            Console.WriteLine("Get unit prices for Stuffed Frog, Fluffy Bunny, Valentine Bear in Cart page");
            var stuffedFrogPriceCartPage = cartPage.GetStuffedFrogPrice();
            var fluffyBunnyPriceCartPage = cartPage.GetFluffyBunnyPrice();
            var valentineBearPriceCartPage = cartPage.GetValentineBearPrice();

            // Verify the price for each product
            Console.WriteLine("Verify the price for each product");
            Assert.AreEqual(stuffedFrogPriceInShopPage, stuffedFrogPriceCartPage,
                $"Price of 'Stuffed Frog' in Cart page is incorrect. Expected: '{stuffedFrogPriceInShopPage}', Actual: '{stuffedFrogPriceCartPage}'");
            Assert.AreEqual(fluffyBunnyPriceInShopPage, fluffyBunnyPriceCartPage,
                $"Price of 'Fluffy Bunny' in Cart page is incorrect. Expected: '{fluffyBunnyPriceInShopPage}', Actual: '{fluffyBunnyPriceCartPage}'");
            Assert.AreEqual(valentineBearPriceInShopPage, valentineBearPriceCartPage,
                $"Price of 'Valentine Bear' in Cart page is incorrect. Expected: '{valentineBearPriceInShopPage}', Actual: '{valentineBearPriceCartPage}'");

            // Calculate expected sub totals for the products
            Console.WriteLine("Calculate expected sub totals for the products");
            var stuffedFrogExpectedSubTotal = quantityOfStuffedFrogItemsToBuy * stuffedFrogPriceInShopPage;
            var fluffyBunnyExpectedSubTotal = quantityOfFluffyBunnyItemsToBuy * fluffyBunnyPriceInShopPage;
            var valentineBearExpectedSubTotal = quantityOfValentineBearItemsToBuy * valentineBearPriceInShopPage;

            // Get sub totals for Stuffed Frog, Fluffy Bunny, Valentine Bear in Cart page
            Console.WriteLine("Get sub totals for Stuffed Frog, Fluffy Bunny, Valentine Bear in Cart page");
            var stuffedFrogSubTotalCartPage = cartPage.GetStuffedFrogSubTotal();
            var fluffyBunnySubTotalCartPage = cartPage.GetFluffyBunnySubTotal();
            var valentineBearSubTotalCartPage = cartPage.GetValentineBearSubTotal();

            // Verify sub totals for each product
            Console.WriteLine("Verify sub totals for each product");
            Assert.AreEqual(stuffedFrogExpectedSubTotal, stuffedFrogSubTotalCartPage,
                $"Sub total of 'Stuffed Frog' in Cart page is incorrect. Expected: '{stuffedFrogExpectedSubTotal}', Actual: '{stuffedFrogSubTotalCartPage}'");
            Assert.AreEqual(fluffyBunnyExpectedSubTotal, fluffyBunnySubTotalCartPage,
                $"Sub total of 'Fluffy Bunny' in Cart page is incorrect. Expected: '{fluffyBunnyExpectedSubTotal}', Actual: '{fluffyBunnySubTotalCartPage}'");
            Assert.AreEqual(valentineBearExpectedSubTotal, valentineBearSubTotalCartPage,
                $"Sub total of 'Valentine Bear' in Cart page is incorrect. Expected: '{valentineBearExpectedSubTotal}', Actual: '{valentineBearSubTotalCartPage}'");

            // Calculate expected sub totals for the products
            Console.WriteLine("Calculate expected sub totals for the products");
            var expectedTotal = stuffedFrogExpectedSubTotal + fluffyBunnyExpectedSubTotal + valentineBearExpectedSubTotal;

            // Get total from Cart page
            Console.WriteLine("Get total from Cart page");
            var actualTotalCartPage = cartPage.GetTotal();

            // Verify that total = sum(sub totals)
            Console.WriteLine("Verify that total = sum(sub totals)");
            Assert.AreEqual(expectedTotal, actualTotalCartPage,
                $"Total in Cart page is incorrect. Expected: '{expectedTotal}', Actual: '{actualTotalCartPage}'");

        }
    }
}
