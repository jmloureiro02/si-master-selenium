using NUnit.Framework;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;


namespace SwagLabsTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public static void Main()
        {
            Thread device1 = new Thread(obj => TestMethod());
            Thread device2 = new Thread(obj => TestMethod());
            Thread device3 = new Thread(obj => TestMethod());
            Thread device4 = new Thread(obj => TestMethod());
            Thread device5 = new Thread(obj => TestMethod());

            //Executing methods
            device1.Start();
            device2.Start();
            device3.Start();
            device4.Start();
            device5.Start();

            device1.Join();
            device2.Join();
            device3.Join();
            device4.Join();
            device5.Join();

        }

        public static void TestMethod()
        {
            //Start Stopwatch
            DateTime StartTime = DateTime.Now;

            //Chrome options
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            //Access URL
            IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Url = "https://www.saucedemo.com/";

            //Type username
            IWebElement username = driver.FindElement(By.XPath(".//*[@id='user-name']"));
            username.SendKeys("standard_user");
            //Type password
            IWebElement password = driver.FindElement(By.XPath(".//*[@id='password']"));
            password.SendKeys("secret_sauce");
            //Login
            IWebElement button = driver.FindElement(By.XPath(".//*[@id='login-button']"));
            button.Click();
            //Sort Low-High
            SelectElement sortselect1 = new SelectElement(driver.FindElement(By.XPath(".//*[@class='product_sort_container']")));
            sortselect1.SelectByValue("lohi");
            //Click item 1
            IWebElement item1link = driver.FindElement(By.XPath(".//*[@id='item_2_image_link']"));
            item1link.Click();
            //Add item 1 to cart
            IWebElement addtocart1 = driver.FindElement(By.XPath(".//*[@id='add-to-cart-sauce-labs-onesie']"));
            addtocart1.Click();
            //Click back to products
            IWebElement backtoproducts = driver.FindElement(By.XPath(".//*[@id='back-to-products']"));
            backtoproducts.Click();
            //Sort Low-High
            SelectElement sortselect2 = new SelectElement(driver.FindElement(By.XPath(".//*[@class='product_sort_container']")));
            sortselect2.SelectByValue("lohi");
            //Add item 2 to cart
            IWebElement addtocart2 = driver.FindElement(By.XPath(".//*[@id='add-to-cart-sauce-labs-bike-light']"));
            addtocart2.Click();
            //Open shopping cart
            IWebElement opencart = driver.FindElement(By.XPath(".//*[@id='shopping_cart_container']"));
            opencart.Click();
            //Click checkout Form
            IWebElement checkout = driver.FindElement(By.XPath(".//*[@id='checkout']"));
            checkout.Click();
            //Type first name
            IWebElement firstname = driver.FindElement(By.XPath(".//*[@id='first-name']"));
            firstname.SendKeys("João");
            //Type last name
            IWebElement lastname = driver.FindElement(By.XPath(".//*[@id='last-name']"));
            lastname.SendKeys("Loureiro");
            //Type postal code
            IWebElement postalcode = driver.FindElement(By.XPath(".//*[@id='postal-code']"));
            postalcode.SendKeys("1000-279");
            //Click continue button
            IWebElement continuebtn = driver.FindElement(By.XPath(".//*[@id='continue']"));
            continuebtn.Click();
            //Clik finish button
            IWebElement finishbtn = driver.FindElement(By.XPath(".//*[@id='finish']"));
            finishbtn.Click();

            //Stop Stopwatch
            TimeSpan ts = DateTime.Now.Subtract(StartTime);
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);

            //Print elapsed time to console
            TestContext.WriteLine(elapsedTime, "RunTime");
        }
    }
}
