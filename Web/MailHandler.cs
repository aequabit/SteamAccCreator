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
            try
            {
                // Wait 5s
                Thread.Sleep(5000);

                // Rest apis to comunicate with
                var inboxKittenClient = new RestClient("https://inboxkitten.com/api/");
                var steamClient = new RestClient("https://store.steampowered.com/account/newaccountverification");

                // Request the inbox of email
                var listEmailsRequest = new RestRequest("v1/mail/list");
                listEmailsRequest.AddParameter("recipient", address.Split('@')[0]);
                var listEmailsResponse = inboxKittenClient.Execute(listEmailsRequest).Content;

                // Select the first email. Parse the response for a key and 2 letters that need to go before that key ie se-key
                var url = listEmailsResponse.Substring(listEmailsResponse.IndexOf("{\"url\":") + 8).Split('"')[0];
                var key = listEmailsResponse.Substring(listEmailsResponse.IndexOf("\"key\":\"") + 7).Split('"')[0];
                var region = url.Substring(8, 2);

                // Get the verification email
                var getEmailRequest = new RestRequest("v1/mail/getKey");
                getEmailRequest.AddParameter("mailKey", region + "-" + key);
                var emailResponse = inboxKittenClient.Execute(getEmailRequest).Content;

                // Parse the email for the verification link and (extract a token and id from it)
                var verifyLink = emailResponse.Substring(emailResponse.IndexOf("https://store.steampowered.com/account/newaccountverification")).Split('"')[0];
                var stoken = verifyLink.Substring(verifyLink.IndexOf("stoken=") + 7).Split('&')[0];
                var creationid = verifyLink.Substring(verifyLink.IndexOf("creationid=") + 11).Split('\\')[0];

                // Send the verification Request
                var verifySteamRequest = new RestRequest("");
                verifySteamRequest.AddParameter("stoken", stoken);
                verifySteamRequest.AddParameter("creationid", creationid);
                var verificationResponse = steamClient.Execute(verifySteamRequest).Content;

            }
            catch (Exception)
            {
                // Ignore errors
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
