using ETrade.DataAccess.Abstract;
using ETrade.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DataAccess.Concrete.EFCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, DataContext>, IProductDal
    {
        public int GetCountByCategory(string category)
        {
            using (var context = new DataContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }

                return products.Count();
            }
        }
        public virtual List<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            using (var context = new DataContext())
            {
                return filter == null
                     ? context.Products.Include("Images").ToList()
                     : context.Products.Include("Images").Where(filter).ToList();
            }
        }

        public Product GetProductDetails(int id)
        {
            using (var context = new DataContext())
            {
                return context.Products
                        .Where(p => p.Id == id)
                        .Include("Images")
                        .Include(p => p.ProductCategories)
                        .ThenInclude(p => p.Category)
                        .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var context = new DataContext())
            {
                var products = context.Products.Include("Images").AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }

                return products.Skip(page-1).Take(pageSize).ToList();   
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new DataContext())
            {
                var product = context.Products.Include(i=>i.ProductCategories).FirstOrDefault(i => i.Id == entity.Id);

                if(product != null)
                {
                    context.Images.RemoveRange(context.Images.Where(i => i.ProductId == entity.Id).ToList());
                    product.Price = entity.Price;
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
                    {
                        ProductId = entity.Id,
                        CategoryId = catId
                    }).ToList();

                    product.Images = entity.Images;
                }

                context.SaveChanges();
            }
        }
        public override void Delete(Product entity)
        {
            using (var context = new DataContext())
            {
                context.Images.RemoveRange(entity.Images);
                context.Products.Remove(entity);
                context.SaveChanges();
            }
        }

    }
}
