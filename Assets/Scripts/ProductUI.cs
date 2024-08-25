using System;
using UnityEngine;
using UnityEngine.UI;

namespace OneFrame.Market.Core
{
    public class ProductUI : MonoBehaviour, IProductUI
    {
        public Action<Product> OnBuy {get; set;}

        [Header("UI References")]
        [SerializeField] private Image _thumbnail;
        [SerializeField] private TMPro.TextMeshProUGUI _name;
        [SerializeField] private TMPro.TextMeshProUGUI _description;
        [SerializeField] private TMPro.TextMeshProUGUI _price;

        private Product _data;

        public void Setup(Product data)
        {
            _data = data;

            _thumbnail.sprite = Resources.Load<Sprite>($"Products/Thumbnail/{_data.Reference}") ?? default;
            _name.text = _data.Name;
            _description.text = _data.Description;
            _price.text = $"${_data.Price}";
        }

        public void Buy()
        {
            OnBuy?.Invoke(_data);
        }
    }
}