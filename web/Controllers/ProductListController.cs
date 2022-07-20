﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftBox.DataBase.Entities;
using SoftBox.DataBase.InterfacesRepository;

namespace MVCWebApplication.Controllers;

[Authorize]
public class ProductListController : Base.EntityController<Product, Guid> 
{
    private readonly IProductRepository productRepository;

    public ProductListController(IProductRepository productRepository) : base(productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<IActionResult> Index()
    {
        var product = await productRepository.GetAll();
        return View(Ok,product);
    }
    public async Task<IActionResult> GetProductByOrganizationName(string organizationName)
    {
        try
        {
            if (string.IsNullOrEmpty(organizationName))
                ModelState.AddModelError("Customer", "Not found organization");

            var faund = await productRepository.GetByName(organizationName);
            return View(Ok, faund);
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
            return BadRequest();
        }
    }
    public async Task<IActionResult> Create(Product product)
    {
        if (product is null) throw new ArgumentNullException(nameof(product));
        try
        {
            if (product.Id.ToString() == product.Name)
                ModelState.AddModelError("Customer", "The Display cannot exactly match the Name.");

            if (product.Price >= 10) // toggle switch limit 
                ModelState.AddModelError("Vendor", "The delivery price is too low.");
            if (product.Price <= 0)
                ModelState.AddModelError("Vendor", "The price of the product cannot be negative");

            if (ModelState.IsValid)
            {
                await productRepository.Add(product);
                TempData["success"] = "Product create successfully";
                return RedirectToAction("Index");
            }
            return View(Ok,product);
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    public async Task<IActionResult> Edit(Product product)
    {
        if (product is null) throw new ArgumentNullException(nameof(product));
        try
        {
            var obj = await productRepository.Update(product);
            TempData["success"] = "Product update successfully";
            return View(obj);
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
            return RedirectToAction("Index");
        }

    }
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var obj = await productRepository.GetById(id);
            if (obj == null) return NotFound();
            await productRepository.Delete(obj);
            TempData["success"] = "Product delete successfully";
            return View(obj);
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
            return RedirectToAction("Index");
        }
    }
}
