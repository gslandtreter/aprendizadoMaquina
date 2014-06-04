using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjetoNB
{
    class Text
    {
        public Hashtable words;
        public String fileName;
        public int wordCount;

        public String classType;

        public Text()
        {
            fileName = classType = String.Empty;
            words = new Hashtable();
            wordCount = 0;
        }

        public void Classify(Database database)
        {
            double probPos = Math.Log(database.positivos.probability);
            double probNeg = Math.Log(database.negativos.probability);

            foreach (DictionaryEntry palavra in words)
            {
                if (database.distinctWords.ContainsKey(palavra.Key)) //Palavra existe no vocabulario
                {
                    probPos += Math.Log(((Word)database.distinctWords[palavra.Key]).probabilityPos);
                    probNeg += Math.Log(((Word)database.distinctWords[palavra.Key]).probabilityNeg);
                }
            }

            if (probPos >= probNeg)
                classType = "Positivo";
            else
                classType = "Negativo";
        }

    }
}
