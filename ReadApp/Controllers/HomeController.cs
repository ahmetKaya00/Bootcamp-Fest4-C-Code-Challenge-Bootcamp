﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadApp.Models;

namespace ReadApp.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
    }

    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;

        if(!String.IsNullOrEmpty(searchString)){

            ViewBag.SearchString = searchString;
            products = products.Where(p=>p.Name.ToLower().Contains(searchString)).ToList();
        }
         if(!String.IsNullOrEmpty(category) && category != "0"){
            products = products.Where(p=>p.CategoryId == int.Parse(category)).ToList();
        }

        var model = new ProductViewModel{
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Create(){

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product model){
        Repository.CreateProduct(model);
        return RedirectToAction("Index");
    }

}