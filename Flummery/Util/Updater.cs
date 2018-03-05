using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Flummery.Util
{
    public class Updater
    {
        public struct UpdateResponse
        {
            public bool success;
            public Update[] updates;
        }

        public struct Update
        {
            public string update;
            public string version;
            public string changelog;
        }

        public string UpdateUrl = "http://www.flummery.co.uk/fuss/update.php?client_version={0}";

        public void Check(string currentVersion, Action<bool, Update[]> callback)
        {
            Uri uri = new Uri(string.Format(UpdateUrl, currentVersion));

            (new HttpClient())
                .GetAsync(new Uri(string.Format(UpdateUrl, currentVersion)))
                .ContinueWith((requestTask) => finishRequest(requestTask, callback));
        }

        private void finishRequest(Task<HttpResponseMessage> result, Action<bool, Update[]> callback)
        {
            try
            {
                UpdateResponse response = JsonConvert.DeserializeObject<UpdateResponse>(result.Result.Content.ReadAsStringAsync().Result);

                callback(response.success, response.updates);
            }
            catch
            {
                callback(false, null);
            }
        }
    }
}