using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SecretSanta.Web.ViewModels;
using SecretSanta.Web.Data;

namespace SecretSanta.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View(MockData.User);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.User.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(MockData.User[id]);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.User[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            MockData.User.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}