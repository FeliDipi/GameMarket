using System.Collections.Generic;

namespace OneFrame.Market.Core
{
    public interface IMarket
    {
        public List<IProduct> Products {get;}
    }
}