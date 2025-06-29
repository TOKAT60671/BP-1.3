using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;
using Dtos;

namespace API
{
    class ApiHelper : MonoBehaviour
    {
        // login / register deel
        public static async Task Login(string username, string password)
        {
            var loginResponse = await ApiClient.PerformApiCall(
                "post",
                ApiClient.url + "/user/login",
                jsonData: @$"{{""UserName"": ""{username}"", ""Password"" : ""{password}""}}"
);
            Debug.Log("Login response: " + loginResponse);

            var tokenObj = JsonConvert.DeserializeObject<AccessToken>(loginResponse);
            Debug.Log("Deserialized token: " + (tokenObj?.accessToken ?? "null"));

            ApiClient.Token = tokenObj?.accessToken;

        }

        public static async Task Register(string username, string password)
        {
            await ApiClient.PerformApiCall(
                "post",
                ApiClient.url + "/user/register",
                jsonData: @$"{{""UserName"": ""{username}"", ""Password"" : ""{password}""}}"
            );
        }

        // savegame deel
        public static async Task NewSave(string savename)
        {
            Debug.Log("Creating new save");
            await ApiClient.PerformApiCall(
                "post",
                ApiClient.url + "/data/saves",
                jsonData: @$"{{""Name"": ""{savename}""}}",
                token: ApiClient.Token
            );
        }

        public static async Task<string> GetSaves()
        {
            Debug.Log("getting saves");
            return await ApiClient.PerformApiCall(
                "get",
                ApiClient.url + "/data/saves",
                token: ApiClient.Token
            );
        }

        public static async Task<string> GetSave(Guid saveId)
        {
            return await ApiClient.PerformApiCall(
                "get",
                ApiClient.url + $"/data/saves/{saveId}",
                token: ApiClient.Token
            );
        }

        public static async Task SaveObjects(Guid saveId, GObjectDto[] gObjects)
        {
            await ApiClient.PerformApiCall(
                "post",
                ApiClient.url + $"/data/saves/{saveId}/objects",
                jsonData: JsonConvert.SerializeObject(gObjects),
                token: ApiClient.Token
            );
        }

        public static async Task DeleteSave(Guid saveId)
        {
            await ApiClient.PerformApiCall(
                "delete",
                ApiClient.url + $"/data/saves/{saveId}",
                token: ApiClient.Token
            );
        }
    }
}
