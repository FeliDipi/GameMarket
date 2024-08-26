using System.Collections.Generic;
using UnityEngine;

namespace OneFrame.Market.Core
{
    public class MarketView : MonoBehaviour 
    {
        [Header("Dependencies")]
        [SerializeField] private Market _market;

        [Header("UI")]
        [SerializeField] private RectTransform _productsContent;
        [SerializeField] private ProductUI _productUIPrefab;
        [SerializeField] private UserUI _userUI;

        private Dictionary<string,ProductUI> _productUICells = new Dictionary<string, ProductUI>();

        private void Awake()
        {
            _market.OnGetProducts += ShowProducts;
            _market.OnGetUser += ShowUser;
        }

        private void ShowProducts(List<Product> products)
        {
            if(_productUIPrefab == null) return;

            foreach(Product product in products)
            {
                ProductUI productUI = Instantiate(_productUIPrefab);
                productUI.Setup(product);
                productUI.OnBuy += BuyHandler;

                productUI.transform.SetParent(_productsContent);

                _productUICells[product.ID] = productUI;
            }
        }

        private void ShowUser(User user)
        {
            _userUI.Setup(user.Name,user.Balance);
        }

        private async void BuyHandler(Product product)
        {
            if(!_productUICells.ContainsKey(product.ID)) return;

            bool status = await _market.Buy(product);

            if(status)
            {
                Destroy(_productUICells[product.ID].gameObject);
                _productUICells.Remove(product.ID);
            }
        }
    }
}