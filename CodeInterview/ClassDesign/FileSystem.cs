using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution {
        public static void Main(string[] args) {
            var folder1 = new MyFolder("folder1");
            var file1 = new MyFile("file1", 5);
            folder1.AddFileObject(file1);

            var folder2 = new MyFolder("folder2");
            var file2 = new MyFile("file2", 2);
            var file3 = new MyFile("file3", 3);
            folder2.AddFileObject(file2);
            folder2.AddFileObject(file3);

            folder1.AddFileObject(folder2);

            Console.WriteLine(folder1.SizeBytes);
        }
    }

    public interface IFileType {
        string Name {get;}
        int SizeBytes {get;}
    }

    public class MyFile : IFileType {
        public string Name {get;}
        public int SizeBytes {get;}

        public MyFile(string name, int size) {
            this.Name = name;
            this.SizeBytes = size;
        }
    }

    public class MyFolder : IFileType  {
        public string Name {get;}
        public int SizeBytes {get; set;}
        private List<IFileType> FileObjectList {get;}

        public MyFolder(string folderName){
            this.Name = folderName;
            this.SizeBytes = 0;
            this.FileObjectList = new List<IFileType>();
        }

        public void AddFileObject(IFileType fileObject) {
            this.FileObjectList.Add(fileObject);
            this.SizeBytes += fileObject.SizeBytes;
        }

        public int GetTotalSize(){
            var totalSize = 0;         
            foreach(var fileObject in this.FileObjectList){
                totalSize += fileObject.SizeBytes;
            }
            return totalSize;
        }
    }
}