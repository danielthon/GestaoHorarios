﻿using System;
using System.Data;

namespace GestaoHorarios.classes.DAL
{
    class TableUsuario
    {
        static string tabela = "usuario";

        static string[] campos =
        {
            "",
            ""
        };

        public static void Inserir(string[] values) { ExecutorComandos.Insert(tabela, values); }

        public static DataTable Visualizar() { return ExecutorComandos.Select(tabela); }

        public static DataTable Visualizar(int id) { return ExecutorComandos.Select(tabela, id); }

        public static DataTable Visualizar(string[] campos, int id) { return ExecutorComandos.Select(tabela, campos, id); }

        public static void Alterar(string[] values, int id) { ExecutorComandos.Update(tabela, campos, values, id); }

        public static void Excluir(int id) { ExecutorComandos.Delete(tabela, id); }
    }
}
