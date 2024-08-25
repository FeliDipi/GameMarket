using System;

namespace OneFrame.Market.Core
{
    public interface IProductUI
    {
        public Action<Product> OnBuy {get; set;}

        public void Setup(Product data);

        public void Buy();
    }
}