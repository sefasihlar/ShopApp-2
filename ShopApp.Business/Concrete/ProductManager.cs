﻿using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entites;

namespace ShopApp.Business.Concrete
{
    public class ProductManager : IProdcutService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productdal)
        {
            _productDal = productdal;
        }

        public void Create(Product entity, int[] categoryIds)
        {
            _productDal.Create(entity, categoryIds);
        }

        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetALl()
        {
            return _productDal.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productDal.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productDal.GetCountByCategory(category);
        }

        public IEnumerable<Product> GetLastAddProduct()
        {
            return _productDal.GetLastAddProduct().ToList();
        }

        public IEnumerable<Product> GetPopularProduct()
        {
            return _productDal.GetPopularProduct().ToList();
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            return _productDal.GetProductsByCategory(category, page, pageSize);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _productDal.Update(entity, categoryIds);
        }
    }
}
