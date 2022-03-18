import time
from hidemyacc import Hidemyacc
from sys import platform
from selenium import webdriver
from selenium.webdriver.chrome.options import Options

hma = Hidemyacc()
profile_id = '622eb5fccce7ce1a59b4efe9'

if platform == "win32":
	chrome_driver_path = "chromedriver.exe"
elif platform == "darwin":
	chrome_driver_path = "./chromedriver"

debugger_address = hma.start(profile_id)
print(debugger_address)
chrome_options = Options()
chrome_options.add_experimental_option("debuggerAddress", debugger_address)
driver = webdriver.Chrome(executable_path=chrome_driver_path, options=chrome_options)
driver.get("http://hidemyacc.com")
time.sleep(3)
hma.stop(profile_id)