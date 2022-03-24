using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HidemyaccSample
{
    public class ChromeService
	{
		public ChromeDriver chrome { get; set; }
		public Process process { get; set; }
		public Profile CurrentProfile { get; set; }
		public string UserAgent { get; set; }
		public string Proxy { get; set; }
		public int TypeProxy { get; set; }
		public Point Size { get; set; }
		public Point Position { get; set; }

		public ChromeService()
		{
			UserAgent = "";
			Proxy = "";
			TypeProxy = 0;
			Position = new Point(0, 0);
			Size = new Point(1280, 720);
		}

		public bool StartProfile(string ProfileName = "")
		{
			StartProfileOptions options = new StartProfileOptions
			{
				proxy = new StartProfileOptions.Proxy { Host = "", Mode = "none", Password = "", Port = 0, Username = "" },
				windowSize = new StartProfileOptions.WindowSize { Heigh = Size.Y, Width = Size.X },
				windowPosition = new StartProfileOptions.WindowPosition { X = Position.X, Y = Position.Y },
				otherParmas = "--disable-notifications --disable-popup-blocking"
			};

			List<Profile> profiles = HmaApi.GetProfiles();
			Profile profile = profiles.Find(o => o.Name == ProfileName);
			if (profile == null)
			{

				User me = HmaApi.GetUser();
				if (me.MaxProfiles <= profiles.Count)
				{
					return false;
				}
				profile = HmaApi.CreateProfile(ProfileName, options.proxy);

			}

			if (profile == null)
			{
				return false;
			}

			CurrentProfile = profile;

			int port = HmaApi.StartProfile(profile.Id, options);

			if (port == 0)
			{
				return false;
			}

			ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
			chromeDriverService.HideCommandPromptWindow = true;

			ChromeOptions chromeOptions = new ChromeOptions
			{
				DebuggerAddress = "localhost:" + port
			};

			chrome = new ChromeDriver(chromeDriverService, chromeOptions);

			CloseOtherTabs();

			return true;
		}

		public void CloseOtherTabs()
		{
			try
			{
				var handles = chrome.WindowHandles;
				for (int index = 0; index < handles.Count; index++)
				{
					if (index != 0)
					{
						chrome.SwitchTo().Window(handles[index]);
						chrome.Close();
						Thread.Sleep(500);
					}
				}
				chrome.SwitchTo().Window(chrome.WindowHandles[0]);
			}
			catch { }
		}


		public void Close()
		{
			try
			{
				chrome.Quit();
				HmaApi.StopProfile(CurrentProfile.Id);
			}
			catch
			{
			}
		}

		public bool TestChromeDrive()
		{
			if (chrome == null) return false;

			string homeURL = "https://www.google.com";
			chrome.Navigate().GoToUrl(homeURL);
			WebDriverWait wait = new WebDriverWait(chrome, System.TimeSpan.FromSeconds(15));
			wait.Until(driver => driver.FindElement(By.Name("q")));
			IWebElement element = chrome.FindElement(By.Name("q"));
			element.SendKeys("Hello");
			Thread.Sleep(1000);
			element.SendKeys(Keys.Enter);

			Thread.Sleep(15000);

			Close();

			return true;
		}
	}
}
