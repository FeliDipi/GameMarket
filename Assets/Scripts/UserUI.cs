using UnityEngine;

namespace OneFrame.Market.Core
{
    public class UserUI : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private TMPro.TextMeshProUGUI _name;
        [SerializeField] private TMPro.TextMeshProUGUI _balance;

        public void Setup(string name, float balance)
        {
            _name.text = name;
            _balance.text = $"${balance}";
        }
    }
}