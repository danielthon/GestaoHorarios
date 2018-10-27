using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTL.Excecoes
{
    class ErroConexaoException : Exception
    {
        public ErroConexaoException() : base("Não foi possível realizar a conexão.") { }
        public ErroConexaoException(string msg) : base(msg) { }
    }
}
