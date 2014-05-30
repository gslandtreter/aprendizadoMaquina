using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ProtoBuf;

namespace ProjetoNB
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Deseja (L)er do arquivo de dados, ou (G)erar arquivo de dados? ");

            char read = Console.ReadKey().KeyChar;

            Database fullDatabase;
            if (read == 'g' || read == 'G')
            {
                fullDatabase = new Database();
                Console.Write("Gerando base de dados... ");
                fullDatabase.positivos = FileIO.loadFilesFromDirectory("..\\..\\..\\positivo");
                fullDatabase.negativos = FileIO.loadFilesFromDirectory("..\\..\\..\\negativo");

                fullDatabase.positivos.countDistinctWords();
                fullDatabase.negativos.countDistinctWords();

                fullDatabase.distinctWords = Word.getTotalWordData(fullDatabase.positivos, fullDatabase.negativos);

                using (var file = File.Create("database.bin"))
                {
                    Serializer.Serialize(file, fullDatabase);
                }

                Console.WriteLine("[OK]");
 
            }
            else
            {
                Console.Write("Lendo base de dados... ");

                using (var file = File.OpenRead("database.bin"))
                {
                    fullDatabase = Serializer.Deserialize<Database>(file);
                }

                Console.WriteLine("[OK]");

            }


            Console.WriteLine("Arquivos positivos: {0} - Palavras: {1}", fullDatabase.positivos.getFileCount(), fullDatabase.positivos.getWordCount());
            Console.WriteLine("Arquivos negativos: {0} - Palavras: {1}", fullDatabase.negativos.getFileCount(), fullDatabase.negativos.getWordCount());


            Console.ReadKey();
        }
    }
}
