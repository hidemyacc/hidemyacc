# HIDEMYACC AUTOMATION - GUIDE TO USE (part 1) 
## What is Hidemyacc Automation?
Hidemyacc Automation is a new feature in Hidemyacc 3.0 that helps you save time, effort, and money on repetitive tasks such as Cookie Bot, creating accounts, web surfing, and more. 

You only need to drag and drop commands; no programming skills are required. Hidemyacc will automatically run scripts on selected profiles and perform repetitive tasks according to your requirements.

## Hidemyacc Automation Using Guide - Drag-and-Drop Commands
To use the Automation feature effectively, you should be able to familiarize yourself with these commands. Here is a quick explanation of each command.
### New tab
Enter the Website URL you want the Script to open. Click on the "three dot" icon to edit the command. 

![new-tab-1](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/9f735f4f-1ed2-4b81-a3cd-bbabcf8cbd4a)

### Click element
Use this command to make your profile click on a specific selector. You need to paste the selector you want to click on. You can use either a CSS Selector or an Xpath to obtain the selector.

![click-element-1](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/4187388a-1447-4193-9d00-5fa0906f06d1)

To get the selector, follow these steps:
- Access the website where you want to get the selector and right-click, then select "Inspect."

![inspect](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/86308979-3506-413c-835a-a661a387babd)
- Choose the element you want to click on.
- Copy the selector or Xpath (depending on your selector preference).

![lấy selector](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/b7750e39-aca1-460f-a924-11f7177dace0)
- Additionally, you can customize some parameters:
  - Click rate: The success rate of clicking on the selector.
  -  Random click: Randomly click on the selector.
  -  Wait navigation: Wait for the webpage to finish loading.

### Type
Simulate the behavior of typing text into the selector you choose. You need to **paste the selector** you want to enter the text in and enter the text you want. Typing speed will be **randomized between 100ms and 300ms**.

![type](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/cd327dc0-28c1-4fd7-b423-0422ee0e9d25)
- You can input text in the following ways:
- Type: Manually input text.
- Choose from file: Only upload .txt files. You can choose to select text randomly by lines or from top to bottom (Top-down).

![text-choose from file](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/b06cdce5-3085-4b7f-aed3-4adc6720fa66)
- You can also choose to:
  - Random Google keywords: Input random Google keywords from the server.
  - Random Amazon keywords: Input random keywords from the Amazon website.
  - Random Etsy keywords: Input random keywords from the Etsy website.
  - Random eBay keywords: Input random keywords from the eBay website.
  - Random line of text: Randomly select text by lines.

![texxt-gooogle](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/a7db7309-cf7c-4957-ba79-338b5c7b1340)

### Wait
Your profile will **wait** for the specific seconds you chose before continuing to the following action.

![wait](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/2603b68e-4400-4464-a72f-352a313a0d49)

### Wait navigation
Wait for the page to load after navigation

![wait navigation](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/6aec1a8f-5e16-4a05-9b08-150c89533217)

### Go back
This command helps you **return** to the previous page.

![go back](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/35e3b11f-5161-4de9-bb6d-7c14a7e886ad)

### Go forward
Go forward to the next page of the tab.

![go forward](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/048bbddf-9212-458a-8ad0-4cf3e5fe4e68)

### SwipeUp
**Scroll up** the web page in vertical with a specified number of pixels. You can randomize the pixel value and the number of scrolls or choose fixed parameters:
- 500 pixels
- Number scroll: 1 (scroll 500 pixels once)
- Break Time (s): 1 (number of seconds to pause between each scroll).

![swipe up-random scroll](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/d313d5b4-64fa-4b60-8b15-e1709c8d78a8)

![up-random](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/fc1ae6d1-ab50-4a51-9a95-410bb5655032)

### SwipeDown
**Scroll down** the web page in vertical with a specified number of pixels. You can randomize the pixel value and the number of scrolls or choose fixed parameters:
- 500 pixels
- Number scroll: 1 (scroll 500 pixels once)
- Break Time (s): 1 (number of seconds to pause between each scroll).

![random-down](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/7140e142-66b3-4559-9f71-fb60444a7c8e)

![fix-down](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/20b54cf1-d0d4-4e55-87e0-6d0f2bc483e9)

### Close tab
Close the currently open tab.

![close tab](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/30a553db-2e3d-4b65-b1a2-3b104e3b7e0d)

### Reload tab
Refresh the currently open webpage.

![reload](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/34d7f4e6-a95e-4db0-8b19-16f45a43f372)

### JavaScript code
You can either upload a JavaScript file or write your own code.
- Run in page: Execute commands that can be used in the web page's DevTools.

![java](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/452e3e12-ec23-446a-a25b-b56962813752)

### Keypress
Simulate keyboard keypress actions. Supported keys include: Enter, Shift, Control, Alt, Meta, PageUp, PageDown, ArrowLeft, ArrowUp, Escape, Delete, Home, End, Space, and CapsLock. You can also add your desired keys.

![keypress](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/14f55122-0920-4c7c-b441-a5402f56f500)

### Take screenshot
You use this command to take a screenshot of the current active tab. You can choose to take a screenshot of the current display (Page), capture the entire web page (Full page), or capture any element (An element).

![take screenshot-1](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/632fe8af-473a-4f3a-9928-be85a0300182)

If you don't name the file, the system will randomly generate a name for you. As for the file location, it will be set as the default to save in 'Downloads,' or you can choose a different desired location. 

![take screenshot-2](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/fa8f1286-f7ba-41fa-952c-3e4775e0e8cc)

👉 Explore our tutorial videos for a comprehensive guide: [Hidemyacc Automation Playlist](https://www.youtube.com/watch?v=7ZeOfx70ino&list=PLBBtW4MP4Bf66mPrzu4TVyBiz0v2eygeG)

👉 For more information please visit our website at: [Hidemyacc - The best anti-detect browser](https://hidemyacc.com/)
