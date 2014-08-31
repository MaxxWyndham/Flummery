using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Flummery.Util
{

    class Updater
    {
        private struct UpdateResponse
        {
            public bool success;
            public string update;
        }

        public string UpdateUrl = "http://localhost/FlummeryUpdateService/update.php?client_version={0}";
        private WebRequest webRequest;

        Action<bool, string> responseCallback;

        public Updater()
        {

        }

        public void Check(string currentVersion, Action<bool, string> callback)
        {
            responseCallback = callback;
            webRequest = WebRequest.Create(string.Format(UpdateUrl, currentVersion));

            webRequest.BeginGetResponse(new AsyncCallback(finishRequest), null);
        }

        private void finishRequest(IAsyncResult result)
        {
            try
            {
                UpdateResponse response = (UpdateResponse)JsonConvert.DeserializeObject<UpdateResponse>(new StreamReader(webRequest.GetResponse().GetResponseStream()).ReadToEnd());
                responseCallback(response.success, response.update);
            }
            catch (Exception e)
            {
                responseCallback(false, null);
            }

        }
    }
}
