using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_BasicCRUD.ResourceParamaters
{
    public class PageResourceParamaters
    {
        private int _pageNumber = 1;
        private int _pageSize = 10;

        /// <summary>
        /// 最大上限設定為 50
        /// </summary>
        const int maxPageSize = 50;

        /// <summary>
        /// 第幾頁
        /// </summary>
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                if (value >= 1)
                {
                    _pageNumber = value;
                }
            }
        }

        /// <summary>
        /// 一頁顯示幾筆
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value >= 1)
                {
                    _pageSize = (value > maxPageSize) ? maxPageSize : value;
                }
            }
        }
    }
}
