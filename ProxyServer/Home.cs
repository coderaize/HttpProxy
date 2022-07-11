using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace ProxyServerApp
{
    public partial class Home : Form
    {
        ProxyServer proxyServer = new ProxyServer();
        string[] BlockedWebs { get; set; }
        public static string HomeDirectory { get; set; } = Environment.CurrentDirectory;

        public Home()
        {
            InitializeComponent();
            //
            ServicePointManager.ServerCertificateValidationCallback +=
             (s, certificate, chain, sslPolicyErrors)

             => true;
            //
            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //HomeDirectory = Properties.Settings.Default.HomeDirectory == "" ? Environment.CurrentDirectory : Properties.Settings.Default.HomeDirectory;
            HomeDirectory = Environment.CurrentDirectory;
            decryptSSLCheck.Checked = Properties.Settings.Default.isDecryptSSL;
            portNum.Value = Properties.Settings.Default.Port;
            if (Properties.Settings.Default.isStartOnLoad)
            {
                StartProxy();
                StartLocalService();
            }

            this.FormClosed += (x, y) => { Application.Exit(); Environment.Exit(0); };
        }

        private void StartLocalService()
        {
            System.Timers.Timer T = new System.Timers.Timer(5000);
            T.Elapsed += (e, a) =>
            {
                try
                {

                    BlockedWebs = File.ReadAllLines(Environment.CurrentDirectory + @"\BlockedWebs.txt");
                    //
                    if (File.Exists(HomeDirectory + @"\DetailedLogs.txt"))
                    {
                        FileInfo fi = new FileInfo(Environment.CurrentDirectory + @"\DetailedLogs.txt");
                        if (fi.Length > 1 * 1024 * 1024 * 10)
                        {
                            File.Move(Environment.CurrentDirectory + @"\DetailedLogs.txt", HomeDirectory + @"\DetailedLogs_" + DateTime.Now.ToString("(yyyy_MM_dd)_(hh_mm)") + ".txt");
                        }
                    }
                    if (!string.IsNullOrEmpty(LogMaker.DetailedLogs))
                    {
                        string logsFile = Environment.CurrentDirectory + @"\DetailedLogs.txt";
                        File.AppendAllText(logsFile, LogMaker.DetailedLogs);
                        LogMaker.DetailedLogs = "";
                    }
                }
                catch { }
                //}
            };
            T.Start();
        }


        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartProxy();
            StartLocalService();
        }

        private void StartProxy()
        {
            if (portNum.Value == 0) { MessageBox.Show("Please Enter available Port Number"); return; }
            try
            {
                proxyServer = new ProxyServer();
                // locally trust root certificate used by this proxy 
                //proxyServer.CertificateManager.TrustRootCertificate(true);
                // optionally set the Certificate Engine
                // Under Mono only BouncyCastle will be supported
                //proxyServer.CertificateManager.CertificateEngine = Network.CertificateEngine.BouncyCastle;
                //////////////////////////////////////////////////////////////////////
                proxyServer.BeforeRequest += OnRequest;
                //proxyServer.BeforeResponse += OnResponse;
                //proxyServer.ServerCertificateValidationCallback += OnCertificateValidation;
                //proxyServer.ClientCertificateSelectionCallback += OnCertificateSelection;
               

                //proxyServer.ClientCertificateSelectionCallback += OnCertificateSelection;
                var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, (int)portNum.Value, decryptSSLCheck.Checked) { };
                
                //explicitEndPoint.BeforeTunnelConnectRequest += OnBeforeTunnelConnect;

                proxyServer.AddEndPoint(explicitEndPoint);

                //////////////
                //proxyServer.ConnectionTimeOutSeconds = 600;


                proxyServer.Start();

                ///////////////////////////////////////////////////////////
                portNum.Enabled = false;
                foreach (var endPoint in proxyServer.ProxyEndPoints)
                {
                    majorLogsTxt.AppendText(string.Format("Listening on '{0}' endpoint at Ip {1} and port: {2} \n",
                          endPoint.GetType().Name, endPoint.IpAddress, endPoint.Port));

                    LogMaker.DetailedAddLogs(string.Format("Listening on '{0}' endpoint at Ip {1} and port: {2} \n",
                        endPoint.GetType().Name, endPoint.IpAddress, endPoint.Port));

                }
               
            }
            catch (Exception t) { LogMaker.DetailedAddLogs(t.Message, true); }

        }

      


        public async Task OnRequest(object sender, SessionEventArgs e)
        {
            this.Text = "[Connects]" + proxyServer.ThreadPoolWorkerThread.ToString();


            var datetime = DateTime.Now;
            LogMaker.DetailedAddLogs("----[]\r\n----[]\r\n[]"
                + datetime
                + "[]"
                + e.HttpClient.Request.Url);
            //Detailed Section
            if (detailedLogsCheck.Checked)
            {
                LogMaker.DetailedAddLogs("\r\n------------------------------\r\n[]"
                    + datetime.ToString()
                    + "[]\r\nRequest Header\r\n");
                e.HttpClient.Request.Headers.GetAllHeaders().ForEach(X =>
                {
                    LogMaker.DetailedAddLogs(X.Name + " : " + X.Value + "\r\n");
                });
                LogMaker.DetailedAddLogs("\r\n[]UserData[]\r\n");
                LogMaker.DetailedAddLogs(e.HttpClient.UserData.ToString());
                LogMaker.DetailedAddLogs("\r\n[]TimeLine[]\r\n");
                foreach (var a in e.TimeLine)
                {
                    LogMaker.DetailedAddLogs(a.Key + ":  " + a.Value.ToString() + "\n");
                }
                LogMaker.DetailedAddLogs("\r\n[][][][][][][][][][][][]\r\n");
            }
            //})).Start();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            proxyServer.Stop();
            majorLogsTxt.AppendText("Proxy Stopped\n\n");
            portNum.Enabled = true;
            proxyServer.Dispose();
        }


        private void BlockFileBtn_Click(object sender, EventArgs e)
        {
            Process.Start(HomeDirectory + @"\BlockedWebs.txt", "notepad.exe").WaitForExit();
            MessageBox.Show("Blocks Updated");
            BlockedWebs = File.ReadAllLines(HomeDirectory + @"\BlockedWebs.txt");
        }

        private void ClearMajorLogsaBtn_Click(object sender, EventArgs e)
        {
            majorLogsTxt.Text = "";
        }

        private void decryptSSLCheck_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
