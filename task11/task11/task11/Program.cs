using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task11
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> handledFileList = new Dictionary<string, int>();
            List<string> myFilesNames = FolderHelper.GetFilesList();
            foreach (string curFileName in myFilesNames) 
            {
                handledFileList.Add(curFileName, FileHanler.CountSearchedString(curFileName));
            }
            FileHanler.SaveHanledList(handledFileList);
        }
    }

    static class FolderHelper 
    {        
        static public List<string> GetFilesList(string targetDirectory = @"D:\Learning\Data\task11\myFolder", string searchedString = "aaaa") 
        {
            List<string> fileList = new List<string>();
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.txt");
            foreach (string fileName in fileEntries) 
            {                
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string contents = sr.ReadToEnd();
                    if (contents.Contains(searchedString))
                    {
                        fileList.Add(fileName);
                    }
                }                
            }
            return fileList;
        }
    }

    static class FileHanler {
        static public int CountSearchedString(string fileName, string searchedString = "aaaa") 
        {
            int total = 0;
            if(File.Exists(fileName))
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
            return total;
        }
        static public void SaveHanledList(Dictionary<string,int> handledFileList, string fileName = @"D:\Learning\Data\task11\handledFileList.txt") 
        {
            using (StreamWriter file = new StreamWriter(fileName))
                foreach (var entry in handledFileList)
                    file.WriteLine("[{0} {1}]", entry.Key, entry.Value);
        }
    }
}
