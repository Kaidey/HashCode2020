using System;
using System.IO;


namespace GoogleHashCode2020
{

    class ReadWriteFiles
    {

        private string outputFile;
        DirectoryInfo dirInf;
        FileInfo[] inputFiles;

        public ReadWriteFiles()
        {
            this.dirInf = new DirectoryInfo(@"../Inputs");
            this.inputFiles = this.dirInf.GetFiles("*.txt");
        }

        public FileInfo[] getInputFiles()
        {
            return this.inputFiles;
        }

        public readInfoFromFile(){
            for 
        }




    }
}