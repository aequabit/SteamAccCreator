using System;
using System.Threading;
using System.Windows.Forms;
using SteamAccCreator.Gui;

namespace SteamAccCreator
{
	public static class MainClass
	{
		internal static void Main(string[] args)
		{
			MainClass.mutex_0 = new Mutex(true, "StmAccGen", out bool flag);
			if (!flag)
			{
				return;
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		private static Mutex mutex_0;
	}
}
