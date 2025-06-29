using Dtos;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace API
{
    public class ApiClient : MonoBehaviour
    {
        public static string Token { get; set; }

        public static readonly string url = "https://localhost:7026";

        public static async Task<string> PerformApiCall(string method, string url, string jsonData = null, string token = null)
        {
            Debug.Log("json = " + jsonData);
            Debug.Log("Current token: " + (token ?? ApiClient.Token));

            using (UnityWebRequest request = new(url, method))
            {
                if (!string.IsNullOrEmpty(jsonData))
                {
                    byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);
                    request.uploadHandler = new UploadHandlerRaw(jsonToSend);
                }

                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                // Use the provided token if available, otherwise use ApiClient.Token
                string authToken = token ?? ApiClient.Token;
                if (!string.IsNullOrEmpty(authToken))
                {
                    request.SetRequestHeader("Authorization", "Bearer " + authToken);
                }

                await request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("API-call success: " + request.downloadHandler.text);
                    return request.downloadHandler.text;
                }
                else
                {
                    Debug.Log("API-call error: " + request.error);
                    return null;
                }
            }
        }

    }
}
