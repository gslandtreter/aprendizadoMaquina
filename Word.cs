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
            Hashtable totalWordList = (Hashtable)cat1.distinctWords.Clone();

            foreach (DictionaryEntry newWord in cat2.distinctWords)
            {
                if (totalWordList.ContainsKey(newWord.Key))
                {
                    Word wordMatch = (Word)totalWordList[newWord.Key];
                    wordMatch.countInText += ((Word)newWord.Value).countInText;
                }
                else
                {
                    totalWordList.Add(newWord.Key, newWord.Value);
                }
            }

            return totalWordList;

        }
    }

    
}
