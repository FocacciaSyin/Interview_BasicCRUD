using Interview_BasicCRUD.Helpers;
using Interview_BasicCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview_BasicCRUD.Services
{
    public interface IProductRepositroy
    {
        #region GET
        /// <summary>
        /// [GET]取得產品清單
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="description"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        Task<PaginationList<Product>> GetProductsAsync(
            string productName, string description,
            int pageSize, int pageNumber
            );

        /// <summary>
        /// [GET]使用產品ID取得該產品資料
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(Guid productId);

        /// <summary>
        /// [GET]確認產品是否存在
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> ProductExistsAsync(Guid productId);
        #endregion

        #region POST
        /// <summary>
        /// [POST]新增一個產品基本資料
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task AddProduct(Product product);

        #endregion

        #region DELETE
        /// <summary>
        /// [DELETE]刪除產品基本資料
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task DeleteProduct(Product product);
        #endregion

        Task<bool> SaveAsync();
    }
}
