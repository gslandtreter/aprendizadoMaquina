using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ProjetoNB
{
    [ProtoContract]
    class Text
    {
        [ProtoMember(1)]
        public Hashtable words;
        [ProtoMember(2)]
        public String fileName;
        [ProtoMember(3)]
        public int wordCount;
        [ProtoMember(4)]
        public float probability;

        public Text()
        {
            fileName = String.Empty;
            words = new Hashtable();
            wordCount = 0;
            probability = 0;
        }

    }
}
