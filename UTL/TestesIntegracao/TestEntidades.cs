using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BLL.Entidades;
using BLL.Estruturas;

namespace UTL.TestesIntegracao
{
    [TestClass]
    public class TestEntidades
    {

        [ClassInitialize]
        public void ClassInit()
        {
            // método executado automaticamente antes de iniciar os testes dessa classe

            // suba o banco com o ambiente preparado e defina a conexão aqui
        }

        [ClassCleanup]
        public void ClassCleanup()
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
            Administrador adm = new Administrador("AdministradorTeste", "1234");
            string msgAcao;

            if (adm.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            adm.SalvarNoBanco();

            Assert.AreEqual(true, adm.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar um administrador na tabela "Administrador".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar um administrador na tabela \"Administrador\".")]
        public void TI_AD_002()
        {
            Administrador adm = new Administrador("AdministradorTeste", "1234");
            string msgAcao;

            if (adm.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            adm.SalvarNoBanco();

            Assert.AreEqual(true, adm.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar um administrador na tabela "Administrador".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar remover um administrador na tabela \"Administrador\".")]
        public void TI_AD_003()
        {
            Administrador adm = new Administrador("AdministradorTeste", "1234");
            string msgAcao;

            if (adm.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            adm.SalvarNoBanco();

            Assert.AreEqual(true, adm.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar um professor na tabela "Professor".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar salvar um professor na tabela \"Professor\".")]
        public void TI_PR_001()
        {
            Professor prof = new Professor("ProfessorTester", "1234");

            string msgAcao;

            if (prof.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            prof.SalvarNoBanco();

            Assert.AreEqual(true, prof.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        /// <summary>
        /// Tentar alterar um professor na tabela "Professor".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar um professor na tabela \"Professor\".")]
        public void TI_PR_002()
        {
            Professor prof = new Professor("ProfessorTester", "1234");

            string msgAcao;

            if (prof.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            prof.SalvarNoBanco();

            Assert.AreEqual(true, prof.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        /// <summary>
        /// Tentar remover um professor na tabela "Professor".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar remover um professor na tabela \"Professor\".")]
        public void TI_PR_003()
        {
            Professor prof = new Professor("ProfessorTester", "1234");

            string msgAcao;

            if (prof.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            prof.SalvarNoBanco();

            Assert.AreEqual(true, prof.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar uma disciplina na tabela "Disciplina".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar salvar uma disciplina na tabela \"Disciplina\".")]
        public void TI_DI_001()
        {
            Disciplina discip = new Disciplina("DisciplinaTester", 0, 0);

            string msgAcao;

            if (discip.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            discip.SalvarNoBanco();

            Assert.AreEqual(true, discip.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        /// <summary>
        /// Tentar alterar uma disciplina na tabela "Disciplina".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar uma disciplina na tabela \"Disciplina\".")]
        public void TI_DI_002()
        {
            Disciplina discip = new Disciplina("DisciplinaTester", 0, 0);

            string msgAcao;

            if (discip.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            discip.SalvarNoBanco();

            Assert.AreEqual(true, discip.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        /// <summary>
        /// Tentar remover uma disciplina na tabela "Disciplina".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar remover uma disciplina na tabela \"Disciplina\".")]
        public void TI_DI_003()
        {
            Disciplina discip = new Disciplina("DisciplinaTester", 0, 0);

            string msgAcao;

            if (discip.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            discip.SalvarNoBanco();

            Assert.AreEqual(true, discip.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        /// <summary>
        /// Tentar salvar uma alocação na tabela "Alocação".
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar salvar uma alocação na tabela \"Alocacao\".")]
        public void TI_AL_001()
        {
            Disciplina discip = new Disciplina("DisciplinaTeste", 0, 0);
            Horario hor = new Horario(DiaSemana.Segunda, Hora._19h00);

            Alocacao aloc = new Alocacao(discip, hor);

            string msgAcao;

            if (aloc.ExisteNoBanco())
            {
                msgAcao = "atualizada";
            }
            else
            {
                msgAcao = "inserida";
            }

            aloc.SalvarNoBanco();

            Assert.AreEqual(true, aloc.ExisteNoBanco(), "A alocação não foi " + msgAcao + " corretamente no banco");
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

            string msgAcao;

            if (aloc.ExisteNoBanco())
            {
                msgAcao = "atualizada";
            }
            else
            {
                msgAcao = "inserida";
            }

            aloc.SalvarNoBanco();

            Assert.AreEqual(true, aloc.ExisteNoBanco(), "A alocação não foi " + msgAcao + " corretamente no banco");
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

            string msgAcao;

            if (aloc.ExisteNoBanco())
            {
                msgAcao = "atualizada";
            }
            else
            {
                msgAcao = "inserida";
            }

            aloc.SalvarNoBanco();

            Assert.AreEqual(true, aloc.ExisteNoBanco(), "A alocação não foi " + msgAcao + " corretamente no banco");
        }
    }
}
