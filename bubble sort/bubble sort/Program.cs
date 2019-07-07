using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace bubble_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFileName = @"./input-data.json";
            var outputFileName = @"./output-data.json";

            var data = LoadData(inputFileName);

            PrintList(data);

            BubleSort(data);

            Console.WriteLine(Environment.NewLine + "to => " + " ");

            PrintList(data);

            SaveData(outputFileName, data);

            Console.ReadKey();
        }

 
        private static void SaveData(string fileName, List<int> data)
        {
            // serialize JSON to a string and then write string to a file
            var dataText = JsonConvert.SerializeObject(data);
            File.WriteAllText(fileName, dataText);
        }

        private static List<int> LoadData(string fileName)
        {
            var textData = File.ReadAllText(fileName);
            var data = JsonConvert.DeserializeObject<List<int>>(textData);
            return data;
        }

        private static void PrintList(List<int> data)
        {
            for (int i = 0; i < data.Count; i++) Console.Write(data[i] + " ");
        }

        private static void BubleSort(List<int> data)
        {
            for (int write = 0; write < data.Count; write++)
            {
                for (int sort = 0; sort < data.Count - 1 - write; sort++)
                {
                    if (data[sort] > data[sort + 1])
                    {
                        var temp = data[sort + 1];
                        data[sort + 1] = data[sort];
                        data[sort] = temp;
                    }
                }
            }
        }
    }
}
