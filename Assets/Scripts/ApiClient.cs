using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{
   public async void Register()
    {
        var request = new PostRegisterRequestDto()
        {
            email = "naam321432432134@test.nl",
            password = "33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!"
        };

       var jsondata = JsonUtility.ToJson(request);
        Debug.Log(jsondata);
        await PerformApiCall("https://avansict2231887.azurewebsites.net/account/register", "POST", jsondata);
    }

    public async void Login()
    {
        var request = new PostRegisterRequestDto()
        {
            email = "orm123@test.nl",
            password = "33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!33nW@chtWoord!"
        };

        var jsondata = JsonUtility.ToJson(request);
        Debug.Log(jsondata);
        var response = await PerformApiCall("https://avansict2231887.azurewebsites.net/account/login", "POST", jsondata);
        Debug.Log(response);
        var ResponseDto = JsonUtility.FromJson<PostLoginRequestDto>(response);
    }



    private async Task<string> PerformApiCall(string url, string method, string jsonData = null, string token = null)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, method))
        {
            if (!string.IsNullOrEmpty(jsonData))
            {
                byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            if (!string.IsNullOrEmpty(token))
            {
                request.SetRequestHeader("Authorization", "Bearer " + token);
            }

            request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("API-aanroep is successvol: " + request.downloadHandler.text);

                return request.downloadHandler.text;
            }
            else
            {
                Debug.Log("Fout bij API-aanroep: " + request.error);
                return null;
            }
        }
    }
}
