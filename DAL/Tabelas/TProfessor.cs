using System;
using System.Data;
using GestaoHorarios.classes;
using DAL;
using DAL.MySQL;

namespace DAL.Tabelas
{
    public class TProfessor : Tabela
    {
        public TProfessor()
        {
            this.tabela = "professor";

            this.campos = new string[]
            {
                "Id_Usuario"
            };
        }

        //public static void Inserir(Professor prof)
        //{
        //    string[] values =
        //    {
        //        prof.ID_Usuario
        //    };

        //    TUsuario.Inserir(prof);
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

        //public static void Excluir(Professor prof)
        //{
        //    ExecutorComandos.Delete(tabela, prof.ID);

        //    TUsuario.Excluir(prof);

        //    prof = null;
        //}
    }
}
