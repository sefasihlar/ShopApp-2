﻿using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.ViewComponents
{
    public class GetPopularTrendProductViewComponent : ViewComponent
    {
        ProductManager _productManager = new ProductManager(new EfCoreProductDal());
        public IViewComponentResult Invoke()
        {
            return View(new ProductModel()
            {
                //categorilerden hangisini seçildigini bulmak için yapılan işlem
                Products = _productManager.GetALl().Where(x => x.Price <= 250).ToList(),
            });
        }
    }
}
