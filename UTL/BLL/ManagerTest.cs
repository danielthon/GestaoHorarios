using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BLL.Entidades;
using BLL.Estruturas;
using UTL.Excecoes;

namespace UTL.BLL
{
    [TestClass]
    public class ManagerTest
    {
        public ManagerTest()
        {
            string errMsg;
            Manager.AbrirConexao(out errMsg);
            Manager.CarregarGrafoPeloBanco();
        }

        [TestMethod]
        public void AbrirConexao()
        {
            string msgErro;

            Assert.AreEqual(true, Manager.AbrirConexao(out msgErro), msgErro);
        }

        [TestMethod]
        public void TentarAlocar()
        {
            Disciplina d = new Disciplina("Filosofia_1", 0, 0);
            Vertice vd = Manager.GetVerticeNaGrade(d);
            Horario h = new Horario(DiaSemana.Quarta, Hora._20h50);

            Vertice vDisciplina = new Vertice(d);
            Vertice vHorario = new Vertice(h);

            Assert.AreEqual(true, Manager.TentarAlocar(vHorario, vDisciplina), "OPSSS, O método retornou false");
        }

        [TestMethod]
        public void SalvarNoBancoAdministradorException()
        {
            Administrador adm = new Administrador("AdmnidtradorTester", "1234");
            
            try
            {
                adm.SalvarNoBanco();
            } catch(Exception e)
            {
                StringAssert.Contains(e.Message, "não inserido no banco");
                StringAssert.Contains(e.Message, "lógica corrompida");
            }
            Assert.Fail("Nenhuma exceção foi alcançada.");
        }

        [TestMethod]
        public void SalvarNoBancoAlocacaoException()
        {
            Disciplina discip = new Disciplina("DisciplinaTester", 0, 0);
            Horario hor = new Horario(DiaSemana.Segunda, Hora._19h00);

            Alocacao aloc = new Alocacao(discip, hor);

            try
            {
                aloc.SalvarNoBanco();
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "não inserido no banco");
            }
            Assert.Fail("Nenhuma exceção foi alcançada.");
        }

        [TestMethod]
        public void SalvarNoBancoDisciplinaException()
        {
            Disciplina discip = new Disciplina("DisciplinaTester", 0, 0);

            try
            {
                discip.SalvarNoBanco();
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "não inserido no banco");
            }
            Assert.Fail("Nenhuma exceção foi alcançada.");
        }

        [TestMethod]
        public void SalvarNoBancoProfessorException()
        {
            Professor prof = new Professor("ProfessorTester", "1234");

            try
            {
                prof.SalvarNoBanco();
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "não inserido no banco");
            }
            Assert.Fail("Nenhuma exceção foi alcançada.");
        }

        [TestMethod]
        public void SalvarNoBancoAdministrador()
        {
            Administrador adm = new Administrador("AdmnidtradorTester", "1234");
            string msgAcao;

            if (adm.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            } else
            {
                msgAcao = "inserido";
            }

            adm.SalvarNoBanco();

            Assert.AreEqual(true, adm.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        [TestMethod]
        public void SalvarNoBancoAlocacao()
        {
            Disciplina discip = new Disciplina("DisciplinaTester", 0, 0);
            Horario hor = new Horario(DiaSemana.Segunda, Hora._19h00);

            Alocacao aloc = new Alocacao(discip, hor);

            string msgAcao;

            if (aloc.ExisteNoBanco())
            {
                msgAcao = "atualizado";
            }
            else
            {
                msgAcao = "inserido";
            }

            aloc.SalvarNoBanco();

            Assert.AreEqual(true, aloc.ExisteNoBanco(), "O usuário não foi " + msgAcao + " corretamente no banco");
        }

        [TestMethod]
        public void SalvarNoBancoDisciplina()
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

        [TestMethod]
        public void SalvarNoBancoProfessor()
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
    }
}
