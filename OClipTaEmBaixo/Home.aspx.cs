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
using System.Threading;
using System.Net.Http;
using System.Web.Services;
using System.Web.Script.Services;

namespace OClipTaEmBaixo
{
    public partial class Home : System.Web.UI.Page
    {
        private const string DATE_FORMAT = "dd-MM-yyyy HH:mm";
        private const int TIME = 30000;
        private const string ADDRESS = "https://clip.unl.pt";

        //worker thread
        private static Thread RequestWorker = new Thread(RequestWorkProcedure);


        //data
        private static DateTime lastUp = DateTime.Now;
        private static DateTime lastDown = DateTime.Now;
        private static string ServerStatus = "OK";
        private static string currentRTT="";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!RequestWorker.IsAlive)
                //    RequestWorker.Start();
            }
            while (string.IsNullOrEmpty(ServerStatus)) ;
        }

        //Get methods for the data requested to the client
        [WebMethod()]
        public static Tuple<string,string> GetStatus()
        {
            return new Tuple<string,string>(ServerStatus,currentRTT);
        }

        [WebMethod()]
        public static string getLastUp()
        {
            return lastUp.ToString(DATE_FORMAT);
        }
        [WebMethod()]
        public static string getLastDown()
        {
            return lastDown.ToString(DATE_FORMAT);
        }


        //Procedure executed by the worker thread
        public static void RequestWorkProcedure()
        {
            var client = new HttpClient();
            string currentStatus = string.Empty;
            client.BaseAddress = new Uri(ADDRESS);
            while (true)
            {
                DateTime start = DateTime.Now;
                var response = client.GetAsync("/").Result;
                var status = response.StatusCode.ToString();
                int millisseconds = (DateTime.Now - start).Milliseconds;
                currentRTT = millisseconds.ToString();
                if (response.IsSuccessStatusCode)
                    lastUp = DateTime.Now;
                else
                    lastDown = DateTime.Now;

                ServerStatus = status.ToString();
                Thread.Sleep(TIME);
            }
        }


    }
}