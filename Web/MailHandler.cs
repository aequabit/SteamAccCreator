using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using RestSharp;

namespace SteamAccCreator.Web
{
	public class MailHandler
	{
		public static int GetRandomNumber(int min, int max)
		{
			Random obj = MailHandler.random_0;
			int result;
			lock (obj)
			{
				result = MailHandler.random_0.Next(min, max);
			}
			return result;
		}

		public static string Reverse(string s)
		{
			char[] array = s.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		public static string Base64Encode(string plainText)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		}

		public static char cipher(char ch, int key)
		{
			if (!char.IsLetter(ch))
			{
				return ch;
			}
			char c = char.IsUpper(ch) ? 'A' : 'a';
			return (char)(((int)ch + key - (int)c) % 26 + (int)c);
		}

		public static string Encipher(string input, int key)
		{
			string text = string.Empty;
			foreach (char ch in input)
			{
				text += MailHandler.cipher(ch, key).ToString();
			}
			return text;
		}

		public void ConfirmMail(string address)
		{
			Thread.Sleep(5000);
			this.restClient_0.BaseUrl = MailHandler.jdevMailv3;
			this.restRequest_0.Method = Method.GET;
			byte[] bytes = Convert.FromBase64String("MTc4MTg4MjE5Mzg5MTI3MTo=");
			string value = MailHandler.Reverse(MailHandler.Base64Encode(MailHandler.Base64Encode(MailHandler.Base64Encode(MailHandler.Base64Encode(MailHandler.Reverse(MailHandler.Base64Encode(MailHandler.Reverse(MailHandler.Encipher(Encoding.UTF8.GetString(bytes) + address, 9)))))))));
			this.restRequest_0.AddParameter("query", value);
			IRestResponse restResponse = this.restClient_0.Execute(this.restRequest_0);
			object arg;
			try
			{
				arg = JsonConvert.DeserializeObject(restResponse.Content);
			}
			catch (Exception)
			{
				arg = "";
			}
			this.restRequest_0.Parameters.Clear();
			try
			{
				if (MailHandler.Class8.callSite_1 == null)
				{
					MailHandler.Class8.callSite_1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(MailHandler)));
				}
				Func<CallSite, object, string> target = MailHandler.Class8.callSite_1.Target;
				CallSite callSite_ = MailHandler.Class8.callSite_1;
				if (MailHandler.Class8.callSite_0 == null)
				{
					MailHandler.Class8.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "First", typeof(MailHandler), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				string input = target(callSite_, MailHandler.Class8.callSite_0.Target(MailHandler.Class8.callSite_0, arg));
				string[] array = Regex.Split(Regex.Split(input, "stoken=")[1], "&");
				string[] array2 = Regex.Split(Regex.Split(input, "creationid=")[1], " ");
				string arg2 = "stoken=" + array[0] + "&creationid=" + array2[0];
				this.method_1(new Uri(MailHandler.steamVerificationURL + arg2));
			}
			catch (Exception)
			{
			}
		}

		private string method_0(string string_0)
		{
			this.restClient_0.BaseUrl = MailHandler.jdevMailAPI;
			this.restRequest_0.Method = Method.GET;
			this.restRequest_0.AddParameter("locale", "en");
			this.restRequest_0.AddParameter("id", string_0);
			IRestResponse restResponse = this.restClient_0.Execute(this.restRequest_0);
			this.restRequest_0.Parameters.Clear();
			object arg = JsonConvert.DeserializeObject(restResponse.Content);
			if (MailHandler.Class9.callSite_1 == null)
			{
				MailHandler.Class9.callSite_1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(MailHandler)));
			}
			Func<CallSite, object, string> target = MailHandler.Class9.callSite_1.Target;
			CallSite callSite_ = MailHandler.Class9.callSite_1;
			if (MailHandler.Class9.callSite_0 == null)
			{
				MailHandler.Class9.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "bodyHtmlStrict", typeof(MailHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			return target(callSite_, MailHandler.Class9.callSite_0.Target(MailHandler.Class9.callSite_0, arg));
		}

		private void method_1(Uri uri_3)
		{
			this.restClient_0.BaseUrl = uri_3;
			this.restRequest_0.Method = Method.GET;
			this.restClient_0.Execute(this.restRequest_0);
			this.restRequest_0.Parameters.Clear();
		}

		public MailHandler()
		{
			this.restClient_0 = new RestClient();
			this.restRequest_0 = new RestRequest();
		}

		private static readonly Random random_0 = new Random();

		private readonly RestClient restClient_0;

		private readonly RestRequest restRequest_0;

		private static readonly Uri jdevMailv3 = new Uri("http://dedsecmail.jdevcloud.com/mailv3.php");

		private static readonly Uri jdevMailAPI = new Uri("http://dedsecmail.jdevcloud.com/mailapi.php");

		private static readonly Uri steamVerificationURL = new Uri("https://store.steampowered.com/account/newaccountverification?");

		private static readonly Regex regex_0 = new Regex("stoken=([^&]+).*creationid=([^\"]+)");

		[CompilerGenerated]
		private static class Class8
		{
			public static CallSite<Func<CallSite, object, object>> callSite_0;

			public static CallSite<Func<CallSite, object, string>> callSite_1;
		}

		[CompilerGenerated]
		private static class Class9
		{
			public static CallSite<Func<CallSite, object, object>> callSite_0;

			public static CallSite<Func<CallSite, object, string>> callSite_1;
		}
	}
}
