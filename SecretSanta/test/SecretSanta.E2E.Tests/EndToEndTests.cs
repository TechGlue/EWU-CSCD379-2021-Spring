using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaywrightSharp;
using System.Linq;
using SecretSanta.Web.Tests;

namespace SecretSanta.Web.Test
{
    [TestClass]
    public class EndToEndTests
    {
        private static WebHostServerFixture<Web.Startup, SecretSanta.Api.Startup> Server;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            Server = new();
        }
        
        [TestMethod]
        public async Task LaunchHomePage()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);
            //the variable under here is searching the html form for these divs and then looking for the contents. 
            var headerContent = await page.GetTextContentAsync("body > header > div > a");
            Assert.AreEqual("Secret Santa", headerContent);
        }
        
              
        [TestMethod]
        public async Task VerifyUsers()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");
           
            Assert.IsTrue(response.Ok);
        }
        
        [TestMethod]
        public async Task VerifyGifts()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");
           
            Assert.IsTrue(response.Ok);
        }
       
        [TestMethod]
        public async Task VerifyGroups()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Groups");
           
            Assert.IsTrue(response.Ok);
        }

        [TestMethod]
        public async Task CreateUser()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });
        
            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);
        
            Assert.IsTrue(response.Ok);
            
            await page.ClickAsync("text=Users");
            
            //make sure we have 5 speakers here
            var Users = await page.QuerySelectorAllAsync("body > section > section > section");
            int initialNumberUsers = Users.Count();
            Assert.AreEqual(initialNumberUsers, Users.Count());
            
            await page.ClickAsync("text=Create");
            await page.TypeAsync("input#FirstName", "Luis");
            await page.TypeAsync("input#LastName", "Garcia");
            
            await page.ClickAsync("text=Create");
            
            //make sure we have 6 after adding.
            Users = await page.QuerySelectorAllAsync("body > section > section > section");

            Assert.AreEqual(initialNumberUsers+1, Users.Count());
        }
        
        [TestMethod]
        public async Task ModifyLastUser()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);
            
            await page.ClickAsync("text=Users");
           
            await page.ClickAsync("body > section > section > section:last-child > a > section");
            Assert.IsTrue(response.Ok);
            
            await page.FillAsync("text=First Name", "Garcia");
            await page.FillAsync("text=Last Name", "Luis");
            await page.ClickAsync("text=Update");
            
            var sectionText = await page.GetTextContentAsync("body > section > section > section:last-child > a > section > div");
            Assert.IsTrue(sectionText.Contains("Garcia Luis"));
        }
        
        [TestMethod]
        public async Task DeleteUser()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);
            
            await page.ClickAsync("text=Users");
            
            
            var Users = await page.QuerySelectorAllAsync("body > section > section > section");
            int count = Users.Count();
            Assert.AreEqual(count, Users.Count());
            
            page.Dialog += (_, args) => args.Dialog.AcceptAsync();
           
            await page.ClickAsync("body > section > section > section:last-child > a > section > form > button");
            
            Users = await page.QuerySelectorAllAsync("body > section > section > section");
            Assert.AreEqual(count-1, Users.Count());
        }
        
        
        [TestMethod]
        public async Task ValidateUserText()
        {
            var localhost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(localhost);

            Assert.IsTrue(response.Ok);
            
            await page.ClickAsync("text=Users");
           
            var sectionText = await page.GetTextContentAsync("body > section > section > section:last-child > a > section > div");
            
            Assert.IsTrue(sectionText.Contains("Miracle Max"));
        }
     }
}
 
