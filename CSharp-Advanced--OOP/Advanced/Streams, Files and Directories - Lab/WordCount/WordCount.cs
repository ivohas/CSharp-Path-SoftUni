namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class Word
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public Word(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }

        public override string ToString()
        {
            return $"{Name} - {Count}";
        }
    }
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<Word> words = new List<Word>();
            
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string line;
                while ((line = wordsReader.ReadLine()) != null)
                {
                    line = line.ToLower();
                    string[] wordArgs = line.Split(' ');
                    foreach (string word in wordArgs)
                    {
                        words.Add(new Word(word, 0));
                    }
                }
            }

            using (StreamReader textReader = new StreamReader(textFilePath))
            {
                string line;
                while ((line = textReader.ReadLine()) != null)
                {
                    line = line.ToLower();
                    for (int i = 0; i < words.Count; i++)
                    {
                        char firstLetter = words[i].Name[0];
                        int wordLenght = words[i].Name.Length;
                        for (int j = 0; j < line.Length; j++)
                        {
                            char c = line[j];
                            if (line[j] == firstLetter &&
                                j + words[i].Name.Length < line.Length &&
                                j - 1 >= 0 &&
                                !char.IsLetter(line[j - 1]) &&
                                !char.IsLetter(line[j + wordLenght]) &&
                                line.Substring(j, wordLenght) == words[i].Name)
                            {
                                words[i].Count++;
                                j += wordLenght - 1;
                            }
                        }
                    }
                }
            }

            using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
            {
                foreach (Word word in words.OrderByDescending(x => x.Count))
                {
                    outputWriter.WriteLine(word);
                }
            }
        }
    }
}
