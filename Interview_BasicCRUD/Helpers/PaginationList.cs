using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_BasicCRUD.Helpers
{
    public class PaginationList<T> : List<T>
    {

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }


        public PaginationList(int totalCount, int currentPage, int pageSize, List<T> items)
        {

            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            AddRange(items);
        }

        /// <summary>
        /// 工廠模式
        /// 1.使用Create 命名
        /// 2.回傳的內容是自己
        /// </summary>
        /// <returns></returns>
        public static async Task<PaginationList<T>> CreateAsync(
            int currentPage,
            int pageSize,
            IQueryable<T> result)
        {
            var totalCount = await result.CountAsync();
            //pageInation
            //Skip
            var skip = (currentPage - 1) * pageSize;
            result = result.Skip(skip);
            //以PageSize為標準顯示一定的資料
            result = result.Take(pageSize);

            var items = await result.ToListAsync();
            return new PaginationList<T>(totalCount, currentPage, pageSize, items);
        }
    }
}
