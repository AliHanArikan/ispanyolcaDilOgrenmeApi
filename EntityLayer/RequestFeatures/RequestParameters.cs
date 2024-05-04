using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.RequestFeatures
{
    //bu class base class olacağı için abstract yapıyoruz
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;

        //auto-implemented property
        public int PageNumber { get; set; }
        private int _pageSize;

        //full property
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value }
        }

    }
}
