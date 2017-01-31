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
        private static string ServerStatus = "";
        private static string currentRTT="";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!RequestWorker.IsAlive)
                    RequestWorker.Start();
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