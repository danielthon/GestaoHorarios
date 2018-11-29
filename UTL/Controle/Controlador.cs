using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Diagnostics;

namespace UTL.Controle
{
    class Controlador
    {
        private static Process driverExe;
        private static IWebDriver driver;

        public static IWebDriver Driver { get { return driver; } }

        public static void AbrirDriver(string caminhoAplicacao)
        {

            ProcessStartInfo info = new ProcessStartInfo();

            info.UseShellExecute = false; //nao exibe a janela preta
            info.FileName = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\UTL\Controle\Drivers\Winium.Desktop.Driver.exe";
            info.Arguments = "--port 9999";

            //inicia o Winium.WebDriver.exe
            driverExe = Process.Start(info);

            DesiredCapabilities dc = new DesiredCapabilities();
            dc.SetCapability("app", caminhoAplicacao);
            dc.SetCapability("args", "--testing");

            //conecta o Selenium ao Winium.WebDriver.exe pela porta
            driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
        }

        public static void FecharDriver()
        {
            //fechar o driver (conexao selenium)
            try
            {
                driver.Close();
                driver.Dispose();
            }
            catch { }

            //fechar o driver (executavel)
            try
            {
                driverExe.CloseMainWindow();
                driverExe.Close();
            }
            catch { }
        }
    }
}
