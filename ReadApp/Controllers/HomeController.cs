using System.Diagnostics;
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
    public async Task<IActionResult> Create(Product model, IFormFile imageFile){

        var allowenExtensions = new[] {".jpg",".png",".jpeg"};

        if(imageFile != null){

            var extensions = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            if(!allowenExtensions.Contains(extensions)){
                ModelState.AddModelError("","Sadece .jpg .png,.jpeg türlerinde dosya yükleyebilirsiniz.");
            }
            else
            {
                var randomfileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img", randomfileName);

                try
                {
                    using(var stream = new FileStream(path, FileMode.Create)){
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomfileName;
                }
                catch
                {   
                    ModelState.AddModelError("","Dosya yüklenirken bir hata oluştu.");
                }
            }
        }else{
            ModelState.AddModelError("","Bir resim seçiniz.");
        }
        if(ModelState.IsValid){
            model.ProductId = Repository.Products.Count + 1;
            Repository.CreateProduct(model);
            return RedirectToAction("Index");
        }
       ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
       return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int? id){
        if(id == null){
            return NotFound();
        }

        var entity = Repository.Products.FirstOrDefault(p=>p.ProductId == id);
        if(entity == null){
            return NotFound();
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
       return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile){

        if(id != model.ProductId){
            return NotFound();
        }
                var allowenExtensions = new[] {".jpg",".png",".jpeg"};

        if(imageFile != null){

            var extensions = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            if(!allowenExtensions.Contains(extensions)){
                ModelState.AddModelError("","Sadece .jpg .png,.jpeg türlerinde dosya yükleyebilirsiniz.");
            }
            else
            {
                var randomfileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img", randomfileName);

                try
                {
                    using(var stream = new FileStream(path, FileMode.Create)){
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomfileName;
                }
                catch
                {   
                    ModelState.AddModelError("","Dosya yüklenirken bir hata oluştu.");
                }
            }
        }else{
            ModelState.AddModelError("","Bir resim seçiniz.");
        }
        if(ModelState.IsValid){
            Repository.EditProduct(model);
            return RedirectToAction("Index");
        }
       ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
       return View(model);
    }

    public IActionResult Delete(int? id){
        if(id == null){
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(p=>p.ProductId == id);
        if(entity == null){
            return NotFound();
        }

        Repository.DeleteProduct(entity);
        return RedirectToAction("index");
    }

}
