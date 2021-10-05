const puppeteer = require('puppeteer-core');
const Hidemyacc = require('./hidemyacc');

const delay = (ms) => new Promise((resolve) => setTimeout(resolve, ms));

(async () => {
  try {
    const hidemyacc = new Hidemyacc();
    const response = await hidemyacc.start('61596b072a151505fe61677c');
    if (response.code == 1) {
      const data = response.data;
      const browser = await puppeteer.connect({
        browserWSEndpoint: data.wsUrl,
        ignoreHTTPSErrors: true,
        args: ['--start-maximized'],
        slowMo: 90,
      });
      const page = await browser.newPage();
      await page._client.send('Emulation.clearDeviceMetricsOverride');
      await page.goto('https://hidemyacc.com');
    }
  } catch (e) {
    console.log(e);
  }
})();
