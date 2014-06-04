using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjetoNB
{
    class FileIO
    {

        public static Text loadFile(String filePath)
        {
            String buffer;
            Text newText = new Text();

            using (StreamReader reader = new StreamReader(filePath))
            {
                if (reader == null)
                    return null;

                buffer = reader.ReadToEnd();
            }

            newText.fileName = Path.GetFileName(filePath);

            buffer = buffer.ToLower();

            buffer = Regex.Replace(buffer, @"[^\w\s]", "");
            buffer = Regex.Replace(buffer, @"[0-9]", "");

            String[] words = buffer.Split(' ');

            foreach (String word in words)
            {
                if (word.Length > 0)
                {
                    if (newText.words.ContainsKey(word))
                    {
                        Word wordFound = (Word)newText.words[word];
                        wordFound.countInText++;
                    }
                    else
                    {
                        Word newWord = new Word();

                        newWord.countInText = 1;
                        newWord.wordText = word;

                        newText.words.Add(word, newWord);
                    }
                }

                newText.wordCount++;
            }

            return newText;
        }

        public static FileCategory loadFilesFromDirectory(String path)
        {
            FileCategory newCategory = new FileCategory();
            string[] files = Directory.GetFiles(path, "*.txt");

            foreach (String fileName in files)
            {
                Text newFile = loadFile(fileName);

                if (newFile != null)
                {
                    newCategory.files.Add(newFile);
                    newCategory.wordCount += newFile.wordCount;
                }
            }

            return newCategory;
        }

        public static FileCategory loadFilesFromDirectory(String path, int min, int max)
        {
            FileCategory newCategory = new FileCategory();
            string[] files = Directory.GetFiles(path, "*.txt");

            foreach (String fileName in files)
            {
                int fileNum = Convert.ToInt32(Path.GetFileNameWithoutExtension(fileName));

                if (fileNum >= min && fileNum <= max)
                {
                    Text newFile = loadFile(fileName);

                    if (newFile != null)
                    {
                        newCategory.files.Add(newFile);
                        newCategory.wordCount += newFile.wordCount;
                    }
                }
                
            }

            return newCategory;
        }
    }
}
