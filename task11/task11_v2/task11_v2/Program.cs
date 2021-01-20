using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11_v2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string contentString, searchedString;
            List<string> fileList = new List<string>();
            Dictionary<string, int> handledFileList = new Dictionary<string, int>();
            List<Task> countTaskList = new List<Task>();

            switch (args.Length)
            {
                case 2:
                    contentString = args[0];
                    searchedString = args[1];
                    break;
                case 1:
                    contentString = searchedString = args[0];
                    break;
                default:
                    contentString = searchedString = "aaaa";
                    break;
            }

            fileList = FileHelper.GetFilesList(contentString);

            foreach (string curFileName in fileList)
            {
                countTaskList.Add(FileHelper.StringCounter(curFileName, handledFileList, searchedString));
                Console.WriteLine(curFileName);
            }
            
            await Task.WhenAll(countTaskList);
            FileHelper.SaveHanledList(handledFileList);
        }
    }
    public static class FileHelper 
    {
        public static List<string> GetFilesList(string contentString = "aaaa", string targetDirectory = @"D:\Learning\Data\task11\myFolder")
        {
            List<string> fileList = new List<string>();
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.txt");
            foreach (string fileName in fileEntries)
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string contents = sr.ReadToEnd();
                    if (contents.Contains(contentString))
                    {
                        fileList.Add(fileName);
                    }
                }
            }
            return fileList;
        }
        public static async Task StringCounter(string fileName, Dictionary<string, int> handledList, string searchedString = "aaaa")
        {
            if (File.Exists(fileName))
            {
                int total = 0;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        var counts = sr
                            .ReadLine()
                            .Split(' ')
                            .GroupBy(s => s)
                            .Select(g => new { Word = g.Key, Count = g.Count() });
                        var wc = counts.SingleOrDefault(c => c.Word == searchedString);
                        total += (wc == null) ? 0 : wc.Count;
                    }
                }
                handledList.Add(fileName, total);
            }

        }
        static public void SaveHanledList(Dictionary<string, int> handledFileList, string fileName = @"D:\Learning\Data\task11\handledFileList.txt")
        {
            using (StreamWriter file = new StreamWriter(fileName))
                foreach (var entry in handledFileList)
                    file.WriteLine("[{0} {1}]", entry.Key, entry.Value);
        }
    }
}
