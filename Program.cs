using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjetoNB
{
    class Program
    {
        static void Main(string[] args)
        {

            FileCategory positivos = FileIO.loadFilesFromDirectory("..\\..\\..\\positivo");
            FileCategory negativos = FileIO.loadFilesFromDirectory("..\\..\\..\\negativo");

            Console.WriteLine("Arquivos positivos: {0}", positivos.getFileCount());
            Console.WriteLine("Arquivos negativos: {0}", negativos.getFileCount());

            Console.ReadKey();
        }
    }
}
