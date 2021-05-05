using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Api;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;
using System;
using System.Linq;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        public IUsersClient Client {get;}

        public UsersController(IUsersClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IActionResult> Index()
        {
            ICollection<UserDto> users = await Client.GetAllAsync();
            List<UserViewModel> viewModelUsers = new();
            int count = users.Select(item => item.Id).Max() ?? 0;
            foreach(UserDto e in users)
            {
                viewModelUsers.Add(new UserViewModel
                {
                    Id = e.Id ?? count,
                    FirstName = e.FirstName,
                    LastName = e.LastName
                });
            }
            return View(viewModelUsers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await Client.PostAsync(new UserDto() {
                    Id = viewModel.Id,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                });
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(MockData.Users[id]);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await Client.PutAsync(viewModel.Id,
                    new UserDto {Id = viewModel.Id, FirstName = viewModel.FirstName, LastName = viewModel.LastName});
             
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await Client.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
