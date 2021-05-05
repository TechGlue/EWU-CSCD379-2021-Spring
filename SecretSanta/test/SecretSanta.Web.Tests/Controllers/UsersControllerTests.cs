using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Web.Api;
using SecretSanta.Web.Tests.Api;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Tests.controllers
{
    [TestClass]
    public class UsersControllersTests

    {       
        private WebApplicationFactory Factory{get;} = new();
        private TestableUsersClient Client {get;} = new();

        [TestMethod]
        public async Task Index_WithUsers_InvocesGetAllAsync()
        {
            //arrange
            UserDto user1 = new(){
                Id = 1,
                FirstName = "luis",
                LastName = "garcia"
            };

            UserDto user2 = new(){
                Id = 2,
                FirstName = "luis2",
                LastName = "garcia2"
            };
            TestableUsersClient usersClient = Factory.Client;
            usersClient.GetAllUsersReturnValue = new List<UserDto>(){
                user1, user2
            };
            HttpClient client = Factory.CreateClient();
            //act
            HttpResponseMessage response =  await client.GetAsync("/Users/");
            //assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(1,usersClient.GetAllAsyncInvocationCount);
        }

        //currently failing retry 
        [TestMethod]
        public async Task Create_WithValidModel_InvokePostAsync()
        {
            //Arrange
            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();

            List<UserDto> u = new(){
                new UserDto(){Id = 0,FirstName = "Luis", LastName = "Garcia" }
            };
 
            UserDto newUser = new()
            {
                FirstName = "Luis",
                LastName = "Garcia"
            };

            string json = System.Text.Json.JsonSerializer.Serialize(newUser);
            StringContent content = new (json);
            //Act
            HttpResponseMessage response =  await client.PostAsync("/Users/Create", content);
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(1,usersClient.PostAsyncInvocationCount);
            Assert.AreEqual(1, usersClient.PostAsyncInvokedParameters.Count);
            Assert.AreEqual(newUser.FirstName, usersClient.PostAsyncInvokedParameters[0].FirstName);
            Assert.AreEqual(newUser.LastName, usersClient.PostAsyncInvokedParameters[0].LastName);
        }
    
    }
}
