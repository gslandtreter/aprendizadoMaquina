﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ProjetoNB
{
    [ProtoContract]
    class Text
    {
        [ProtoMember(1)]
        public List<Word> words;
        [ProtoMember(2)]
        public String fileName;

        public Text()
        {
            fileName = String.Empty;
            words = new List<Word>();
        }

    }
}
