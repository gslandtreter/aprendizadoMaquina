using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ProjetoNB
{
    [ProtoContract]
    class Word
    {
        [ProtoMember(1)]
        public String wordText;
        [ProtoMember(2)]
        public int countInText;

        public static List<Word> getTotalWordData(FileCategory cat1, FileCategory cat2)
        {
            List<Word> totalWordList = new List<Word>(cat1.distinctWords);

            foreach (Word newWord in cat2.distinctWords)
            {
                Word wordMatch = totalWordList.Find(match => match.wordText.Equals(newWord.wordText));

                if (wordMatch != null)
                    wordMatch.countInText += newWord.countInText;
                else
                {
                    totalWordList.Add(newWord);
                }
            }

            return totalWordList;

        }
    }

    
}
