﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BLL.Entidades;
using BLL.Estruturas;

namespace BLL.LeituraArquivo
{
    public static class LeituraArquivo
    {
        static private List<IDado[]> matrizDados;

        static string nomeArquivo;
        static StreamReader read;

        static LeituraArquivo()
        {
            matrizDados = new List<IDado[]>();
        }

        public static List<IDado[]> MatrizDados { get => matrizDados; set => matrizDados = value; }

        /// <summary>
        /// Retorna uma matriz, sendo que cada linha possui as informações de uma
        /// linha do arquivo.
        /// </summary>
        /// <param name="nomeArq">Nome do arquivo que será retornado em forma de vetor.</param>
        /// <param name="caractereSeparador">Caractere que separa as informações de uma
        /// mesma linha no arquivo.</param>
        /// <returns></returns>
        static public List<IDado[]> LerAquivo(string nomeArq, char caractereSeparador)
        {
            string[] conteudoArq;

            nomeArquivo = nomeArq;

            if (nomeArquivo.IndexOf(".txt") == -1)
            {
                nomeArquivo = nomeArquivo + ".txt";
            }

            read = new StreamReader(nomeArquivo);

            string texto = read.ReadToEnd();

            texto = texto.Replace("\r", "");

            conteudoArq = texto.Split('\n');

            PreencherMatriz(conteudoArq, caractereSeparador);

            read.Close();

            return matrizDados;
        }

        static private void PreencherMatriz(string[] transfereDados, char caractereSeparador)
        {
            int quantColunas = transfereDados[0].Split(caractereSeparador).Length;
            int quantLinhas = transfereDados.Length;
            string[] dadosLinha;
            IDado[] vetorAux = new IDado[quantLinhas];
            Professor profAux = null;

            for (int i = 0; i < quantLinhas; i++)
            {
                dadosLinha = transfereDados[i].Split(caractereSeparador);
                vetorAux[0] = (IDado)new Disciplina(dadosLinha[0], int.Parse(dadosLinha[3]));
                vetorAux[1] = (IDado)new Professor(dadosLinha[1], "", "");
                vetorAux[2] = (IDado)new Periodo(int.Parse(dadosLinha[2]));

                profAux = ProcurarProfessor(dadosLinha[1]);

                if (profAux != null)
                {
                    vetorAux[1] = (IDado)profAux;
                }

                matrizDados.Add(vetorAux);

                vetorAux = new IDado[quantLinhas];
            }


        }

        static private Professor ProcurarProfessor(string nomeProf)
        {
            Professor profAux = null;
            Professor profBusca = new Professor(nomeProf, "", "");

            if (matrizDados.Count > 0)
            {
                for (int i = 0; i < matrizDados.Count; i++)
                {
                    profAux = (Professor)matrizDados[i][1];
                    if (profAux.CompareTo(profBusca) == 0)
                    {
                        return profAux;
                    }
                }
            }
            return null;
        }



    }
}
