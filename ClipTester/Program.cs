using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClipTester
{
    class Program
    {
        public const int TIME = 3000;
        public const string ADDRESS = "https://clip.unl.pt";
        static void Main(string[] args)
        {
            var client = new HttpClient();
            string currentStatus = string.Empty;
            client.BaseAddress =  new Uri(ADDRESS);
            while (true) { 
            var response = client.GetAsync("/").Result;
                var status = response.StatusCode.ToString();
            if (!currentStatus.Equals(status.ToString()))
                { 
                    Console.WriteLine("Current Status is ---> {0}",status);
                    currentStatus = status.ToString();
                }
                System.Threading.Thread.Sleep(TIME);
            }
        }
    }
}
