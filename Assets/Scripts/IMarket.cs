using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneFrame.Market.Core
{
    public interface IMarket
    {
        public Action<List<Product>> OnGetProducts {get; set;}

        public List<Product> Products {get;}

        public Task<bool> Buy(Product product);
    }
}