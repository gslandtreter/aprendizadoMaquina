using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ProjetoNB
{
    [ProtoContract]
    class Database
    {
        [ProtoMember(1)]
        public FileCategory positivos;
        [ProtoMember(2)]
        public FileCategory negativos;

        [ProtoMember(3)]
        public Hashtable distinctWords;


        public void carregaArquivos(int min, int max, int testBegin, int testEnd)
        {
            this.positivos = FileIO.loadFilesFromDirectory("..\\..\\..\\positivo", min, max, testBegin, testEnd);
            this.negativos = FileIO.loadFilesFromDirectory("..\\..\\..\\negativo", min, max, testBegin, testEnd);

            this.positivos.countDistinctWords();
            this.negativos.countDistinctWords();

            this.distinctWords = Word.getTotalWordData(positivos, negativos);
        }

        public void aprende()
        {
            int totalFiles = this.negativos.files.Count + this.positivos.files.Count;

            this.positivos.probability = (float)this.positivos.files.Count / totalFiles;
            this.negativos.probability = (float)this.negativos.files.Count / totalFiles;

            int vocabularyCount = this.positivos.getDistinctWordCount() + this.negativos.getDistinctWordCount();

            int distintasPositivas = this.positivos.getDistinctWordCount();
            int distintasNegativas = this.negativos.getDistinctWordCount();

            foreach (DictionaryEntry palavraDistinita in this.distinctWords)
            {
                int positivasCount = this.positivos.getWordCount((String)palavraDistinita.Key);

                ((Word)palavraDistinita.Value).probabilityPos = (float)(positivasCount + 1) / (distintasPositivas + vocabularyCount);

                int negativasCount = this.negativos.getWordCount((String)palavraDistinita.Key);
                ((Word)palavraDistinita.Value).probabilityNeg = (float)(negativasCount + 1) / (distintasNegativas + vocabularyCount);
            }
        }
    }  
}
