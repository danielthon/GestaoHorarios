using System;
using System.Data;

namespace GestaoHorarios.classes.DAL
{
    static class TableAdministrador
    {
        static string tabela = "administrador";

        static string[] campos =
        {
            "Id_Usuario"
        };

        public static void Inserir(Administrador admin)
        {
            string[] values =
            {
                admin.ID_Usuario
            };

            TableUsuario.Inserir(admin);
            ExecutorComandos.Insert(tabela, values);

            //usuario.ID = ?
        }

        public static DataTable Visualizar()
        {
            return ExecutorComandos.Select(tabela);
        }

        public static DataTable Visualizar(string id)
        {
            return ExecutorComandos.Select(tabela, id);
        }

        public static string Visualizar(string campo, string id)
        {
            return ExecutorComandos.Select(tabela, campo, id);
        }

        public static void Alterar(Usuario usuario)
        {
            //verificar se o Id_Usuario alterou
        }

        public static void Excluir(Administrador admin)
        {
            ExecutorComandos.Delete(tabela, admin.ID);

            TableUsuario.Excluir(admin);

            admin = null;
        }
    }
}
