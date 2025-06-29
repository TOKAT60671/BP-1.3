using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Dtos;
using Unity.Services.Core;
using System.Text.RegularExpressions;
using TMPro;




namespace API
{
    class ApiManager : MonoBehaviour
    {
        public TMP_InputField RusernameField;
        public TMP_InputField RpasswordField;
        public TMP_InputField LusernameField;
        public TMP_InputField LpasswordField;
        
        

        public async void Register()
        {
            if (!CheckPassword(RpasswordField.text))
            {
                Debug.Log("Password does not meet requirements.");
                return;
            }
            await ApiHelper.Register(RusernameField.text, RpasswordField.text);
            Debug.Log("Registration successful. You can now log in.");
            FindFirstObjectByType<ScreenManagerScript>().ToLogin();


        }


        public async void Login()
        {
            await ApiHelper.Login(LusernameField.text, LpasswordField.text);
            Debug.Log("Login successful.");
            FindFirstObjectByType<ScreenManagerScript>().ToSaves();
        }

        public static bool CheckPassword(string password)
        {
            // At least 10 characters, 1 lowercase, 1 uppercase, 1 digit, 1 non-alphanumeric
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{10,}$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
