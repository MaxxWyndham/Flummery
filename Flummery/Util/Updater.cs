using System;
using System.IO;
using System.Net;

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
        private WebRequest webRequest;

        Action<bool, Update[]> responseCallback;

        public void Check(string currentVersion, Action<bool, Update[]> callback)
        {
            responseCallback = callback;
            webRequest = WebRequest.Create(string.Format(UpdateUrl, currentVersion));

            webRequest.BeginGetResponse(new AsyncCallback(finishRequest), null);
        }

        private void finishRequest(IAsyncResult result)
        {
            try
            {
                UpdateResponse response = JsonConvert.DeserializeObject<UpdateResponse>(new StreamReader(webRequest.GetResponse().GetResponseStream()).ReadToEnd());

                responseCallback(response.success, response.updates);
            }
            catch
            {
                responseCallback(false, null);
            }
        }
    }
}