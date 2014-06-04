using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ProjetoNB
{
    [ProtoContract]
    class Word
    {

        public String wordText;

        public int countInText;

        public float probabilityPos;
        public float probabilityNeg;

        public Word()
        {
            countInText = 0;
            probabilityPos = probabilityNeg = 0;
        }

        public static Hashtable getTotalWordData(FileCategory cat1, FileCategory cat2)
        {
            Hashtable totalWordList = new Hashtable();

            foreach (DictionaryEntry entrada in cat1.distinctWords)
            {
                Word buffer = new Word();
                buffer.wordText = ((Word)entrada.Value).wordText;
                buffer.countInText = ((Word)entrada.Value).countInText;

                totalWordList.Add(entrada.Key, buffer);
            }

            foreach (DictionaryEntry newWord in cat2.distinctWords)
            {
                if (totalWordList.ContainsKey(newWord.Key))
                {
                    Word wordMatch = (Word)totalWordList[newWord.Key];
                    ((Word)totalWordList[newWord.Key]).countInText += ((Word)newWord.Value).countInText;
                }
                else
                {
                    Word buffer = new Word();
                    buffer.wordText = ((Word)newWord.Value).wordText;
                    buffer.countInText = ((Word)newWord.Value).countInText;

                    totalWordList.Add(newWord.Key, buffer);
                }
            }

            return totalWordList;

        }
    }

    
}
