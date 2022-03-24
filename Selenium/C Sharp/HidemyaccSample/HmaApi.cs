using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidemyaccSample
{
	public class HmaApi
	{
		public static string HOST = "http://localhost:12368";
		public static User currentUser;

		public static User GetUser()
		{
			try
			{
				RequestHttp requestHttp = new RequestHttp();
				string text = requestHttp.RequestGet(HOST + "/me");
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					if (((int)jObject["code"]) == 1)
					{
						JObject dataObject = (JObject)jObject["data"];
						User userProfile = new User
						{
							Id = (string)dataObject["id"],
							Email = (string)dataObject["email"],
							Profiles = (int)dataObject["profiles"],
							Plan = (string)dataObject["plan"]["name"],
							MaxProfiles = (int)dataObject["plan"]["maxProfiles"],
							ExpireDate = (DateTime)dataObject["expireDate"],
							CreatedAt = (DateTime)dataObject["createdAt"],
							LockEnabled = (bool)dataObject["lockEnabled"]
						};
						currentUser = userProfile;
						return userProfile;
					}
				}
			}
			catch { }
			return null;
		}

		public static List<Profile> GetProfiles()
		{
			List<Profile> profiles = new List<Profile>();
			try
			{
				RequestHttp requestHttp = new RequestHttp();
				string text = requestHttp.RequestGet(HOST + "/profiles");
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					if (((int)jObject["code"]) == 1)
					{
						JArray arr = JArray.FromObject(jObject["data"]);
						foreach (JObject dataObject in arr)
						{
							Profile profile = new Profile
							{
								Id = (string)dataObject["id"],
								Name = (string)dataObject["name"],
								Notes = (string)dataObject["notes"]
							};
							profiles.Add(profile);
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return profiles;
		}

		public static int StartProfile(string profileId, StartProfileOptions options)
		{
			try
			{
				RequestHttp requestHttp = new RequestHttp();

				JObject proxy = new JObject();
				proxy["host"] = options.proxy.Host;
				proxy["mode"] = options.proxy.Mode;
				proxy["password"] = options.proxy.Password;
				proxy["port"] = options.proxy.Port;
				proxy["username"] = options.proxy.Username;

				string paramString = $"{options.otherParmas} --window-position={options.windowPosition.X},{options.windowPosition.Y} --window-size={options.windowSize.Width},{options.windowSize.Heigh}";
				string windowSize = $"{options.windowSize.Width},{options.windowSize.Heigh}";

				string data = "params=" + paramString + "&windowSize=" + windowSize;

				if (options.proxy.Mode != "system")
				{
					data += "&proxy=" + proxy.ToString(Formatting.None);
				}

				string text = requestHttp.RequestPost(HOST + "/profiles/start/" + profileId, data);
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					if (((int)jObject["code"]) == 1)
					{
						return (int)jObject["data"]["port"];
					}
				}
			}
			catch { }
			return 0;
		}

		public static bool StopProfile(string profileId)
		{
			try
			{
				RequestHttp requestHttp = new RequestHttp();
				string text = requestHttp.RequestPost(HOST + "/profiles/stop/" + profileId);
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					if (((int)jObject["code"]) == 1)
					{
						return true;
					}
				}
			}
			catch { }
			return false;
		}

		public static Profile CreateProfile(string profileName, StartProfileOptions.Proxy proxy)
		{
			try
			{
				RequestHttp requestHttp = new RequestHttp();

				string data = "os=win&name=" + profileName;

				if (proxy.Mode == "http" || proxy.Mode == "socks5")
				{
					JObject proxyJson = new JObject();
					proxyJson["host"] = proxy.Host;
					proxyJson["mode"] = proxy.Mode;
					proxyJson["password"] = proxy.Password;
					proxyJson["port"] = proxy.Port;
					proxyJson["username"] = proxy.Username;

					data += "&proxy=" + proxyJson.ToString(Formatting.None);
				}

				string text = requestHttp.RequestPost(HOST + "/profiles", data);
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					if (((int)jObject["code"]) == 1)
					{
						JObject dataObject = (JObject)jObject["data"];
						Profile profile = new Profile
						{
							Id = (string)dataObject["id"],
							Name = (string)dataObject["name"],
							Notes = (string)dataObject["notes"]
						};
						return profile;
					}
				}
			}
			catch { }
			return null;
		}

		public static bool DeleteProfile(string profileId)
		{
			try
			{
				RequestHttp requestHttp = new RequestHttp();
				string text = requestHttp.RequestPost(HOST + "/profiles/delete/" + profileId);
				if (text != "")
				{
					JObject jObject = JObject.Parse(text);
					if (((int)jObject["code"]) == 1)
					{
						return true;
					}
				}
			}
			catch { }
			return false;
		}
	}

	public class StartProfileOptions
	{
		public Proxy proxy { get; set; }
		public WindowSize windowSize { get; set; }
		public WindowPosition windowPosition { get; set; }
		public string otherParmas { get; set; }
		public class WindowSize
		{
			public int Width { get; set; }
			public int Heigh { get; set; }
		}
		public class WindowPosition
		{
			public int X { get; set; }
			public int Y { get; set; }
		}
		public class Proxy
		{
			public string Host { get; set; }
			public string Mode { get; set; }
			public string Username { get; set; }
			public string Password { get; set; }
			public int Port { get; set; }

		}
	}

	public class User
	{
		public string Id { get; set; }
		public string Email { get; set; }
		public int Profiles { get; set; }
		public string Plan { get; set; }
		public int MaxProfiles { get; set; }
		public DateTime ExpireDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool LockEnabled { get; set; }

	}

	public class Profile
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
	}
}
