using System;
using System.Collections.Generic;
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
        public List<Word> distinctWords;

        public FileCategory()
        {
            files = new List<Text>();
            distinctWords = new List<Word>();
        }

        public int getFileCount()
        {
            if (files != null)
                return files.Count;
            else return 0;
        }

        public int getWordCount()
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
                foreach (Word word in text.words)
                {
                    Word wordFound = distinctWords.Find(match => match.wordText.Equals(word.wordText));
                    if (wordFound != null)
                        wordFound.countInText += word.countInText;
                    else
                    {
                        distinctWords.Add(word);
                    }
                }
            }
        }
    }
}
