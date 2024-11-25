﻿using System;
using System.IO;
using System.Text;
using System.Threading;

namespace ProxyServerApp
{
	public class Logger
	{
		private static Logger LocalInstanceHolder { get; set; }

		private Logger()
		{
		}

		private string LogPath = $"{Environment.CurrentDirectory}\\Logs.txt";

		private string VerbosePath = $"{Environment.CurrentDirectory}\\Logs.txt";

		private string ErrorPath = $"{Environment.CurrentDirectory}\\Errors.txt";

		public StringBuilder Logs { get; set; } = new();

		public StringBuilder VerboseLogs { get; set; } = new();

		public StringBuilder Errors { get; set; } = new();

		public static Logger Instance
		{
			get
			{
				if (LocalInstanceHolder == null)
				{
					LocalInstanceHolder = new Logger();
				}

				return LocalInstanceHolder;
			}
		}

		public void Log(string message)
		{
			Logs.AppendLine(message);
		}

		public void LogVerbose(string message)
		{
			VerboseLogs.AppendLine(message);
		}

		public void LogVerboseIf(Func<bool> func, string message)
		{
			if (func())
			{
				VerboseLogs.AppendLine(message);
			}
		}


		public void LogError(string message, Exception exception = null)
		{
			Errors.AppendLine(message + "\r\n" + exception.ToString());
		}

		private object lockObject = new object();

		public void LogDumper(CancellationToken ct)
		{
			var thread = new Thread(new ThreadStart(delegate
			{
				while (!ct.IsCancellationRequested)
				{
					try
					{
						WriteLog();
					}
					catch (Exception ex)
					{
						Logger.Instance.LogError("Error whule writing log", ex);
					}

					Thread.Sleep(15 * 1000);
				}
			}));

			thread.Start();
		}

		private void WriteLog()
		{
			new Thread(new ThreadStart(delegate
			{
				lock (lockObject)
				{
					using (StreamWriter file = new StreamWriter(LogPath, true))
					{
						file.WriteLine(Logs.ToString());
					}
					Logs.Clear();

					using (StreamWriter file = new StreamWriter(VerbosePath, true))
					{
						file.WriteLine(VerboseLogs.ToString());
					}
					VerboseLogs.Clear();

					using (StreamWriter file = new StreamWriter(ErrorPath, true))
					{
						file.WriteLine(Errors.ToString());
					}
					Errors.Clear();
				}
			})).Start();
		}
	}
}