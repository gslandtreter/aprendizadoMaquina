using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ProjetoNB
{
    [ProtoContract]
    class FileCategory
    {
        [ProtoMember(1)]
        public List<Text> files;
        [ProtoMember(2)]
        public Hashtable distinctWords;
        [ProtoMember(3)]
        public int wordCount;
        [ProtoMember(4)]
        public float probability;

        public FileCategory()
        {
            files = new List<Text>();
            distinctWords = new Hashtable();

        }

        public int getFileCount()
        {
            if (files != null)
                return files.Count;
            else return 0;
        }

        public int getDistinctWordCount()
        {
            if (distinctWords != null)
                return distinctWords.Count;
            else return 0;
        }

        public void countDistinctWords()
        {
            distinctWords.Clear();

            foreach (Text text in files)
            {
                foreach (DictionaryEntry word in text.words)
                {
                    if (distinctWords.ContainsKey(word.Key))
                    {
                        Word wordFound = (Word)distinctWords[word.Key];
                        wordFound.countInText += ((Word)word.Value).countInText;
                    }
                    else
                    {
                        distinctWords.Add(word.Key, word.Value);
                    }
                }
            }
        }

        public int getWordCount(string word)
        {
            if (distinctWords.ContainsKey(word))
                return ((Word)distinctWords[word]).countInText;

            else return 0;
        }
    }
}
