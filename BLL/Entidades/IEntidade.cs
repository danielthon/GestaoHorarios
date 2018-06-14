using System.Data;
using System.Collections.Generic;

namespace BLL.Entidades
{
    public interface IEntidade
    {
        /// <summary>
        /// Insere ou atualiza o registro no banco da entidade respectiva a este objeto.
        /// </summary>
        void SalvarNoBanco();
        /// <summary>
        /// Exclui no banco o registro da entidade respectiva a este objeto.
        /// </summary>
        void RemoverDoBanco();
        /// <summary>
        /// <para>Tenta encontrar um registro no banco que contenha os valores chaves da entidade respectiva a este objeto.</para>
        /// <para>Se conseguir, seta o id do objeto com o registro encontrado.</para>
        /// </summary>
        /// <returns>Retorna se o registro foi encontrado ou não.</returns>
        bool ExisteNoBanco();
        /// <summary>
        /// <para>Tenta encontrar um registro no banco que contenha o id informado por parâmetro.</para>
        /// <para>Se conseguir, carrega todas as informações do objeto.</para>
        /// </summary>
        /// <returns>Retorna se o registro foi encontrado ou não.</returns>
        bool CarregaAtributos(int id);
        /// <summary>
        /// (static) Retorna todos os registros da tabela respectiva.
        /// </summary>
        /// <returns></returns>
        DataTable TodosT();
        /// <summary>
        /// (static) Retorna todos os registros da tabela respectiva no formato do objeto.
        /// </summary>
        /// <returns></returns>
        List<IEntidade> Todos();
    }
}
