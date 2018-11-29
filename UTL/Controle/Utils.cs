using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTL.Controle
{
    class Utils
    {
        public static IWebElement Encontrar(By by)
        {
            return Controlador.Driver.FindElement(by);
        }

        public static void Clicar(By by)
        {
            Controlador.Driver.FindElement(by).Click();
        }

        public static void Digitar(By by, string texto)
        {
            Controlador.Driver.FindElement(by).SendKeys(texto);
        }

        public static IWebElement Esperar(By by)
        {
            var wait = new WebDriverWait(Controlador.Driver, TimeSpan.FromSeconds(10));
            return wait.Until<IWebElement>(f => f.FindElement(by));
        }

        public static void VerificarCampoTexto(By by, string esperada)
        {
            Assert.Equals(Controlador.Driver.FindElement(by).Text, esperada);
        }

        public static void VerificarMessageBox(string msg)
        {
            //var elements = Controlador.Driver.FindElement(By.Id("TMessageForm"))./*FindElement(By.XPath(".."))*/.FindElements(By.XPath("*"));

            var elements = Controlador.Driver.SwitchTo().ActiveElement().FindElement(By.XPath("..")).FindElements(By.XPath("*"));
            
            Assert.Equals(elements[elements.Count - 2].GetAttribute("Name"), msg);

            Utils.Clicar(By.Name("OK"));
        }
    }
}
