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
        static Database fullDatabase;

        static void CarregaArquivos()
        {
            fullDatabase.positivos = FileIO.loadFilesFromDirectory("..\\..\\..\\positivo");
            fullDatabase.negativos = FileIO.loadFilesFromDirectory("..\\..\\..\\negativo");

            fullDatabase.positivos.countDistinctWords();
            fullDatabase.negativos.countDistinctWords();

            fullDatabase.distinctWords = Word.getTotalWordData(fullDatabase.positivos, fullDatabase.negativos);
        }

        static void Aprende()
        {
            int totalFiles = fullDatabase.negativos.files.Count + fullDatabase.positivos.files.Count;

            fullDatabase.positivos.probability = (float)fullDatabase.positivos.files.Count / totalFiles;
            fullDatabase.negativos.probability = (float)fullDatabase.negativos.files.Count / totalFiles;

            int vocabularyCount = fullDatabase.positivos.getDistinctWordCount() + fullDatabase.negativos.getDistinctWordCount();

            int distintasPositivas = fullDatabase.positivos.getDistinctWordCount();
            int distintasNegativas = fullDatabase.negativos.getDistinctWordCount();

            foreach (DictionaryEntry palavraDistinita in fullDatabase.distinctWords)
            {
                int positivasCount = fullDatabase.positivos.getWordCount((String)palavraDistinita.Key);
                ((Word)palavraDistinita.Value).probabilityPos = (float)(positivasCount + 1) / (distintasPositivas + vocabularyCount);

                int negativasCount = fullDatabase.negativos.getWordCount((String)palavraDistinita.Key);
                ((Word)palavraDistinita.Value).probabilityNeg = (float)(negativasCount + 1) / (distintasNegativas + vocabularyCount);
            }
        }
        static void Main(string[] args)
        {

            fullDatabase = new Database();

            CarregaArquivos();

            Console.WriteLine("Arquivos positivos: {0} - Palavras: {1} - Distintas: {2}", fullDatabase.positivos.getFileCount(), fullDatabase.positivos.wordCount, fullDatabase.positivos.getDistinctWordCount());
            Console.WriteLine("Arquivos negativos: {0} - Palavras: {1} - Distintas: {2}", fullDatabase.negativos.getFileCount(), fullDatabase.negativos.wordCount, fullDatabase.negativos.getDistinctWordCount());

            Aprende();

            Console.ReadKey();
        }
    }
}
