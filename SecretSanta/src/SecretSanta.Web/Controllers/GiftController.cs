using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class GiftController : Controller
    {
        public IActionResult Index()
        {
            return View(MockData.Gift);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GiftViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Gift.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(MockData.Gift[id]);
        }

        [HttpPost]
        public IActionResult Edit(GiftViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Gift[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            MockData.Gift.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}