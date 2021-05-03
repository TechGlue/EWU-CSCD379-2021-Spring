using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Web.Api;
using SecretSanta.Web.Tests.Api;

namespace SecretSanta.Web.Tests
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
            User user1 = new(){
                Id = 1,
                FirstName = "luis",
                LastName = "garcia"
            };

            User user2 = new(){
                Id = 2,
                FirstName = "luis2",
                LastName = "garcia2"
            };
            TestableUsersClient usersClient = Factory.Client;
            usersClient.GetAllUsersReturnValue = new List<User>(){
                user1, user2
            };
            HttpClient  client = Factory.CreateClient();
            //act
            HttpResponseMessage response =  await client.GetAsync("/Users/");
            //assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(1,usersClient.GetAllAsyncInvocationCount);
        }

        [TestMethod]
        public async Task Edit_WithValidModel_InvokePostAsync()
        {
            //Arrange
            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();
            //Act
            HttpResponseMessage response =  await client.GetAsync("/Users/");
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(1,usersClient.PostAsyncInvocationCount);
        }
    
    }
}
