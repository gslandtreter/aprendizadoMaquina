using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoNB
{
    class FileCategory
    {
        public List<Text> files;

        public FileCategory()
        {
            files = new List<Text>();
        }

        public int getFileCount()
        {
            if (files != null)
                return files.Count;
            else return 0;
        }
    }
}
