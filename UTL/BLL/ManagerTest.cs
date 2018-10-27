using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using UTL.Excecoes;

namespace UTL.BLL
{
    [TestClass]
    public class ManagerTest
    {
        [TestMethod]
        public void AbrirConexao()
        {
            string msgErro;

            Assert.AreEqual(true, Manager.AbrirConexao(out msgErro), msgErro);
        }
    }
}
