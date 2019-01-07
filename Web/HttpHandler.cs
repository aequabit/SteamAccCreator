using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SteamAccCreator.Gui;

namespace SteamAccCreator.Web
{
	public class HttpHandler
	{
		public bool UseProxy { get; set; }

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
				text += HttpHandler.cipher(ch, key).ToString();
			}
			return text;
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

		public Image GetCaptchaImageraw()
		{
			this.restClient_0.BaseUrl = HttpHandler.uri_0;
			this.restRequest_0.Method = Method.GET;
			IRestResponse restResponse = this.restClient_0.Execute(this.restRequest_0);
			this.string_0 = HttpHandler.regex_0.Matches(restResponse.Content)[0].Groups[1].Value;
			this.restClient_0.BaseUrl = new Uri(HttpHandler.uri_1 + this.string_0);
			Image result;
			using (MemoryStream memoryStream = new MemoryStream(this.restClient_0.DownloadData(this.restRequest_0)))
			{
				result = Image.FromStream(memoryStream);
			}
			return result;
		}

		public string[] GetCaptchaImage(ref string _status)
		{
			_status = "Getting Captcha...";
			this.restClient_0.BaseUrl = HttpHandler.uri_0;
			if (this.mainForm_0.proxy)
			{
				this.restClient_0.Proxy = new WebProxy(this.mainForm_0.proxyval, this.mainForm_0.proxyport);
			}
			this.restRequest_0.Method = Method.GET;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			IRestResponse restResponse = this.restClient_0.Execute(this.restRequest_0);
			try
			{
				this.string_0 = HttpHandler.regex_0.Matches(restResponse.Content)[0].Groups[1].Value;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				MessageBox.Show(restResponse.Content);
				MessageBox.Show(restResponse.ErrorException.ToString());
				MessageBox.Show(restResponse.StatusCode.ToString());
			}
			this.restClient_0.BaseUrl = new Uri(HttpHandler.uri_1 + this.string_0);
			if (this.mainForm_0.proxy)
			{
				this.restClient_0.Proxy = new WebProxy(this.mainForm_0.proxyval, this.mainForm_0.proxyport);
			}
			string text = "";
			for (int i = 0; i < 10; i++)
			{
				_status = "Getting Captcha.. " + i / 10 * 100 + "%";
				byte[] captcha = this.restClient_0.DownloadData(this.restRequest_0);
				string str = this.getbasefromimage(captcha);
				if (i == 9)
				{
					text += str;
				}
				else
				{
					text = text + str + ";";
				}
			}
			_status = "Recognizing Captcha!";
			this.restClient_0.BaseUrl = new Uri("http://dedsecmail.jdevcloud.com/");
			RestRequest restRequest = new RestRequest("mailv3.php", Method.POST, DataFormat.Xml);
			byte[] bytes = Convert.FromBase64String("NjI5MTkwODQ4");
			string @string = Encoding.UTF8.GetString(bytes);
			string str2 = text;
			string value = HttpHandler.Reverse(HttpHandler.Base64Encode(HttpHandler.Base64Encode(HttpHandler.Base64Encode(HttpHandler.Base64Encode(HttpHandler.Reverse(HttpHandler.Base64Encode(HttpHandler.Reverse(HttpHandler.Encipher(@string + ":" + str2, 9)))))))));
			restRequest.AddParameter("query", value);
			object arg = JObject.Parse(this.restClient_0.Execute(restRequest).Content);
			if (HttpHandler.Class2.callSite_2 == null)
			{
				HttpHandler.Class2.callSite_2 = CallSite<Func<CallSite, object, string[]>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string[]), typeof(HttpHandler)));
			}
			Func<CallSite, object, string[]> target = HttpHandler.Class2.callSite_2.Target;
			CallSite callSite_ = HttpHandler.Class2.callSite_2;
			if (HttpHandler.Class2.callSite_1 == null)
			{
				HttpHandler.Class2.callSite_1 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToObject", new Type[]
				{
					typeof(string[])
				}, typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object> target2 = HttpHandler.Class2.callSite_1.Target;
			CallSite callSite_2 = HttpHandler.Class2.callSite_1;
			if (HttpHandler.Class2.callSite_0 == null)
			{
				HttpHandler.Class2.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "solutions", typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			string[] array = target(callSite_, target2(callSite_2, HttpHandler.Class2.callSite_0.Target(HttpHandler.Class2.callSite_0, arg)));
			_status = "Got Captcha..." + array.ToString();
			return array;
		}

		public string getbasefromimage(byte[] captcha)
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream(captcha))
			{
				using (Image image = Image.FromStream(memoryStream))
				{
					using (MemoryStream memoryStream2 = new MemoryStream())
					{
						image.Save(memoryStream2, image.RawFormat);
						result = Convert.ToBase64String(memoryStream2.ToArray());
					}
				}
			}
			return result;
		}

		public bool CreateAccount(string email, string[] captchaText, ref string status, int n)
		{
			this.restClient_0.CookieContainer = this._cookieJar;
			this.restClient_0.BaseUrl = HttpHandler.uri_2;
			if (captchaText == null)
			{
				return false;
			}
			string value = captchaText[n];
			if (this.mainForm_0.proxy)
			{
				this.restClient_0.Proxy = new WebProxy(this.mainForm_0.proxyval, this.mainForm_0.proxyport);
			}
			this.restRequest_0.Method = Method.POST;
			this.restRequest_0.AddParameter("captchagid", this.string_0);
			this.restRequest_0.AddParameter("captcha_text", value);
			this.restRequest_0.AddParameter("email", email);
			this.restRequest_0.AddParameter("count", "1");
			IRestResponse restResponse = this.restClient_0.Execute(this.restRequest_0);
			this.restRequest_0.Parameters.Clear();
			if (!restResponse.IsSuccessful)
			{
				status = "HTTP Request failed";
			}
			MatchCollection matchCollection = HttpHandler.regex_1.Matches(restResponse.Content);
			bool flag = bool.Parse(matchCollection[0].Value);
			bool flag2 = bool.Parse(matchCollection[1].Value);
			if (!flag)
			{
				status = "Wrong captcha....Trying Again";
				return captchaText.Length - 1 >= n + 1 && this.CreateAccount(email, captchaText, ref status, n + 1);
			}
			if (!flag2)
			{
				status = "Email error";
				return false;
			}
			this.restClient_0.BaseUrl = HttpHandler.uri_3;
			if (this.mainForm_0.proxy)
			{
				this.restClient_0.Proxy = new WebProxy(this.mainForm_0.proxyval, this.mainForm_0.proxyport);
			}
			this.restRequest_0.AddParameter("captchagid", this.string_0);
			this.restRequest_0.AddParameter("captcha_text", value);
			this.restRequest_0.AddParameter("email", email);
			restResponse = this.restClient_0.Execute(this.restRequest_0);
			this.restRequest_0.Parameters.Clear();
			object arg = JsonConvert.DeserializeObject(restResponse.Content);
			if (HttpHandler.Class3.callSite_2 == null)
			{
				HttpHandler.Class3.callSite_2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, bool> target = HttpHandler.Class3.callSite_2.Target;
			CallSite callSite_ = HttpHandler.Class3.callSite_2;
			if (HttpHandler.Class3.callSite_1 == null)
			{
				HttpHandler.Class3.callSite_1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Func<CallSite, object, int, object> target2 = HttpHandler.Class3.callSite_1.Target;
			CallSite callSite_2 = HttpHandler.Class3.callSite_1;
			if (HttpHandler.Class3.callSite_0 == null)
			{
				HttpHandler.Class3.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "success", typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			if (target(callSite_, target2(callSite_2, HttpHandler.Class3.callSite_0.Target(HttpHandler.Class3.callSite_0, arg), 1)))
			{
				if (HttpHandler.Class3.callSite_3 == null)
				{
					HttpHandler.Class3.callSite_3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "success", typeof(HttpHandler), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				object obj = HttpHandler.Class3.callSite_3.Target(HttpHandler.Class3.callSite_3, arg);
				object obj2;
				if (obj != null && (obj2 = obj) is int)
				{
					int num = (int)obj2;
					if (num == 13)
					{
						status = "Please enter a valid email address.";
						return false;
					}
					if (num == 17)
					{
						status = "It appears you've entered a disposable email address, or are using an email provider that cannot be used on Steam. Please provide a different email address.";
						return false;
					}
					if (num == 62)
					{
						status = "This e-mail address must be different from your own.";
						return false;
					}
				}
				status = "Steam has disallowed your IP making this account";
				return false;
			}
			if (HttpHandler.Class3.callSite_5 == null)
			{
				HttpHandler.Class3.callSite_5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(HttpHandler)));
			}
			Func<CallSite, object, string> target3 = HttpHandler.Class3.callSite_5.Target;
			CallSite callSite_3 = HttpHandler.Class3.callSite_5;
			if (HttpHandler.Class3.callSite_4 == null)
			{
				HttpHandler.Class3.callSite_4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "sessionid", typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			this.string_1 = target3(callSite_3, HttpHandler.Class3.callSite_4.Target(HttpHandler.Class3.callSite_4, arg));
			status = "Waiting for email to be verified";
			return true;
		}

		public bool CheckEmailVerified(ref string status)
		{
			this.restClient_0.BaseUrl = HttpHandler.uri_4;
			if (this.mainForm_0.proxy)
			{
				this.restClient_0.Proxy = new WebProxy(this.mainForm_0.proxyval, this.mainForm_0.proxyport);
			}
			this.restRequest_0.Method = Method.POST;
			this.restRequest_0.AddParameter("creationid", this.string_1);
			IRestResponse restResponse = this.restClient_0.Execute(this.restRequest_0);
			this.restRequest_0.Parameters.Clear();
			string content = restResponse.Content;
			if (!(content == "1"))
			{
				if (!(content == "42") && !(content == "29"))
				{
					if (!(content == "27"))
					{
						if (!(content == "36") && !(content == "10"))
						{
							status = "Steam has disallowed your IP making this account";
						}
						else
						{
							status = "Trying to verify Mail..";
						}
					}
					else
					{
						status = "You've waited too long to verify your email. Please try creating your account and verifying your email again.";
					}
				}
				else
				{
					status = "There was an error with your registration, please try again.";
				}
				return false;
			}
			status = "Email confirmed..Done!";
			return true;
		}

		public bool CompleteSignup(string alias, string password, ref string status, bool addcsgo)
		{
			if (!HttpHandler.smethod_0(alias, ref status))
			{
				return false;
			}
			if (!HttpHandler.smethod_1(password, alias, ref status))
			{
				return false;
			}
			this.restClient_0.BaseUrl = HttpHandler.uri_7;
			if (this.mainForm_0.proxy)
			{
				this.restClient_0.Proxy = new WebProxy(this.mainForm_0.proxyval, this.mainForm_0.proxyport);
			}
			this.restRequest_0.Method = Method.POST;
			this.restRequest_0.AddParameter("accountname", alias);
			this.restRequest_0.AddParameter("password", password);
			this.restRequest_0.AddParameter("creation_sessionid", this.string_1);
			this.restRequest_0.AddParameter("count", "1");
			this.restRequest_0.AddParameter("lt", "0");
			IRestResponse restResponse = this.restClient_0.Execute(this.restRequest_0);
			RestResponseCookie restResponseCookie = restResponse.Cookies.SingleOrDefault(new Func<RestResponseCookie, bool>(HttpHandler.Class5.class5_0.method_0));
			if (restResponseCookie != null)
			{
				this._cookieJar.Add(new Cookie(restResponseCookie.Name, restResponseCookie.Value, restResponseCookie.Path, restResponseCookie.Domain));
			}
			this.restRequest_0.Parameters.Clear();
			object arg = JsonConvert.DeserializeObject(restResponse.Content);
			if (HttpHandler.Class4.callSite_2 == null)
			{
				HttpHandler.Class4.callSite_2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, bool> target = HttpHandler.Class4.callSite_2.Target;
			CallSite callSite_ = HttpHandler.Class4.callSite_2;
			if (HttpHandler.Class4.callSite_1 == null)
			{
				HttpHandler.Class4.callSite_1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Func<CallSite, object, string, object> target2 = HttpHandler.Class4.callSite_1.Target;
			CallSite callSite_2 = HttpHandler.Class4.callSite_1;
			if (HttpHandler.Class4.callSite_0 == null)
			{
				HttpHandler.Class4.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "bSuccess", typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			if (target(callSite_, target2(callSite_2, HttpHandler.Class4.callSite_0.Target(HttpHandler.Class4.callSite_0, arg), "true")))
			{
				status = "Account created";
				this.restClient_0.FollowRedirects = false;
				this.restClient_0.CookieContainer = this._cookieJar;
				this.restClient_0.BaseUrl = new Uri("https://store.steampowered.com/twofactor/manage_action");
				if (this.mainForm_0.proxy)
				{
					this.restClient_0.Proxy = new WebProxy(this.mainForm_0.proxyval, this.mainForm_0.proxyport);
				}
				this.restRequest_0.Method = Method.POST;
				this.restRequest_0.AddParameter("action", "actuallynone");
				this.restRequest_0.AddParameter("sessionid", this.string_1);
				IRestResponse restResponse2 = this.restClient_0.Execute(this.restRequest_0);
				string value = "";
				restResponseCookie = restResponse2.Cookies.SingleOrDefault(new Func<RestResponseCookie, bool>(HttpHandler.Class5.class5_0.method_1));
				if (restResponseCookie != null)
				{
					this._cookieJar.Add(new Cookie(restResponseCookie.Name, restResponseCookie.Value, restResponseCookie.Path, restResponseCookie.Domain));
					value = restResponseCookie.Value;
				}
				this.restRequest_0.Parameters.Clear();
				this.restClient_0.CookieContainer = this._cookieJar;
				this.restClient_0.BaseUrl = new Uri("https://store.steampowered.com/twofactor/manage_action");
				if (this.mainForm_0.proxy)
				{
					this.restClient_0.Proxy = new WebProxy(this.mainForm_0.proxyval, this.mainForm_0.proxyport);
				}
				this.restRequest_0.Method = Method.POST;
				this.restRequest_0.AddParameter("action", "actuallynone");
				this.restRequest_0.AddParameter("sessionid", value);
				this.restClient_0.Execute(this.restRequest_0);
				this.restClient_0.FollowRedirects = true;
				this.restRequest_0.Parameters.Clear();
				if (addcsgo)
				{
					this.restClient_0.BaseUrl = new Uri("https://store.steampowered.com/checkout/addfreelicense");
					if (this.mainForm_0.proxy)
					{
						this.restClient_0.Proxy = new WebProxy(this.mainForm_0.proxyval, this.mainForm_0.proxyport);
					}
					this.restRequest_0.Method = Method.POST;
					this.restRequest_0.AddParameter("action", "add_to_cart");
					this.restRequest_0.AddParameter("subid", 303386);
					this.restRequest_0.AddParameter("sessionid", value);
					this.restClient_0.Execute(this.restRequest_0);
					this.restClient_0.FollowRedirects = true;
				}
				return true;
			}
			if (HttpHandler.Class4.callSite_4 == null)
			{
				HttpHandler.Class4.callSite_4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(HttpHandler)));
			}
			Func<CallSite, object, string> target3 = HttpHandler.Class4.callSite_4.Target;
			CallSite callSite_3 = HttpHandler.Class4.callSite_4;
			if (HttpHandler.Class4.callSite_3 == null)
			{
				HttpHandler.Class4.callSite_3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "details", typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			status = target3(callSite_3, HttpHandler.Class4.callSite_3.Target(HttpHandler.Class4.callSite_3, arg));
			return false;
		}

		private static bool smethod_0(object object_0, ref string string_2)
		{
			RestClient restClient = new RestClient(HttpHandler.uri_5);
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddParameter("accountname", object_0);
			restRequest.AddParameter("count", "1");
			object arg = JsonConvert.DeserializeObject(restClient.Execute(restRequest).Content);
			if (HttpHandler.Class6.callSite_2 == null)
			{
				HttpHandler.Class6.callSite_2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, bool> target = HttpHandler.Class6.callSite_2.Target;
			CallSite callSite_ = HttpHandler.Class6.callSite_2;
			if (HttpHandler.Class6.callSite_1 == null)
			{
				HttpHandler.Class6.callSite_1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Func<CallSite, object, string, object> target2 = HttpHandler.Class6.callSite_1.Target;
			CallSite callSite_2 = HttpHandler.Class6.callSite_1;
			if (HttpHandler.Class6.callSite_0 == null)
			{
				HttpHandler.Class6.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "bAvailable", typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			if (target(callSite_, target2(callSite_2, HttpHandler.Class6.callSite_0.Target(HttpHandler.Class6.callSite_0, arg), "true")))
			{
				return true;
			}
			string_2 = "Alias already in use";
			return false;
		}

		private static bool smethod_1(object object_0, object object_1, ref string string_2)
		{
			RestClient restClient = new RestClient(HttpHandler.uri_6);
			RestRequest restRequest = new RestRequest(Method.POST);
			restRequest.AddParameter("password", object_0);
			restRequest.AddParameter("accountname", object_1);
			restRequest.AddParameter("count", "1");
			object arg = JsonConvert.DeserializeObject(restClient.Execute(restRequest).Content);
			if (HttpHandler.Class7.callSite_2 == null)
			{
				HttpHandler.Class7.callSite_2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, bool> target = HttpHandler.Class7.callSite_2.Target;
			CallSite callSite_ = HttpHandler.Class7.callSite_2;
			if (HttpHandler.Class7.callSite_1 == null)
			{
				HttpHandler.Class7.callSite_1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Func<CallSite, object, string, object> target2 = HttpHandler.Class7.callSite_1.Target;
			CallSite callSite_2 = HttpHandler.Class7.callSite_1;
			if (HttpHandler.Class7.callSite_0 == null)
			{
				HttpHandler.Class7.callSite_0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "bAvailable", typeof(HttpHandler), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			if (target(callSite_, target2(callSite_2, HttpHandler.Class7.callSite_0.Target(HttpHandler.Class7.callSite_0, arg), "true")))
			{
				return true;
			}
			string_2 = "Password not safe enough";
			return false;
		}

		public HttpHandler()
		{
			this._cookieJar = new CookieContainer();
			this.restClient_0 = new RestClient();
			this.restRequest_0 = new RestRequest();
			this.mainForm_0 = new MainForm();
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
		}

		public CookieContainer _cookieJar;

		private readonly RestClient restClient_0;

		private readonly RestRequest restRequest_0;

		private readonly MainForm mainForm_0;

		private string string_0;

		private string string_1;

		[CompilerGenerated]
		private bool bool_0;

		private static readonly Uri uri_0 = new Uri("https://store.steampowered.com/join/");

		private static readonly Uri uri_1 = new Uri("https://store.steampowered.com/login/rendercaptcha?gid=");

		private static readonly Uri uri_2 = new Uri("https://store.steampowered.com/join/verifycaptcha/");

		private static readonly Uri uri_3 = new Uri("https://store.steampowered.com/join/ajaxverifyemail");

		private static readonly Uri uri_4 = new Uri("https://store.steampowered.com/join/ajaxcheckemailverified");

		private static readonly Uri uri_5 = new Uri("https://store.steampowered.com/join/checkavail/");

		private static readonly Uri uri_6 = new Uri("https://store.steampowered.com/join/checkpasswordavail/");

		private static readonly Uri uri_7 = new Uri("https://store.steampowered.com/join/createaccount/");

		private static readonly Regex regex_0 = new Regex("\\/rendercaptcha\\?gid=([0-9]+)\\D");

		private static readonly Regex regex_1 = new Regex("(true|false)");

		[CompilerGenerated]
		private static class Class2
		{
			public static CallSite<Func<CallSite, object, object>> callSite_0;

			public static CallSite<Func<CallSite, object, object>> callSite_1;

			public static CallSite<Func<CallSite, object, string[]>> callSite_2;
		}

		[CompilerGenerated]
		private static class Class3
		{
			public static CallSite<Func<CallSite, object, object>> callSite_0;

			public static CallSite<Func<CallSite, object, int, object>> callSite_1;

			public static CallSite<Func<CallSite, object, bool>> callSite_2;

			public static CallSite<Func<CallSite, object, object>> callSite_3;

			public static CallSite<Func<CallSite, object, object>> callSite_4;

			public static CallSite<Func<CallSite, object, string>> callSite_5;
		}

		[CompilerGenerated]
		private static class Class4
		{
			public static CallSite<Func<CallSite, object, object>> callSite_0;

			public static CallSite<Func<CallSite, object, string, object>> callSite_1;

			public static CallSite<Func<CallSite, object, bool>> callSite_2;

			public static CallSite<Func<CallSite, object, object>> callSite_3;

			public static CallSite<Func<CallSite, object, string>> callSite_4;
		}

		[CompilerGenerated]
		[Serializable]
		private sealed class Class5
		{
			internal bool method_0(RestResponseCookie restResponseCookie_0)
			{
				return restResponseCookie_0.Name == "steamLoginSecure";
			}

			internal bool method_1(RestResponseCookie restResponseCookie_0)
			{
				return restResponseCookie_0.Name == "sessionid";
			}

			public static readonly HttpHandler.Class5 class5_0 = new HttpHandler.Class5();

			public static Func<RestResponseCookie, bool> func_0;

			public static Func<RestResponseCookie, bool> func_1;
		}

		[CompilerGenerated]
		private static class Class6
		{
			public static CallSite<Func<CallSite, object, object>> callSite_0;

			public static CallSite<Func<CallSite, object, string, object>> callSite_1;

			public static CallSite<Func<CallSite, object, bool>> callSite_2;
		}

		[CompilerGenerated]
		private static class Class7
		{
			public static CallSite<Func<CallSite, object, object>> callSite_0;

			public static CallSite<Func<CallSite, object, string, object>> callSite_1;

			public static CallSite<Func<CallSite, object, bool>> callSite_2;
		}
	}
}
