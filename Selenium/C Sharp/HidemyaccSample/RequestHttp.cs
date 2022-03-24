using HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HidemyaccSample
{
	public class RequestHttp
	{
		public RequestHTTP request;

		private string UserAgent;

		private string Proxy;

		public RequestHttp(string cookie = "", string userAgent = "", string proxy = "", int typeProxy = 0)
		{
			if (userAgent == "")
			{
				UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36";
			}
			else
			{
				UserAgent = userAgent;
			}
			request = new RequestHTTP();
			request.SetSSL(SecurityProtocolType.Tls12);
			request.SetKeepAlive(k: true);
			request.SetDefaultHeaders(new string[2]
			{
				"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
				"user-agent: " + UserAgent
			});
			if (cookie != "")
			{
				AddCookie(cookie);
			}
			Proxy = proxy;
		}

		public string RequestGet(string url)
		{
			if (Proxy != "")
			{
				if (Proxy.Contains(":"))
				{
					return request.Request("GET", url, null, null, autoredrirect: true, new WebProxy(Proxy.Split(':')[0], Convert.ToInt32(Proxy.Split(':')[1]))).ToString();
				}
				return request.Request("GET", url, null, null, autoredrirect: true, new WebProxy("127.0.0.1", Convert.ToInt32(Proxy))).ToString();
			}
			return request.Request("GET", url).ToString();
		}

		public string RequestPost(string url, string data = "")
		{
			if (Proxy != "")
			{
				if (Proxy.Contains(":"))
				{
					return request.Request("POST", url, null, Encoding.ASCII.GetBytes(data), autoredrirect: true, new WebProxy(Proxy.Split(':')[0], Convert.ToInt32(Proxy.Split(':')[1]))).ToString();
				}
				return request.Request("POST", url, null, Encoding.ASCII.GetBytes(data), autoredrirect: true, new WebProxy("127.0.0.1", Convert.ToInt32(Proxy))).ToString();
			}
			return request.Request("POST", url, null, Encoding.ASCII.GetBytes(data)).ToString();
		}

		public void AddCookie(string cookie)
		{
			string[] array = cookie.Split(';');
			string text = "";
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split('=');
				if (array3.Count() > 1)
				{
					try
					{
						text = text + array3[0] + "=" + array3[1] + ";";
					}
					catch
					{
					}
				}
			}
			request.SetDefaultHeaders(new string[3]
			{
				"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8;charset=UTF-8",
				"user-agent: " + UserAgent,
				"cookie: " + text
			});
		}

		public string GetCookie()
		{
			return request.GetCookiesString();
		}
	}
}
