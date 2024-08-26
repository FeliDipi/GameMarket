using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace OneFrame.Market.Core
{
    public class Market : MonoBehaviour, IMarket
    {
        [SerializeField] private string _userId = "66cb3b033d879d40806c2068";

        public Action<List<Product>> OnGetProducts { get; set; }
        public Action<User> OnGetUser { get; set; }
        public List<Product> Products => _products;
        private List<Product> _products = new List<Product>();

        private User _user;

        private APIClient _apiClient = new APIClient();

        private async void Start()
        {
            _products = await _apiClient.GetProducts();
            _user = await _apiClient.GetUser(_userId);
            
            OnGetProducts?.Invoke(_products);
            OnGetUser?.Invoke(_user);
        }

        public async Task<bool> Buy(Product product)
        {
            bool buyStatus = await _apiClient.BuyProduct(_userId,product.ID);

            if(buyStatus) 
            {
                Debug.Log($"Product with id: {product.ID} bought");

                _user = await _apiClient.GetUser(_userId);
                OnGetUser?.Invoke(_user);

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