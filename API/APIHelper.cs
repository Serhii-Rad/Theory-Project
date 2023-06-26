using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace API
{
    public static class APIHelper
    {
        private static string token = "8yy22TAZ5iuuKaTOo6EOmmYwOTQ2OTkyLTk1YjMtNGY2ZS1hZDIxLTA3YzRhZWFiY2Q2MA=="; //token for seleniumUI

        public static string EndPoint { get; set; } = @"https://api.syxsense.io";
        public static string ContentType { get; set; } = "application/json";
        public static HttpStatusCode StatusCode { get; private set; }
        public static string Token
        {
            get => token;
            set => token = value;
        }

        public static string GetRequest(string parameters) // space == %20
        {
            var client = new RestClient(EndPoint);
            var request = new RestRequest(parameters, Method.Get);
            Thread.Sleep(500);
            request.AddHeader("Authorization", Token);
            request.RequestFormat = DataFormat.Json;

            var response = client.ExecuteGetAsync(request).Result;
            StatusCode = response.StatusCode;
            Thread.Sleep(500);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var message = String.Format("Faile: Received HTTP {0}", response.StatusCode);
                throw new ApplicationException(message);
            }
            return response.Content;
        }

        /// <summary>
        /// Post the value in json string format and returns response. Example: "{"fieldName": "fieldValue"}"
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestData"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public static string PostRequest(string request, object requestData)
        {
            using var client = new RestClient(EndPoint);
            var postRequest = new RestRequest(request, Method.Post);
            if (Token != null)
                postRequest.AddHeader("Authorization", Token);
            if (requestData.GetType() != typeof(string))
                requestData = JsonConvert.SerializeObject(requestData);
            postRequest.AddStringBody(requestData.ToString(), DataFormat.Json);
            try
            {
                var response = client.PostAsync(postRequest).Result;
                StatusCode = response.StatusCode;
                return response.Content;
            }
            catch (Exception e)
            {
                
                if (e is AggregateException or HttpRequestException)
                {
                    // this is the correct way, but threre is a problem with HttpRequestException, it does not have "StatusCode" realisation in current version and it cannot be updated for some reason
                    HttpRequestException httpEx = (HttpRequestException)e.InnerException;
                    StatusCode = (HttpStatusCode)httpEx.StatusCode;

                    //string statusCode;
                    //if (e.InnerException == null)
                    //{
                    //    statusCode = e.Message.Split(' ').Last();
                    //    StatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), statusCode);
                    //    return null;
                    //}
                    //statusCode = e.InnerException.Message.Split(' ').Last();
                    //StatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), statusCode);
                    //return null;
                }
                StatusCode = HttpStatusCode.NotFound;
                throw;
            }
        }

        /// <summary>
        /// Return a json object. T is format model, like "RootObject"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="properties"></param>
        /// <param name="postData"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public static T GetJsonObject<T>(Func<string> method)
        {
            string jsonString = method.Invoke();
            var jsonModel = JsonConvert.DeserializeObject<T>(jsonString);
            return jsonModel;
        }
    }
}
