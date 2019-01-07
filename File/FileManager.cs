using System;
using System.IO;
using System.Threading.Tasks;

namespace SteamAccCreator.File
{
	public class FileManager
	{
		public void WriteIntoFile(string mail, bool writeMail, string alias, string pass, string path, bool original)
		{
			Task.Delay(2000).Wait();
			using (StreamWriter streamWriter = new StreamWriter(path, true))
			{
				if (original)
				{
					if (!writeMail)
					{
						streamWriter.WriteLine(alias + ":" + pass);
					}
					else
					{
						streamWriter.WriteLine(string.Concat(new string[]
						{
							alias,
							":",
							pass,
							":",
							mail
						}));
					}
				}
				else if (!original)
				{
					if (!writeMail)
					{
						streamWriter.WriteLine("Alias: \t\t" + alias);
						streamWriter.WriteLine("Pass: \t\t" + pass);
						streamWriter.WriteLine("Creation: \t" + DateTime.Now);
						streamWriter.WriteLine("###########################");
					}
					else
					{
						streamWriter.WriteLine("Mail: \t\t" + mail);
						streamWriter.WriteLine("Alias: \t\t" + alias);
						streamWriter.WriteLine("Pass: \t\t" + pass);
						streamWriter.WriteLine("Creation: \t" + DateTime.Now);
						streamWriter.WriteLine("###########################");
					}
				}
			}
		}
	}
}
