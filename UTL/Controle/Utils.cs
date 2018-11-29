using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

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
    }
}
