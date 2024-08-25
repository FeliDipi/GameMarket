using System;
using System.Collections.Generic;
using UnityEngine;

namespace OneFrame.Market.Core
{
    public class Market : MonoBehaviour, IMarket
    {
        public Action<List<Product>> OnGetProducts { get; set; }
        public List<Product> Products => _products;
        private List<Product> _products = new List<Product>();

        private async void Start()
        {
            APIClient apiClient = new APIClient();
            _products = await apiClient.Get();

            OnGetProducts?.Invoke(_products);
        }

        public bool Buy(Product product)
        {
            bool buyStatus = true;

            if(buyStatus) 
            {
                Debug.Log($"Product with id: {product.ID} bought");

                GameObject item = Resources.Load<GameObject>($"Products/Item/{product.Reference}") ?? default;

                //Add item bought into player inventory
            }
            else
            {
                Debug.Log($"Not enough money for buy it");
            }

            return buyStatus;
        }
    }
}