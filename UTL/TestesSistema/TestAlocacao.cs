using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTL.TestesSistema
{
    class TestAlocacao
    {
        /// <summary>
        /// Alocar
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Alocar")]
        private void TS_AL_001()
        {

        }

        /// <summary>
        /// Alterar alocação
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Alterar alocação")]
        private void TS_AL_002()
        {

        }

        /// <summary>
        /// Tentar alterar alocação para disciplina de outro período (nao encontrar)
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar alocação para disciplina de outro período (nao encontrar)")]
        private void TS_AL_003()
        {

        }

        /// <summary>
        /// Tentar alterar alocação para disciplina já alocada (não encontrar)
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alterar alocação para disciplina já alocada (não encontrar)")]
        private void TS_AL_004()
        {

        }

        /// <summary>
        /// Remover alocação
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Remover alocação")]
        private void TS_AL_005()
        {

        }

        /// <summary>
        /// Tentar alocar um professor no mesmo horário em períodos diferentes (alerta de erro)
        /// </summary>
        [TestMethod]
        [TestProperty("Description", "Tentar alocar um professor no mesmo horário em períodos diferentes (alerta de erro)")]
        private void TS_AL_006()
        {

        }
    }
}
