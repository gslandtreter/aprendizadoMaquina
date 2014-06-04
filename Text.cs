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
                    Word dictionaryWord = ((Word)database.distinctWords[palavra.Key]);
                    probPos += ((Word)palavra.Value).countInText * Math.Log(dictionaryWord.probabilityPos);
                    probNeg += ((Word)palavra.Value).countInText * Math.Log(dictionaryWord.probabilityNeg);
                }
            }

            if (probPos >= probNeg)
                classType = "Positivo";
            else
                classType = "Negativo";
        }

    }
}
