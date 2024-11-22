using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace SeleniumCsharp
{
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;
        string url = "https://app.cloudqa.io/home/AutomationPracticeForm";

        [OneTimeSetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]

        public void verifyMultipleFeilds()
        {
            driver.Navigate().GoToUrl(url);

            TestFieldsInNormalForm(); // Test normal form and also checks for first shadow dom form
            TestFieldsInIframeWithoutId(); // Test iframe form without id
            TestFieldsInNestedIframe(); // Test the nested iframe
            TestFieldsInIframeWithId(); // Test iframe form with id
            TestFieldsInNestedShadowDOM(); // Test all the nested shadow form
            TestFieldsInNestedShadowDOMWith3(); // Test all the nested shadow form for level 3
            TestFieldsInNestedShadowDOMWith4(); // Test all the nested shadow form for level 4
            TestFieldsInNestedShadowDOMWith5(); // Test all the nested shadow form for level 5
        }


        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();

        }

        void TestFieldsInNormalForm()
        {
            Console.WriteLine("Testing fields in normal form...");
            TestFields(() => driver.FindElements(By.XPath("//input")));
        }

        void TestFieldsInIframeWithoutId()
        {
            Console.WriteLine("Testing fields in iframe without ID...");
            IWebElement iframe = wait.Until(driver => driver.FindElement(By.XPath("//iframe")));
            driver.SwitchTo().Frame(iframe);
            TestFields(() => driver.FindElements(By.XPath("//input")));
            driver.SwitchTo().DefaultContent();
        }

        void TestFieldsInNestedIframe()
        {
            Console.WriteLine("Testing fields in nested iframe...");
            IWebElement outerIframe = wait.Until(driver => driver.FindElement(By.XPath("//iframe[@src='/Home/IFrame']")));
            driver.SwitchTo().Frame(outerIframe);

            // Find the nested frame in the iframe
            IWebElement nestedIframe = wait.Until(driver => driver.FindElement(By.XPath("//iframe[@src='/Home/NestedIFrame']")));
            driver.SwitchTo().Frame(nestedIframe);
            TestFields(() => driver.FindElements(By.XPath("//input"))); // test the feilds inside it

            // Find the inner nested frame in the nested frame
            IWebElement innerNestedIframe = wait.Until(driver => driver.FindElement(By.XPath("//iframe[@src='/Home/InnerNestedIFrame']")));
            driver.SwitchTo().Frame(innerNestedIframe);
            TestFields(() => driver.FindElements(By.XPath("//input"))); // the the feilds inside it

            driver.SwitchTo().DefaultContent();
        }

        void TestFieldsInIframeWithId()
        {
            Console.WriteLine("Testing fields in iframe with ID...");
            driver.SwitchTo().Frame("iframeId");
            TestFields(() => driver.FindElements(By.XPath("//input")));
            driver.SwitchTo().DefaultContent();
        }

        void TestFieldsInNestedShadowDOM()
        {
            Console.WriteLine("Testing fields in nested shadow DOM...");

            // Locate the shadow host element
            IWebElement shadowHost = wait.Until(driver => driver.FindElement(By.CssSelector("nestedshadow-form")));

            // Access the shadow root one
            ISearchContext shadowRoot = shadowHost.GetShadowRoot();

            TestFields(() => shadowRoot.FindElements(By.CssSelector("input")));
        }

        void TestFieldsInNestedShadowDOMWith3()
        {
            Console.WriteLine("Testing fields in nested shadow DOM Level 3...");

            // Locate the shadow host element
            IWebElement shadowHost = wait.Until(driver => driver.FindElement(By.CssSelector("nestedshadow-form3")));

            // Access the shadow root
            ISearchContext shadowRoot = shadowHost.GetShadowRoot();

            // Access the shadow host element inside the shadow root
            IWebElement shadowHost1 = shadowRoot.FindElement(By.CssSelector("nestedshadow-form"));
            
            // Access the shadow root one
            ISearchContext shadowRoot1 = shadowHost1.GetShadowRoot();

            TestFields(() => shadowRoot1.FindElements(By.CssSelector("input")));
        }

        void TestFieldsInNestedShadowDOMWith4()
        {
            Console.WriteLine("Testing fields in nested shadow DOM Level 4...");

            // Locate the shadow host element
            IWebElement shadowHost = wait.Until(driver => driver.FindElement(By.CssSelector("nestedshadow-form4")));

            // Access the shadow root
            ISearchContext shadowRoot = shadowHost.GetShadowRoot();

            // Access the shadow host element inside the shadow root
            IWebElement shadowHost1 = shadowRoot.FindElement(By.CssSelector("nestedshadow-form3"));

            // Access the shadow root one
            ISearchContext shadowRoot1 = shadowHost1.GetShadowRoot();

            // Access the shadow host element inside the shadow root one
            IWebElement shadowHost2 = shadowRoot1.FindElement(By.CssSelector("nestedshadow-form"));

            // Access the shadow root two
            ISearchContext shadowRoot2 = shadowHost2.GetShadowRoot();

            TestFields(() => shadowRoot2.FindElements(By.CssSelector("input")));
        }

        void TestFieldsInNestedShadowDOMWith5()
        {
            Console.WriteLine("Testing fields in nested shadow DOM Level 5...");

            // Locate the shadow host element
            IWebElement shadowHost = wait.Until(driver => driver.FindElement(By.CssSelector("nestedshadow-form5")));

            // Access the shadow root
            ISearchContext shadowRoot = shadowHost.GetShadowRoot();

            // Access the shadow host element inside the shadow root
            IWebElement shadowHost1 = shadowRoot.FindElement(By.CssSelector("nestedshadow-form4"));

            // Access the shadow root one
            ISearchContext shadowRoot1 = shadowHost1.GetShadowRoot();

            // Access the shadow host element inside the shadow root one
            IWebElement shadowHost2 = shadowRoot1.FindElement(By.CssSelector("nestedshadow-form3"));

            // Access the shadow root two
            ISearchContext shadowRoot2 = shadowHost2.GetShadowRoot();

            // Access the shadow host element inside the shadow root two
            IWebElement shadowHost3 = shadowRoot2.FindElement(By.CssSelector("nestedshadow-form"));

            // Access the shadow root three
            ISearchContext shadowRoot3 = shadowHost3.GetShadowRoot();

            TestFields(() => shadowRoot3.FindElements(By.CssSelector("input")));
        }


        void TestFields(Func<System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>> getInputElements)
        {
            var inputs = getInputElements();

            foreach (var input in inputs)
            {
                string placeholder = input.GetAttribute("placeholder");
                if (placeholder == "Name")
                {
                    Console.WriteLine("Testing 'Name' input...");
                    input.SendKeys("Test Name");
                    AssertInputValue(input, "Test Name");
                }
                else if (placeholder == "Email")
                {
                    Console.WriteLine("Testing 'Email' input...");
                    input.SendKeys("test@example.com");
                    AssertInputValue(input, "test@example.com");
                }
                else if (placeholder == "Country")
                {
                    Console.WriteLine("Testing 'Country' input...");
                    input.SendKeys("India");
                    AssertInputValue(input, "India");
                }
            }
        }

        void AssertInputValue(IWebElement input, string expectedValue)
        {
            string actualValue = input.GetAttribute("value");
            ClassicAssert.AreEqual(expectedValue, actualValue, $"Assertion failed: Expected '{expectedValue}', but got '{actualValue}'");
            Console.WriteLine($"Input value validated successfully: {actualValue}");
        }
    }
}