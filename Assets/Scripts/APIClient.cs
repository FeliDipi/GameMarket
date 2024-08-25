using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace OneFrame.Market.Core
{
    public class APIClient
    {
        private string _apiURL = "http://localhost:3000/api";

        private List<string> _endPoints = new List<string>() {
            "products",
            "buy"
        };

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                string data = await GetProductsTask();
                Debug.Log($"Data received: {data}");

                return JsonConvert.DeserializeObject<List<Product>>(data);
            }
            catch(Exception ex)
            {
                Debug.LogError($"Error receiving data: {ex.Message}");
            }

            return new List<Product>();
        }

        public async Task<bool> BuyProduct(string userId, string productId)
        {
            bool state = await BuyProductTask(userId, productId);
            return state;
        }

        private async Task<bool> BuyProductTask(string userId, string productId)
        {
            string body = JsonConvert.SerializeObject(new {userId, productId});

            using (UnityWebRequest request = new UnityWebRequest($"{_apiURL}/{_endPoints[1]}","POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(body);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type","application/json");

                var operation = request.SendWebRequest();

                while(!operation.isDone) await Task.Yield();

                if(request.result == UnityWebRequest.Result.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private async Task<string> GetProductsTask()
        {
            using (UnityWebRequest request = UnityWebRequest.Get($"{_apiURL}/{_endPoints[0]}"))
            {
                var operation = request.SendWebRequest();

                while(!operation.isDone) await Task.Yield();

                if(request.result == UnityWebRequest.Result.Success)
                {
                    return request.downloadHandler.text;
                }
                else
                {
                    throw new Exception(request.error);
                }
            }
        }
    }
}

