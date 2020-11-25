using Interview_BasicCRUD.Database;
using Interview_BasicCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_BasicCRUD.Services
{
    public class ProductRepositroy : IProductRepositroy
    {
        private readonly AppDbContext _context;

        public ProductRepositroy(AppDbContext context)
        {
            _context = context;
        }


        public async Task<bool> ProductExistsAsync(Guid productId)
        {
            return await _context.Products.AnyAsync(p => p.Id == productId);
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await _context.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<IQueryable<Product>> GetProductsAsync(string productName, string description)
        {
            IQueryable<Product> result = _context.Products.ToList().AsQueryable();

            #region Where 

            #region  ProductName
            if (!string.IsNullOrWhiteSpace(productName))
            {
                productName = productName.Trim();
                result = result.Where(t => t.ProductName.Contains(productName));
            }
            #endregion

            #region  Description
            if (!string.IsNullOrWhiteSpace(description))
            {
                description = description.Trim();
                result = result.Where(t => t.Description.Contains(description));
            }
            #endregion

            #endregion


            return result;

        }

        public async Task AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Add(product);
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
