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

            //Utils.Esperar(By.Id(FLogin.Usuario_Textbox_Id));

            Utils.Digitar(By.Id(FLogin.Usuario_Textbox_Id), "automacao");
            Utils.Digitar(By.Id(FLogin.Senha_Textbox_Id), "automacao");

            Utils.Clicar(By.Id(FLogin.Entrar_Botao_Id));
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
            try
            {
                Utils.Clicar(By.Name(FHome.Menu_Manutencao_Name));
                Utils.Clicar(By.Name(FHome.MenuItem_AlocacaoHorarios_Name));

                Utils.Clicar(By.Id(FManutencaoHorarios.ComboBox_Periodo_Id));
                Utils.Clicar(By.Name("1"));

                Utils.Clicar(By.Id(FManutencaoHorarios.Label_Terca1_Id));
                Utils.Clicar(By.Id(FManutencaoHorarios.ComboBox_Disciplina_Id));
                Utils.Clicar(By.Name("ATP"));

                Utils.Clicar(By.Id(FManutencaoHorarios.Botao_Gravar_Id));
                Utils.Clicar(By.Name("Sim"));

                // VERIFICAÇÃO

                Utils.VerificarMessageBox("Alocação gravada!");

                Utils.VerificarCampoTexto(By.Id(FManutencaoHorarios.Label_Terca1_Id), "ATP");
            }
            catch
            {
                Cleanup();
            }
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
