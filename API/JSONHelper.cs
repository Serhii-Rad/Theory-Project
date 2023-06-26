using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API
{
    public static class JSONHelper
    {
        public static T LoadJson<T>(string path)
        {
            string jsonString;
            using (StreamReader r = new StreamReader(path))
            {
                jsonString = r.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        /// <summary>
        /// Not sure about this variant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T LoadJson<T>(object json)
        {
            string jsonString = JsonConvert.SerializeObject(json);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
