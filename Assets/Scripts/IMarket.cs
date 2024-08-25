using System;
using System.Collections.Generic;

namespace OneFrame.Market.Core
{
    public interface IMarket
    {
        public Action<List<Product>> OnGetProducts {get; set;}

        public List<Product> Products {get;}

        public bool Buy(Product product);
    }
}