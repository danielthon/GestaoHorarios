using System;
using System.Data;
using GestaoHorarios.classes;
using DAL;
using DAL.MySQL;

namespace DAL.Tabelas
{
    public class TAdministrador : Tabela
    {
        public TAdministrador()
        {
            this.tabela = "administrador";

            this.campos = new string[]
            {
                "Id_Usuario"
            };
        }

        //public static void Inserir(Administrador admin)
        //{
        //    string[] values =
        //    {
        //        admin.ID_Usuario
        //    };

        //    TUsuario.Inserir(admin);
        //    ExecutorComandos.Insert(tabela, values);

        //    //usuario.ID = ?
        //}

        //public static DataTable Visualizar()
        //{
        //    return ExecutorComandos.Select(tabela);
        //}

        //public static DataTable Visualizar(string id)
        //{
        //    return ExecutorComandos.Select(tabela, id);
        //}

        //public static string Visualizar(string campo, string id)
        //{
        //    return ExecutorComandos.Select(tabela, campo, id);
        //}

        //public static void Alterar(Usuario usuario)
        //{
        //    //verificar se o Id_Usuario alterou
        //}

        //public static void Excluir(Administrador admin)
        //{
        //    ExecutorComandos.Delete(tabela, admin.ID);

        //    TUsuario.Excluir(admin);

        //    admin = null;
        //}
    }
}
