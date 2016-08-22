using System;
using System.Collections.Generic;
using AutomatedTester.BrowserMob;
using AutomatedTester.BrowserMob.HAR;

namespace Exercise_3.Helpers
{
    public static class ProxyHelper
    {
        private static Server server;
        private static Client client;
        private const string bmp_path = @"c:\BrowserMobProxy\browsermob-proxy-2.1.2\bin\browsermob-proxy.bat";
        private const int bmp_port = 8888;

        public static Client GetProxy()
        {
            server = new Server(bmp_path, bmp_port);
            server.Start();
            client = server.CreateProxy();
            client.NewHar("test");
            return client;
        }

        public static void ProxyTeardown()
        {
            try
            {
                client.Close();
                server.Stop();
            }
            catch (Exception)
            {
            }
        }

        public static List<int> GetAllResponseCodes()
        {
            HarResult har = client.GetHar();
            Log log = har.Log;
            Entry[] entries = log.Entries;
            List<int> respons = new List<int>();

            foreach (var entry in entries)
            {
                var response = entry.Response;
                respons.Add(response.Status);
            }
            return respons;
        }

    }
}

