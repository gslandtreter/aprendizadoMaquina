using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoNB
{
    class Statistics
    {
        public int truePos;
        public int trueNeg;

        public int falsePos;
        public int falseNeg;

        public float precisaoPos;
        public float precisaoNeg;

        public float medidaF;

        public Statistics()
        {
            trueNeg = truePos = falseNeg = falsePos = 0;
        }

        public void calculaPrecisao()
        {
            precisaoPos = (float)truePos / (truePos + falsePos);
            precisaoNeg = (float)trueNeg / (trueNeg + falseNeg);
        }

        public void calculaF()
        {
            medidaF = (float)(2 * truePos) / ((2 * truePos) + falsePos + falseNeg);
        }

        public void calcula()
        {
            calculaPrecisao();
            calculaF();
        }

        public void imprime()
        {
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Taxa de Verdadeiros Positivos: {0}%", (float)truePos / (truePos + falseNeg) * 100);
            Console.WriteLine("Taxa de Verdadeiros Negativos: {0}%\n", (float)trueNeg / (truePos + falseNeg) * 100);

            Console.WriteLine("Taxa de Falsos Positivos: {0}%", (float)falsePos / (truePos + falseNeg) * 100);
            Console.WriteLine("Taxa de Falsos Negativos: {0}%", (float)falseNeg / (truePos + falseNeg) * 100);

            Console.WriteLine("Precisao: {0}%", precisaoPos * 100);
            //Console.WriteLine("Precisao Negativos: {0}%", precisaoNeg * 100);
            Console.WriteLine("Medida-F: {0}%", medidaF * 100);

            Console.WriteLine("------------------------------------------");
        }
    }
}
