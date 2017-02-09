/**
 * This file is part of O CLIP esta em baixo.

    O CLIP esta em baixo is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    O CLIP esta em baixo is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
 **/

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
