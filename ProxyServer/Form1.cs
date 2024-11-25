
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace ProxyServerApp
{
	public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private ProxyServer ProxyServer => new();

        private void StartProxy_Click(object sender, EventArgs e)
        {
            ProxyServer.BeforeRequest += OnRequest;
            
            //proxyServer.conn
            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, 9001, true) { };
            
            //explicitEndPoint.BeforeTunnelConnect += OnBeforeTunnelConnectRequest;
            ProxyServer.AddEndPoint(explicitEndPoint);

            ProxyServer.Start();
            foreach (var endPoint in ProxyServer.ProxyEndPoints)
			{
				majorLogsTxt.AppendText(string.Format("Listening on '{0}' endpoint at Ip {1} and port: {2} \n",
                    endPoint.GetType().Name, endPoint.IpAddress, endPoint.Port));
			}
		}

        private async Task OnBeforeTunnelConnectRequest(object sender, TunnelConnectSessionEventArgs e)
        {
            await Task.CompletedTask;

            string hostname = e.HttpClient.Request.RequestUri.Host;

            LogMaker.AddLogs("--------------Host Request--------");
            LogMaker.AddLogs("-------" + e.HttpClient.Request.Url + "--------");
            LogMaker.AddLogs("-------" + hostname + "--------");
            if (hostname.Contains("google.com"))
            {
                e.DecryptSsl = false;
            }
        }

        public async Task OnRequest(object sender, SessionEventArgs e)
        {
            //Console.WriteLine(e.HttpClient.Request.Url);
            // read request headers

            var requestHeaders = e.HttpClient.Request.Headers.GetAllHeaders();
            
            //var responseHeaders = e.HttpClient.Response.Headers.GetAllHeaders();
            LogMaker.AddLogs("--------------Request--------");
            LogMaker.AddLogs("-------" + e.HttpClient.Request.Url + "--------");
            requestHeaders.ForEach(X => { LogMaker.AddLogs(X.Name + " : " + X.Value); });
            LogMaker.AddLogs("-----------------------------");
            LogMaker.AddLogs("-----------------------------");
            LogMaker.AddLogs(e.HttpClient.UserData.ToString());
            
            //var a = e.GetRequestBodyAsString();
            //LogMaker.AddLogs("Form Data||||||||"+a);

            //LogMaker.AddLogs("Response---------------------");
            //LogMaker.AddLogs("-------" + e.HttpClient.Request.Url + "--------");
            //responseHeaders.ForEach(X => { LogMaker.AddLogs(X.Name + " : " + X.Value); });
            
            //if (e.HttpClient.Request.RequestUri.AbsoluteUri.Contains("musatours.com"))
            //{
            //    e.Ok("<!DOCTYPE html>" +
            //        "<html><body><h1>" +
            //        "Website Blocked" +
            //        "</h1>" +
            //        "<p>Blocked by AB Malik.</p>" +
            //        "</body>" +
            //        "</html>");
            //}
            // Redirect example
            //if (e.HttpClient.Request.RequestUri.AbsoluteUri.Contains("wikipedia.org"))
            //{
            //    e.Redirect("https://www.paypal.com");
            //}
        }


        private void EndProxy_Click(object sender, EventArgs e)
        {


            ProxyServer.Stop();
        }

        private void DoLogsCheck_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
