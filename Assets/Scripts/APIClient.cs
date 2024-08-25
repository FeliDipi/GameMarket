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
        private string _apiURL = "http://localhost:3000/api/products";

        public async Task<List<Product>> Get()
        {
            try
            {
                string data = await GetCoroutine();
                Debug.Log($"Data received: {data}");

                return JsonConvert.DeserializeObject<List<Product>>(data);
            }
            catch(Exception ex)
            {
                Debug.LogError($"Error receiving data: {ex.Message}");
            }

            return new List<Product>();
        }

        private async Task<string> GetCoroutine()
        {
            using (UnityWebRequest request = UnityWebRequest.Get(_apiURL))
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

