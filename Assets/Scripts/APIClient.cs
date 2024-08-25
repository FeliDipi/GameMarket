using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient
{
    private string _apiURL = "http://localhost:3000/api/products";

    public async Task Get()
    {
        try
        {
            string data = await GetCoroutine();
            Debug.Log($"Data received: {data}");
        }
        catch(Exception ex)
        {
            Debug.LogError($"Error receiving data: {ex.Message}");
        }
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
