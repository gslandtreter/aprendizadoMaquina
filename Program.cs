using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjetoNB
{
    class Program
    {
        static Database[] dataBases = new Database[10];

        static List<Text>[] positivos = new List<Text>[10];
        static List<Text>[] negativos = new List<Text>[10];

        static Statistics[] parciais = new Statistics[10];
        static Statistics resultado = new Statistics();
        
        static void Main(string[] args)
        {
            int baseMin = 18;

            for (int i = 0; i < 10; i++)
            {
                int testeMin =  baseMin + (i * 20);
                int testeMax =  testeMin + 19;

                Console.WriteLine("Carregando database {0} [{1}-{2}]", i + 1, testeMin, testeMax);

                dataBases[i] = new Database();
                dataBases[i].carregaArquivos(18, 217, testeMin, testeMax);

                Console.WriteLine("Arquivos positivos: {0} - Palavras: {1} - Distintas: {2}", dataBases[i].positivos.getFileCount(), dataBases[i].positivos.wordCount, dataBases[i].positivos.getDistinctWordCount());
                Console.WriteLine("Arquivos negativos: {0} - Palavras: {1} - Distintas: {2}", dataBases[i].negativos.getFileCount(), dataBases[i].negativos.wordCount, dataBases[i].negativos.getDistinctWordCount());

                dataBases[i].aprende();

                //Carrega arquivos de teste

                positivos[i] = new List<Text>();
                negativos[i] = new List<Text>();

                for (int n = testeMin; n < testeMax + 1; n++)
                {
                    positivos[i].Add(FileIO.loadPositiveFile(n));
                    negativos[i].Add(FileIO.loadNegativeFile(n));
                }
            }

            for (int i = 0; i < 10; i++)
            {
                parciais[i] = new Statistics();

                foreach (Text texto in positivos[i])
                {
                    texto.classify(dataBases[i]);

                    if (texto.classType.Equals("Positivo"))
                    {
                        resultado.truePos++;
                        parciais[i].truePos++;
                    }
                    else
                    {
                        resultado.falseNeg++;
                        parciais[i].falseNeg++;
                    }
                }

                foreach (Text texto in negativos[i])
                {
                    texto.classify(dataBases[i]);

                    if (texto.classType.Equals("Negativo"))
                    {
                        resultado.trueNeg++;
                        parciais[i].trueNeg++;
                    }
                    else
                    {
                        resultado.falsePos++;
                        parciais[i].falsePos++;
                    }
                }

                Console.WriteLine("Database [{0}] - Matriz de Confusao: ", i + 1);
                parciais[i].calcula();
                parciais[i].imprime();
            }

            Console.WriteLine("Resultado Final:");
            resultado.calcula();
            resultado.imprime();

            Console.ReadKey();
        }
    }
}
