﻿using System;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SetLocale.Client.Web.Test.Selenium
{
    [TestFixture]
    public class NewAppTests
    {
        FirefoxDriver _browser;
        private const string BaseUrl = "http://localhost:3881/";

        [TestFixtureSetUp]
        public void Setup()
        {
            _browser = new FirefoxDriver();
        }

        [Test]
        public void should_new_app()
        {
            _browser.Navigate().GoToUrl(string.Format("{0}/user/logout", BaseUrl));
            _browser.Navigate().GoToUrl(string.Format("{0}/user/login", BaseUrl));

            _browser.FindElementById("email").SendKeys("mehmet.sabancioglu@gmail.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();

            _browser.Navigate().GoToUrl(string.Format("{0}/app/new", BaseUrl));

            _browser.FindElementById("name").SendKeys(Guid.NewGuid().ToString().Replace("-", ""));
            _browser.FindElementById("url").SendKeys(Guid.NewGuid().ToString().Replace("-", ""));
            _browser.FindElementById("description").SendKeys(Guid.NewGuid().ToString().Replace("-", ""));
            _browser.FindElementById("frm").Submit();

            _browser.Close();
        }

    }
}