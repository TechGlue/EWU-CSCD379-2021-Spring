using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Controllers;
using SecretSanta.Api.Dto;
using SecretSanta.Data;
using SecretSanta.Api.Tests.Business;
using SecretSanta.Business;


namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
            [TestMethod]
            public void Constructor_WithNullUserRepo_ThrowsAppropriateException()
            {
                ArgumentNullException ex = Assert.ThrowsException<ArgumentNullException>(
                    () => new UsersController(null!));
                Assert.AreEqual("repository", ex.ParamName);

                try
                {
                    new UsersController(null!);
                }
                catch(ArgumentException e)
                {
                    Assert.AreEqual("repository", e.ParamName);
                    return;
                }
                Assert.Fail("No exception thrown");
            }
            [TestMethod]
            public void Get_WithData_ReturnsUsers()
            {
                //Arrange
                UsersController controller = new(new UserRepository());

                //Act
                IEnumerable<UserDto> users = controller.Get();

                //Assert
                Assert.IsTrue(users.Any());
            }

            [TestMethod]
            [DataRow(42)]
            [DataRow(422222)]
            public async Task Get_WithValidID_ReturnsUser(int id)
            {
                //Arrange
                WebApplicationFactory factory = new();
                TestableUserManager manager = factory.Manager;
                UsersController controller = new(manager);
                
                User expectedUser = new() {Id = id, FirstName = "Papi", LastName = "Chulo"};
                
                HttpClient client = factory.CreateClient();
                manager.GetItemUser = expectedUser;
              
                //Act
                HttpResponseMessage response = await client.GetAsync("/api/Users/" + id );
                //Assert
                response.EnsureSuccessStatusCode();
                Assert.AreEqual(expectedUser, manager.GetItemUser);
                Assert.AreEqual(id, manager.GetItemId);
            }
            
            
            [TestMethod]
            public async Task Get_WithInValidID_ReturnsNotFound()
            {
                //Arrange
                WebApplicationFactory factory = new();
                TestableUserManager manager = factory.Manager;
                UsersController controller = new(manager);
                HttpClient client = factory.CreateClient();
                //Act
                HttpResponseMessage response = await client.GetAsync("/api/Users/-1" );
                //Assert
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            }
   
           [TestMethod]         
           public async Task Put_WithValidData_UpdatesUser()
           {
               //arrange
                WebApplicationFactory factory = new();
                TestableUserManager manager = factory.Manager;
               
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
               HttpResponseMessage response = await client.PutAsJsonAsync("/api/Users/42", updateUser);
              
               //assert
               response.EnsureSuccessStatusCode();
               Assert.AreEqual("Luis", manager.SavedUser?.FirstName);
           }

           [TestMethod]
           public async Task Put_WithInvalidData_ReturnsBadRequest()
           {
               //arrange
               WebApplicationFactory factory = new();
               TestableUserManager manager = factory.Manager;
               
               User foundUser = new User
               {
                   Id = -42
               };

               manager.GetItemUser = foundUser;

               HttpClient client = factory.CreateClient();
               UserDto updateUser = null;
               
               //act
               HttpResponseMessage response = await client.PutAsJsonAsync("/api/Users/"+foundUser.Id, updateUser);

               //assert
               Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
           }
    }
}
