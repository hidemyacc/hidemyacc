# How to create automation scripts with Javascript code command

Hidemyacc Automation is a time-saving solution that simplifies the execution of repetitive tasks, such as seeding, ordering, listing, warming up accounts, and more. 

You can make the most of its advanced capabilities to create batches of automation scripts effortlessly, just by dragging and dropping predefined commands.

But that's not all. You also have the option to infuse your automation with the power of JavaScript code commands, allowing you to blend the ease of drag-and-drop actions with the flexibility of coding. Wondering how this command works and how it can supercharge your automation tasks? Let's dive in and explore its potential.

## What is a Javascript code command?
JavaScript code empowers you to bring in your own custom code to execute the actions you desire. You can write this code in JSON or Puppeteer.

This command combines the best of both worlds in automation script writing. It offers the convenience of dragging and dropping commands while also allowing you to swiftly code commands to your liking. This flexibility enables you to create multiple scripts that run just the way you want them to.

## How to create automation scripts with Javascript code commands? 
Hidemyacc is here to show you how to create an automation script using JavaScript commands to open any web page and extract its text. After that, the automation script will open a random website.

### Create an automation script
First, you'll need to edit the URL in the **"New tab"** command. The system defaults to Hidemyacc's website, but you can change it to any website you like.

![new-tab-github](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/9c679ae7-108e-406c-b665-12f139a3e5a2)

Next, add a **"Wait"** command. This is a command that pauses before executing the next step. You can customize the waiting time from X to Y seconds or leave it as the default 5 seconds.

![wait-github](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/faa48682-13b9-4c09-8ff2-b1e726f3b753)

After that, drag and drop the **JavaScript command** and click on the three dots to edit the code. You can drag and drop a file containing your code or write your own code in the black area below.

![javascript-code-1-github](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/d425670d-5428-4874-9251-59d18dd3185e)

Hidemyacc provides an example of code that changes the background color of a web page and extracts some text. Take a look at the code snippet below:
```c
document.querySelector('.homepage').style.background = "#39739d";
return document.querySelector('h2').textContent;
```

**Note:** You'll need to click "Run in page" to execute the code in your open browser.

Next, add another **"Wait"** command and drag and drop **a second JavaScript command.** This code will open one of three random websites.

![javascript-code-2-github](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/a3f60298-6a17-45b5-b09b-87d759855e25)

Here's an example of that code. Add a **"Wait"** command to allow the page to complete its actions before closing the automation script.
```c
const urls  = ['https://www.etsy.com/', 'https://www.google.com/', 'https://www.amazon.com/'];
const index = parseInt(Math.random() * urls.length);
const url = urls[index];
await page.goto(url);
```

Once you're done, click on the three dashes to arrange the commands. Please note that you only need to arrange them once.

![arrange-github](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/509c4b87-d46a-4e4c-b0ec-e34c1a3c7d30)

### Run test scripts
After successfully creating the automation script, you click "Run test" to test your script. A new Hidemyacc profile will be created to run a test of this automation script.

![run-test-github](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/b70442d3-6596-4047-99ea-ebbf595ef45c)

After running the test, click **"Debug"** Hidemyacc will provide the extracted text as a string.

![debug-github](https://github.com/meimeiblue01/meimeiblue01/assets/124659659/a245cd02-9029-48b3-abbc-4216daba1ab2)

And there you have it! Hidemyacc has guided you through creating an automation script using JavaScript commands.

## Conclusion
The JavaScript code command will provide you with more options when creating automation scripts on Hidemyacc.

👉 For more guidance on using other commands, check out the official Hidemyacc Automation tutorial playlist on our YouTube channel: [Hidemyacc Automation Playlist](https://www.youtube.com/watch?v=7ZeOfx70ino&list=PLBBtW4MP4Bf66mPrzu4TVyBiz0v2eygeG)

👉 For more information, visit our website at [Hidemyacc - The best anti-detect browser](https://hidemyacc.com/)




