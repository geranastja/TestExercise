using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Text;
using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Remote;


namespace BoxTests
{
    [TestFixture]

    public class Base
    {
       
        protected IWebDriver driver;
        protected WebDriverWait iWait;
     

       


    


        [SetUp]
        protected void TestSetup()
        {
            try
            {
                var options = new ChromeOptions();
                var service = ChromeDriverService.CreateDefaultService();
                driver = new ChromeDriver(service, options,
                    TimeSpan.FromSeconds(80));

                iWait = new WebDriverWait(driver, TimeSpan.FromSeconds(80));

            }
            catch
            {

            }
        }

        [TearDown]
        protected void driverQuit()
        {
          

            driver?.Quit();
            driver?.Dispose();
        }
        protected bool IsElementPresent(By Element)
        {
            try
            {


                driver.FindElement(Element);
                return true;


            }
            catch (NoSuchElementException)
            {
                return false;

            }
        }

       
        protected void WaitUntilVisible(By element)
        {
            iWait.Until(driver =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(element);
                    if (elementToBeDisplayed.Displayed)
                    {
                        return elementToBeDisplayed;
                    }
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        protected void WaitUntilVisibleAndClick(By element)
        {
            iWait.Until(driver =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(element);
                    if (elementToBeDisplayed.Displayed)
                    {
                        return elementToBeDisplayed;
                    }
                    return null;

                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            });
            driver.FindElement(element).Click();
        }

    
        public void WaitUntilInVisible(By element)
        {
            iWait.Until(driver =>
            {
                try
                {


                    if (IsElementPresent(element) == false)
                    {
                        // Console.WriteLine("элемент не существует");
                        return true;
                    }
                    else
                    {
                        //  Console.WriteLine("элемент существует");
                        if (IsElementVisible(element) == false)
                        {
                            //  Console.WriteLine("элемент не видим");
                            return true;
                        }
                        return false;
                    }


                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        private bool IsElementVisible(By Element)
        {

            if (driver.FindElement(Element).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

      
   
        }
    }
