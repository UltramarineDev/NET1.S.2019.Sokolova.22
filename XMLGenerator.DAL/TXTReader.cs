using System;
using System.Collections.Generic;
using System.IO;
using XMLGenerator.DAL.Interface;

namespace XMLGenerator.DAL
{
    public class TXTReader : IDataReader
    {
        private string sourcePath;
        public TXTReader()
        {
            sourcePath = "C:\\Epam_Step2\\NET1.S.2019.Sokolova.22\\XMLGenerator.DAL\\Source.txt";
        }

        public IEnumerable<string> GetData()
        {
            List<string> urls = new List<string>();
            InputValidation(sourcePath);
            using (var sr = new StreamReader(sourcePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    urls.Add(line);
                }
            }

            return urls;
        }

        private static void InputValidation(string sourcePath)
        {
            if (!File.Exists(sourcePath))
            {
                throw new ArgumentException("Source file not found.", nameof(sourcePath));
            }
        }
    }
}
