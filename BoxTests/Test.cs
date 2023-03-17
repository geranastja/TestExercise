using NUnit.Framework;
using OpenQA.Selenium;


namespace BoxTests
{
    [TestFixture]

    public partial class Test : Base
    {
        [Test]

        public void Test1()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("https://piter-online.net/");
            driver.FindElement(By.XPath("(.//a[contains(text(), 'Поиск по адресу')])[1]")).Click();
            js.ExecuteScript("arguments[0].click()", 
                driver.FindElement(By.XPath("(.//span[contains(text(), 'Введите улицу')])[1]")));
            driver.FindElement(By.XPath("(.//span[contains(text(), 'Введите улицу')])[1]//following::input[1]")).
                SendKeys("Тестовая линия");
            WaitUntilVisible(By.XPath("(.//input[@value='Тестовая линия'])[1]"));
            driver.FindElement(By.XPath("(.//span[contains(text(), 'Введите улицу')])[1]//following::input[1]")).
               SendKeys(Keys.Enter);
            WaitUntilVisible(By.XPath("(.//span[contains(text(), 'Дом')])[1]//following::input[1]"));
            driver.FindElement(By.XPath("(.//span[contains(text(), 'Дом')])[1]//following::input[1]")).Click();
            driver.FindElement(By.XPath("(.//span[contains(text(), 'Дом')])[1]//following::input[1]")).SendKeys("1");
            driver.FindElement(By.XPath("(.//span[contains(text(), 'Тип подключения')])[1]")).Click();
            WaitUntilVisibleAndClick(By.XPath("(.//li[contains(text(), 'В квартиру')])[2]"));
            driver.FindElement(By.XPath("(.//div[contains(text(), 'показать тарифы')])[1]")).Click();
            WaitUntilVisible(By.XPath(".//div[contains(text(), 'Отлично! Количество подобранных для вас тарифов')]"));
            driver.FindElement(By.XPath(".//span[contains(text(), 'Номер мобильного телефона')]//following::input[1]")).
                SendKeys("1111111111");
            driver.FindElement(By.XPath(".//div[contains(text(), 'Показать результаты')]")).Click();
            WaitUntilVisible(By.XPath(".//div[contains(text(), 'Спасибо за заявку')]"));


        }



    }
}