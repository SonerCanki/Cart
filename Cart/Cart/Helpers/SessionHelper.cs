using Cart.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(ISession session, string key , object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjetAsJson<T>(ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
