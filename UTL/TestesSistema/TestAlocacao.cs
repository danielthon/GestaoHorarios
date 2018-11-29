using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTL.Controle;
using UTL.Controle.Mapping;
using OpenQA.Selenium;
using System.Threading;

namespace UTL.TestesSistema
{
    [TestClass]
    public class TestAlocacao
    {
        [ClassInitialize]
        public static void Init(TestContext tc)
        {
            Controlador.AbrirDriver(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\GestaoHorarios\bin\Release\GestaoHorarios.exe");
            Thread.Sleep(10000);

            Utils.Digitar(By.Id(FLogin.Usuario_Textbox_Id), "automacao");
            Utils.Digitar(By.Id(FLogin.Senha_Textbox_Id), "automacao");

            Utils.Clicar(By.Id(FLogin.Usuario_Textbox_Id));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Controlador.FecharDriver();
        }

        /// <summary>
        /// Alocar
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Alocar")]
        public void TS_AL_001()
        {

        }

        /// <summary>
        /// Alterar alocação
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Alterar alocação")]
        public void TS_AL_002()
        {

        }

        /// <summary>
        /// Tentar alterar alocação para disciplina de outro período (nao encontrar)
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar alocação para disciplina de outro período (nao encontrar)")]
        public void TS_AL_003()
        {

        }

        /// <summary>
        /// Tentar alterar alocação para disciplina já alocada (não encontrar)
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar alocação para disciplina já alocada (não encontrar)")]
        public void TS_AL_004()
        {

        }

        /// <summary>
        /// Remover alocação
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Remover alocação")]
        public void TS_AL_005()
        {

        }

        /// <summary>
        /// Tentar alocar um professor no mesmo horário em períodos diferentes (alerta de erro)
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alocar um professor no mesmo horário em períodos diferentes (alerta de erro)")]
        public void TS_AL_006()
        {

        }
    }
}
