using System.Collections.Generic;
using UnityEngine;

namespace OneFrame.Market.Core
{
    public class Market : MonoBehaviour, IMarket
    {
        public List<IProduct> Products => _products;

        private List<IProduct> _products = new List<IProduct>();

        private async void Start()
        {
            APIClient apiClient = new APIClient();
            await apiClient.Get();
        }
    }
}