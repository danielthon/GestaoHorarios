using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BLL.Entidades;
using BLL.Estruturas;

namespace UTL.TestesUnitarios
{
    [TestClass]
    public class TestConexao
    {
        [TestMethod]
        public void AbrirConexao()
        {
            string msgErro;

            Assert.AreEqual(true, Manager.AbrirConexao(out msgErro), msgErro);
        }
    }
}
