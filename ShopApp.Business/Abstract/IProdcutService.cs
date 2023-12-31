﻿using ShopApp.Entites;

namespace ShopApp.Business.Abstract
{
    public interface IProdcutService
    {
        Product GetById(int id);
        Product GetByIdWithCategories(int id);
        void Create(Product entity);
        void Create(Product entity, int[] categoryIds);
        void Update(Product entity);
        void Update(Product entity, int[] categoryIds);
        void Delete(Product entity);
        List<Product> GetALl();
        List<Product> GetProductsByCategory(String category, int page, int pageSize);

        IEnumerable<Product> GetPopularProduct();
        IEnumerable<Product> GetLastAddProduct();


        int GetCountByCategory(string category);

    }
}
