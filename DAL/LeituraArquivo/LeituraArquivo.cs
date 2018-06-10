using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL.LeituraArquivo
{
    public static class LeituraArquivo
    {
        static private List<string[]> matrizDados;

        static string nomeArquivo;
        static StreamReader read;

        static LeituraArquivo()
        {
            matrizDados = new List<string[]>();
        }

        /// <summary>
        /// Retorna uma matriz, sendo que cada linha possui as informações de uma
        /// linha do arquivo.
        /// </summary>
        /// <param name="nomeArq">Nome do arquivo que será retornado em forma de vetor.</param>
        /// <param name="caractereSeparador">Caractere que separa as informações de uma
        /// mesma linha no arquivo.</param>
        /// <returns></returns>
        static public List<string[]> LerAquivo(string nomeArq, char caractereSeparador)
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
            string[] vetorAux;
            int quantColunas = transfereDados[0].Split(caractereSeparador).Length;
            int quantLinhas = transfereDados.Length;

            for (int i = 0; i < quantLinhas; i++)
            {
                vetorAux = transfereDados[i].Split(caractereSeparador);
                matrizDados.Add(vetorAux);
            }
        }
    }
}
