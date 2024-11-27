using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

			//ByPass Certificate Check
			ServicePointManager.ServerCertificateValidationCallback +=
			 (s, certificate, chain, sslPolicyErrors) => true;

			HomeDirectory = Environment.CurrentDirectory;
			decryptSSLCheck.Checked = Properties.Settings.Default.isDecryptSSL;
			portNum.Value = Properties.Settings.Default.Port;

			if (Properties.Settings.Default.isStartOnLoad)
			{
				StartProxy();
			}

			this.FormClosed += (x, y) =>
			{
				Application.Exit();
				Environment.Exit(0);
			};
		}


		private void StartBtn_Click(object sender, EventArgs e)
		{
			StartProxy();
		}

		private void StartProxy()
		{
			if (portNum.Value == 0)
			{
				MessageBox.Show("Please Enter available Port Number"); return;
			}
			try
			{
				proxyServer = new ProxyServer();

				// locally trust root certificate used by this proxy 
				// proxyServer.CertificateManager.TrustRootCertificate(true);

				// optionally set the Certificate Engine
				// Under Mono only BouncyCastle will be supported
				// proxyServer.CertificateManager.CertificateEngine = Network.CertificateEngine.BouncyCastle;
				//////////////////////////////////////////////////////////////////////

				proxyServer.BeforeRequest += OnRequest;
				proxyServer.BeforeResponse += OnResponse;
				proxyServer.ServerCertificateValidationCallback += OnCertificateValidation;
				proxyServer.ClientCertificateSelectionCallback += OnCertificateSelection;


				//proxyServer.ClientCertificateSelectionCallback += OnCertificateSelection;

				var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, (int)portNum.Value, decryptSSLCheck.Checked)
				{
					// Use self-issued generic certificate on all https requests
					// Optimizes performance by not creating a certificate for each https-enabled domain
					// Useful when certificate trust is not required by proxy clients
					// GenericCertificate = new X509Certificate2(Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "genericcert.pfx"), "password")
				};

				// Fired when a CONNECT request is received
				explicitEndPoint.BeforeTunnelConnectRequest += OnBeforeTunnelConnectRequest;

				// An explicit endpoint is where the client knows about the existence of a proxy
				// So client sends request in a proxy friendly manner
				proxyServer.AddEndPoint(explicitEndPoint);
				proxyServer.Start();

				// Transparent endpoint is useful for reverse proxy (client is not aware of the existence of proxy)
				// A transparent endpoint usually requires a network router port forwarding HTTP(S) packets or DNS
				// to send data to this endPoint
				var transparentEndPoint = new TransparentProxyEndPoint(IPAddress.Any, ((int)portNum.Value + 1), true)
				{
					// Generic Certificate hostname to use
					// when SNI is disabled by client
					// GenericCertificateName = "google.com"
				};

				proxyServer.AddEndPoint(transparentEndPoint);

				//
				portNum.Enabled = false;
				startBtn.Enabled = false;

				foreach (var endPoint in proxyServer.ProxyEndPoints)
				{
					majorLogsTxt.AppendText(string.Format("Listening on '{0}' endpoint at Ip {1} and port: {2} \n",
						  endPoint.GetType().Name, endPoint.IpAddress, endPoint.Port));

					Logger.Instance.Log(string.Format("Listening on '{0}' endpoint at Ip {1} and port: {2} \n",
						endPoint.GetType().Name, endPoint.IpAddress, endPoint.Port));
				}

			}
			catch (Exception t)
			{
				Logger.Instance.LogError(t.Message, t);
				majorLogsTxt.AppendText(t.Message);
			}

		}

		public async Task OnRequest(object sender, SessionEventArgs e)
		{
			await Task.CompletedTask;

			//Blocker
			var url = e.HttpClient.Request.Url;
			var isUrlBlocked = BlockedWebs.Any(url.StartsWith);

			if (isUrlBlocked)
			{
				e.Ok("<!DOCTYPE html>" +
					"<html><body><h1>" +
					"Website Blocked" +
					"</h1>" +
					"<p>Blocked by XC.</p>" +
					"</body>" +
					"</html>");
			}

			// Logger
			await Task.Run(() =>
			{
				var datetime = DateTime.Now;

				Logger.Instance.Log($"""
				-----------
				{datetime:yyyyMMdd_HHmmss.fff}
				{e.HttpClient.Request.Url}
				""");

				//Detailed Logs
				Logger.Instance.LogVerboseIf(() => detailedLogsCheck.Checked,
					$"""
					-----------
					{datetime:yyyyMMdd_HHmmss.fff}
					
					Request Header
					{string.Join("\r\n", e.HttpClient.Request.Headers.GetAllHeaders().Select(x => $"{x.Name}:{x.Value}"))}
					
					UserData
					{e.HttpClient.UserData}
					
					TimeLine
					{string.Join("\r\n", e.TimeLine.Select(x => $"{x.Key}:{x.Value}"))}
					[][][][]
					""");

				Invoke(() =>
				{
					Text = "[Connects]" + proxyServer.ThreadPoolWorkerThread.ToString();
				});
			}).ConfigureAwait(false);
		}

		private void StopBtn_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}


		private void BlockFileBtn_Click(object sender, EventArgs e)
		{
			Process.Start(HomeDirectory + @"\BlockedWebs.txt", "notepad.exe").WaitForExit();
			MessageBox.Show("Blocks Updated");
			BlockedWebs = File.ReadAllLines(HomeDirectory + @"\BlockedWebs.txt");
		}

		private void ClearMajorLogsaBtn_Click(object sender, EventArgs e)
		{
			majorLogsTxt.Clear();
		}

		private async Task OnCertificateSelection(object sender, CertificateSelectionEventArgs e)
		{
			await Task.CompletedTask;
		}

		private async Task OnCertificateValidation(object sender, CertificateValidationEventArgs e)
		{
			await Task.CompletedTask;
		}

		private async Task OnResponse(object sender, SessionEventArgs e)
		{
			await Task.CompletedTask;
		}

		private async Task OnBeforeTunnelConnectRequest(object sender, TunnelConnectSessionEventArgs e)
		{
			//Blocker
			var url = e.HttpClient.Request.Url;
			var isUrlBlocked = BlockedWebs.Any(url.StartsWith);

			if (isUrlBlocked)
			{
				e.DecryptSsl = true;
			}
			await Task.CompletedTask;
		}
	}
}
