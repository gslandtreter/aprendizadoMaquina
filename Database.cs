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
    }
}
