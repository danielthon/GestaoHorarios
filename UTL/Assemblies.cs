using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using DAL;
using UTL.Controle;

namespace UTL
{
    [TestClass]
    public class Assemblies
    {
        [AssemblyInitialize]
        public static void Inicializar(TestContext teste)
        {
            string msgErro;
            Manager.AbrirConexao(out msgErro);
        }

        [AssemblyCleanup]
        public static void Finalizar()
        {
            
        }
    }
}
