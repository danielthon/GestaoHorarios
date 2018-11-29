using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BLL.Entidades;
using BLL.Estruturas;
using DAL.MySQL;

namespace UTL.TestesIntegracao
{
    [TestClass]
    public class TestEntidades
    {
        static Administrador adm;
        static Professor prof;
        static Disciplina discip;
        static Alocacao aloc;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            string msgErro;
            Manager.AbrirConexao(out msgErro);

            // Salvar, Alterar e Remover Administrador
            adm = new Administrador("AdministradorTeste", "1234");

            // Salvar, Alterar e Remover Professor
            prof = new Professor("ProfessorTester", "1234");

            // Salvar, Alterar e Remover Disciplina
            discip = new Disciplina("DisciplinaTester", 0, 0);

            // Salvar, Alterar e Remover Alocação
            Disciplina discipAloc = new Disciplina("DisciplinaTeste", 0, 0);
            Horario horAloc = new Horario(DiaSemana.Segunda, Hora._19h00);

            aloc = new Alocacao(discipAloc, horAloc);

            testContext.WriteLine(msgErro);

            // método executado automaticamente antes de iniciar os testes dessa classe

            // suba o banco com o ambiente preparado e defina a conexão aqui
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // método executado automaticamente após finalizar todos os testes dessa classe

            // feche a conexão e drop o banco aqui
        }

        /// <summary>
        /// Tentar salvar um administrador na tabela "Administrador".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar salvar um administrador na tabela \"Administrador\".")]
        public void TI_AD_001()
        {
            adm.SalvarNoBanco();

            Assert.AreEqual(true, adm.ExisteNoBanco(), "O usuário não foi inserido corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar um administrador na tabela "Administrador".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar um administrador na tabela \"Administrador\".")]
        public void TI_AD_002()
        {
            adm.SalvarNoBanco();

            Assert.AreEqual(true, adm.ExisteNoBanco(), "O usuário não foi alterado corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar um administrador na tabela "Administrador".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar remover um administrador na tabela \"Administrador\".")]
        public void TI_AD_003()
        {
            adm.RemoverDoBanco();

            Assert.AreEqual(false, adm.ExisteNoBanco(), "O usuário não foi removido corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar um professor na tabela "Professor".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar salvar um professor na tabela \"Professor\".")]
        public void TI_PR_001()
        {
            prof.SalvarNoBanco();

            Assert.AreEqual(true, prof.ExisteNoBanco(), "O usuário não foi inserido corretamente no banco");
        }

        /// <summary>
        /// Tentar alterar um professor na tabela "Professor".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar um professor na tabela \"Professor\".")]
        public void TI_PR_002()
        {
            prof.SalvarNoBanco();

            Assert.AreEqual(true, prof.ExisteNoBanco(), "O usuário não foi alterado corretamente no banco");
        }

        /// <summary>
        /// Tentar remover um professor na tabela "Professor".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar remover um professor na tabela \"Professor\".")]
        public void TI_PR_003()
        {
            prof.RemoverDoBanco();

            Assert.AreEqual(false, prof.ExisteNoBanco(), "O usuário não foi removido corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar uma disciplina na tabela "Disciplina".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar salvar uma disciplina na tabela \"Disciplina\".")]
        public void TI_DI_001()
        {
            discip.SalvarNoBanco();

            Assert.AreEqual(true, discip.ExisteNoBanco(), "O usuário não foi inserido corretamente no banco");
        }

        /// <summary>
        /// Tentar alterar uma disciplina na tabela "Disciplina".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar uma disciplina na tabela \"Disciplina\".")]
        public void TI_DI_002()
        {
            discip.SalvarNoBanco();

            Assert.AreEqual(true, discip.ExisteNoBanco(), "A disciplina não foi inserida corretamente no banco");
        }

        /// <summary>
        /// Tentar remover uma disciplina na tabela "Disciplina".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar remover uma disciplina na tabela \"Disciplina\".")]
        public void TI_DI_003()
        {
            discip.RemoverDoBanco();

            Assert.AreEqual(false, discip.ExisteNoBanco(), "A disciplina não foi removida corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar uma alocação na tabela "Alocação".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar salvar uma alocação na tabela \"Alocacao\".")]
        public void TI_AL_001()
        {
            aloc.SalvarNoBanco();

            Assert.AreEqual(true, aloc.ExisteNoBanco(), "A alocação não foi inserida corretamente no banco");
        }

        /// <summary>
        /// Tentar alterar uma alocação na tabela "Alocação".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar uma alocação na tabela \"Alocacao\".")]
        public void TI_AL_002()
        {
            Disciplina discip = new Disciplina("DisciplinaTeste", 0, 0);
            Horario hor = new Horario(DiaSemana.Segunda, Hora._19h00);

            Alocacao aloc = new Alocacao(discip, hor);

            aloc.SalvarNoBanco();

            Assert.AreEqual(true, aloc.ExisteNoBanco(), "A alocação não foi alterada corretamente no banco");
        }

        /// <summary>
        /// Tentar remover uma alocação na tabela "Alocação".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar remover uma alocação na tabela \"Alocacao\".")]
        public void TI_AL_003()
        {
            Disciplina discip = new Disciplina("DisciplinaTeste", 0, 0);
            Horario hor = new Horario(DiaSemana.Segunda, Hora._19h00);

            Alocacao aloc = new Alocacao(discip, hor);

            aloc.RemoverDoBanco();

            Assert.AreEqual(false, aloc.ExisteNoBanco(), "A alocação não foi removida corretamente no banco");
        }
    }
}
