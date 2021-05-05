using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Dto;
using SecretSanta.Data;
using SecretSanta.Api.Tests.Business;


namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
           [TestMethod]         
           public async Task Put_WithValidData_UpdatesUser()
           {

               //arrange
                TestableUserManager manager = new TestableUserManager();
                WebApplicationFactory factory = new();
                
                User foundUser = new User
                {
                    Id = 42
                };

                manager.GetItemUser = foundUser;
                HttpClient client = factory.CreateClient();

                UserDto updateUser = new()
                {
                    FirstName = "Luis",
                    LastName = "Garcia"

                };
               //act
               HttpResponseMessage response = await client.PutAsJsonAsync("api/Users/42", updateUser);
              
               //assert
               response.EnsureSuccessStatusCode();
               Assert.AreEqual("Luis", manager.SavedUser?.FirstName);
           }
    }
}
