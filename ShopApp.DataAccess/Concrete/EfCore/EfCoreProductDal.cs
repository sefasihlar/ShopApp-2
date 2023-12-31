﻿using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entites;

namespace ShopApp.DataAccess.Concrete.EfCore
{

    public class EfCoreProductDal : EfCoreGenericRepository<Product, ShopContext>, IProductDal
    {
        public void Create(Product entity, int[] categoryIds)
        {
            using (var contex = new ShopContext())
            {
                var product = contex.Products
                                .Include(x => x.ProductCategories)
                                .FirstOrDefault(x => x.Id == entity.Id);
                if (product != null)
                {
                    product.Name = entity.Name;
                    product.ImageUrl = entity.ImageUrl;
                    product.Price = entity.Price;
                    product.Gender = entity.Gender;
                    product.Condition = entity.Condition;

                    product.ProductCategories = categoryIds.Select(x => new ProductCategory()
                    {
                        CategoryId = x,
                        ProductId = entity.Id
                    }).ToList();


                    contex.SaveChanges();
                }
            }
        }

        public Product GetByIdWithCategories(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(x => x.Id == id)
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var contex = new ShopContext())

            {
                //ekstra sorgu gönderebilmek için "asQueryable" yi kullandik
                var products = contex.Products.AsQueryable();
                //category bilgisi eger null degilse categoryle gore filtreleme yaparız
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        //"Any"bize true yada false deger dondurur
                        .Where(x => x.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                //sayisal bir değer döndürsün
                return products.Count();
            };
        }

        public IEnumerable<Product> GetLastAddProduct()
        {
            using (var _context = new ShopContext())
            {
                return _context.Products
                    .OrderByDescending(x => x.Id) // Id sütununa göre azalan sırayla sırala
                    .Take(9) // Son 9 öğeyi seç
                    .ToList(); // List olarak döndür
            }
        }

        public IEnumerable<Product> GetPopularProduct()
        {
            using (var _context = new ShopContext())
            {
                return _context.Products
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .Where(x => x.Price > 200)
                    .Take(8) // ilk 6 ürünü seçer
                    .ToList(); // fiyatı 30 dan büyük ilk 6 ürün getirlir.Güncellenecek
            }
        }
        //Kategoriye göre filtereleme işlemi
        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var contex = new ShopContext())

            {
                //ekstra sorgu gönderebilmek için "asQueryable" yi kullandik
                var products = contex.Products.AsQueryable();
                //category bilgisi eger null degilse categoryle gore filtreleme yaparız
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        //"Any"bize true yada false deger dondurur
                        .Where(x => x.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                //hangi saydaki ürünlerin alınacaginin yapıldıgı kısım
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            };
        }

        //ilişkili veri güncelleme işlemi
        public void Update(Product entity, int[] categoryIds)
        {
            using (var contex = new ShopContext())
            {
                var product = contex.Products
                                .Include(x => x.ProductCategories)
                                .FirstOrDefault(x => x.Id == entity.Id);
                if (product != null)
                {
                    product.Name = entity.Name;
                    product.ImageUrl = entity.ImageUrl;
                    product.Price = entity.Price;
                    product.Gender = entity.Gender;
                    product.Condition = entity.Condition;
                    product.Description = entity.Description;

                    product.ProductCategories = categoryIds.Select(x => new ProductCategory()
                    {
                        CategoryId = x,
                        ProductId = entity.Id
                    }).ToList();

                    contex.SaveChanges();



                }
            }
        }
    }
}
