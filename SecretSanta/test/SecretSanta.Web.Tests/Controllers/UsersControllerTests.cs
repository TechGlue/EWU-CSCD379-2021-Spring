using System;
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

        
        [TestMethod]
        public async Task Create_WithValidModel_InvokePostAsync()
        {
            //Arrange
            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();

            Dictionary<string, string?> dictionary = new(){
                {nameof(UserDto.FirstName),"Luis"},
                {nameof(UserDto.LastName),"Garcia"}
            };

            FormUrlEncodedContent content = new(dictionary!);
            //Act
            HttpResponseMessage response =  await client.PostAsync("/Users/Create", content);
            //Assert
            response.EnsureSuccessStatusCode();
            
            Assert.AreEqual(1,usersClient.PostAsyncInvocationCount);
            Assert.AreEqual(1, usersClient.PostAsyncInvokedParameters.Count);
            Assert.AreEqual("Luis", usersClient.PostAsyncInvokedParameters[0].FirstName);
            Assert.AreEqual("Garcia", usersClient.PostAsyncInvokedParameters[0].LastName);
        }
        
                
        [TestMethod]
        public async Task Edit_WithValidId_InvokePutAsync()
        {
            //Arrange
            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();

            Dictionary<string, string?> dictionary = new(){
                {nameof(UserDto.FirstName),"Luis"},
                {nameof(UserDto.LastName),"Garcia"}
            };

            FormUrlEncodedContent content = new(dictionary!);
            //Act
            HttpResponseMessage response =  await client.PostAsync("/Users/Edit/0", content);
            //Assert
            response.EnsureSuccessStatusCode();
            //was not able to finish on time.
        }

        [TestMethod]
        public async Task delete_WithValidID_InvokePutAsync()
        {
            //Arrange
            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();

            List<UserDto> users = new()
            {
                new UserDto() {Id = 0, FirstName = "Luis", LastName = "Garcia"},
                new UserDto() {Id = 2, FirstName = "Bill", LastName = "Tree"}
            };

            //needs love :(

        }
    
    }
}
